using System.Linq.Expressions;

namespace Nanis.Criteria
{
    public static class CombineExpressions<T>
    {
        public static Expression<Func<T, bool>> Combine(
            Expression<Func<T, bool>> firstExpression,
            Expression<Func<T, bool>> secondExpression,
            ExpressionType operationType
            )
        {
            var parameter = Expression.Parameter(typeof(T));
            var first = Expression.Invoke(firstExpression, parameter); 
            var second = Expression.Invoke(secondExpression, parameter);

            var combinedExpression = Expression.MakeBinary(operationType, first, second);

            return Expression.Lambda<Func<T, bool>>(combinedExpression,parameter);
        }
    }
}
