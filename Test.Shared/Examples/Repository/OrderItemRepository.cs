﻿using Microsoft.EntityFrameworkCore;
using Nanis.Repository;
using Nanis.Shared.Faker;

namespace Nanis.Test.Shared.Examples.Repository
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemsRepository
    {
        public OrderItemRepository(DbContext context) : base(context)
        {
        }
    }
}
