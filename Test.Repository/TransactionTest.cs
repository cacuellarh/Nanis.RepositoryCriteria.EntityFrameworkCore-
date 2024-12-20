﻿using Nanis.Shared;
using Nanis.Shared.Faker;
using Nanis.Test.Shared;
using Nanis.Test.Shared.Examples.Criteria.client;
using Nanis.Test.Shared.Examples.Criteria.invoice;
using Nanis.Test.Shared.Examples.Criteria.order;
using Nanis.Test.Shared.Examples.Criteria.paymentMethod;
using Nanis.Test.Shared.Examples.Criteria.product;
using Nanis.Test.Shared.Examples.Criteria.stock;
using Nanis.Test.Shared.Examples.Repository;
using System.Transactions;

namespace Test.Repository.Faker
{
    [TestClass]
    public class TransactionTest : StartUpTest
    {
        private IClientRepository clientRepository;
        private IProductRepository productRepository;
        private IPaymentMethodRepository paymentMethodRepository;
        private IInvoiceRepository invoiceRepository;
        private IOrderRepository orderRepository;
        private IStockRepository stockRepository;

        [TestInitialize]
        public void Setup()
        {
            clientRepository = UnitOfWork.Repository<Client, IClientRepository>();
            clientRepository = UnitOfWork.Repository<Client, IClientRepository>();
            productRepository = UnitOfWork.Repository<Product, IProductRepository>();
            paymentMethodRepository = UnitOfWork.Repository<PaymentMethod, IPaymentMethodRepository>();
            invoiceRepository = UnitOfWork.Repository<Invoice, IInvoiceRepository>();
            orderRepository = UnitOfWork.Repository<Order, IOrderRepository>();
            stockRepository = UnitOfWork.Repository<Stock, IStockRepository>();
        }

        [TestMethod]
        [TestCategory("IntegrationTest")]
        public async Task Can_create_InvoiceTransaction()
        {

            int idClient = 1;
            Client client = await clientRepository.GetAsync(new ClientByIdCriteria(idClient));


            var productsLessThan4000 = await productRepository.GetAllAsync(new ProductsPriceLessThen(4000m));

            var quantityProducts = 2;
            List<OrderItem> orderItems = new List<OrderItem>();

            foreach (var product in productsLessThan4000)
            {
                orderItems.Add(new OrderItem(product, quantityProducts));
            }
            var paymentMethod = await paymentMethodRepository.GetAsync(new PaymentMethodByIdCriteria(1));

            Order order = new Order(client, orderItems, paymentMethod);

            decimal total = order.CalculateTotal();
            await orderRepository.CreateAsync(order);

            Invoice invoice = new Invoice(client, total);
            await invoiceRepository.CreateAsync(invoice);

            var result = await UnitOfWork.Commit();

            // Assert
            Assert.IsNotNull(result, "Transaction commit result should not be null.");
            Assert.AreEqual(13, result, "Transaction result ID does not match expected.");

            // Additional Assertions to Validate Data Consistency
            var savedOrder = await orderRepository.GetAsync(new OrderByIdCriteria(order.Id));
            Assert.IsNotNull(savedOrder, "Order should be saved in the database.");
            Assert.AreEqual(orderItems.Count, savedOrder.items.Count, "The number of order items does not match.");
            Assert.AreEqual(total, savedOrder.CalculateTotal(), "Order total does not match expected value.");

            var savedInvoice = await invoiceRepository.GetAsync(new InvoiceByIdCriteria(invoice.Id));
            Assert.IsNotNull(savedInvoice, "Invoice should be saved in the database.");
            Assert.AreEqual(total, savedInvoice.Total, "Invoice total does not match expected value.");
            Assert.AreEqual(client.Id, savedInvoice.Client.Id, "Invoice should be linked to the correct client.");

            foreach (var item in savedOrder.items)
            {
                Assert.IsTrue(productsLessThan4000.Any(p => p.Id == item.Product.Id), "Order item product should be part of the original product list.");
                Assert.AreEqual(quantityProducts, item.Quantity, "Order item quantity does not match.");
            }

        }

        [TestMethod]
        [TestCategory("IntegrationTest")]
        public async Task Can_Discount_StockItem()
        {

            int idClient = 1;
            Client client = await clientRepository.GetAsync(new ClientByIdCriteria(idClient));


            var productsLessThan4000 = await productRepository.GetAllAsync(new ProductsPriceLessThen(4000m));

            var quantityProducts = 2;
            List<OrderItem> orderItems = new List<OrderItem>();

            foreach (var product in productsLessThan4000)
            {
                orderItems.Add(new OrderItem(product, quantityProducts));
            }
            var paymentMethod = await paymentMethodRepository.GetAsync(new PaymentMethodByIdCriteria(1));

            Order order = new Order(client, orderItems, paymentMethod);

            decimal total = order.CalculateTotal();
            await orderRepository.CreateAsync(order);

            Invoice invoice = new Invoice(client, total);
            await invoiceRepository.CreateAsync(invoice);

            foreach (var item in order.items)
            {
                var stock = await stockRepository.GetAsync(new StockByProductIdCriteria(item.Product.Id));
                if (stock.Cuantity < item.Quantity)
                {
                    UnitOfWork.RollBack();
                    throw new InvalidOperationException("Not enough stock available.");
                }
                stock.Cuantity -= item.Quantity; // Usar el operador -= para reducir la cantidad
                await stockRepository.UpdateAsync(stock);
            }

            var result = await UnitOfWork.Commit();

            // Assert
            Assert.IsNotNull(result, "Transaction commit result should not be null.");

            // Additional Assertions to Validate Data Consistency
            var savedOrder = await orderRepository.GetAsync(new OrderByIdCriteria(order.Id));
            Assert.IsNotNull(savedOrder, "Order should be saved in the database.");
            Assert.AreEqual(orderItems.Count, savedOrder.items.Count, "The number of order items does not match.");
            Assert.AreEqual(total, savedOrder.CalculateTotal(), "Order total does not match expected value.");

            var savedInvoice = await invoiceRepository.GetAsync(new InvoiceByIdCriteria(invoice.Id));
            Assert.IsNotNull(savedInvoice, "Invoice should be saved in the database.");
            Assert.AreEqual(total, savedInvoice.Total, "Invoice total does not match expected value.");
            Assert.AreEqual(client.Id, savedInvoice.Client.Id, "Invoice should be linked to the correct client.");

            foreach (var item in savedOrder.items)
            {
                Assert.IsTrue(productsLessThan4000.Any(p => p.Id == item.Product.Id), "Order item product should be part of the original product list.");
                Assert.AreEqual(quantityProducts, item.Quantity, "Order item quantity does not match.");
            }
        }

        [TestMethod]
        [TestCategory("IntegrationTest")]
        public async Task Concurrent_Orders_Should_Fail_With_IsolationLevel_Serializable()
        {
            var productId = 1;
            var initialStock = 1;

            // Configurar el stock inicial
            using (var unitOfWork = UnitOfWork)
            {
                var stock = await stockRepository.GetAsync(new StockByProductIdCriteria(productId));
                stock.Cuantity = initialStock;
                await stockRepository.UpdateAsync(stock);
                await unitOfWork.Commit();
            }

            // Ejecutar acciones simultáneas de dos transacciones
            var task1 = Task.Run(() => TryPlaceOrderAsync(productId, delay: 100));
            var task2 = Task.Run(() => TryPlaceOrderAsync(productId, delay: 200));

            var results = await Task.WhenAll(task1, task2);

            // Verificar que solo una transacción se haya completado
            Assert.AreEqual(1, results.Count(r => r), "Only one transaction should succeed due to stock limitation.");

            // Validación del estado del stock
            using (var unitOfWork = UnitOfWork)
            {
                var finalStock = (await stockRepository.GetAsync(new StockByProductIdCriteria(productId))).Cuantity;
                Assert.AreEqual(0, finalStock, "Final stock should be zero after successful transaction.");
            }
        }

        private async Task<bool> TryPlaceOrderAsync(int productId, int delay)
        {
            using (var unitOfWork = UnitOfWork)
            {
                try
                {
                    unitOfWork.BeginTransaction(IsolationLevel.Serializable);

                    // Simular concurrencia con retraso
                    await Task.Delay(delay);

                    // Obtener cliente y método de pago
                    var client = await clientRepository.GetAsync(new ClientByIdCriteria(1));
                    var paymentMethod = await paymentMethodRepository.GetAsync(new PaymentMethodByIdCriteria(1));

                    // Crear el pedido para el producto especificado
                    var product = new Product { Id = productId };
                    var orderItem = new OrderItem(product, 1); // Ordenar una unidad
                    var order = new Order(client, new List<OrderItem> { orderItem }, paymentMethod);

                    await orderRepository.CreateAsync(order);

                    // Descontar stock
                    var stock = await stockRepository.GetAsync(new StockByProductIdCriteria(productId));
                    if (stock.Cuantity < orderItem.Quantity)
                    {
                        unitOfWork.RollBack();
                        return false;
                    }

                    stock.Cuantity -= orderItem.Quantity;
                    await stockRepository.UpdateAsync(stock);

                    await unitOfWork.Commit();
                    return true;
                }
                catch
                {
                    unitOfWork.RollBack();
                    return false;
                }
            }
        }
    }
}
