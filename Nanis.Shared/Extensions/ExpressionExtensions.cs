using System.Linq.Expressions;

namespace Nanis.Criteria
{
    /// <summary>
    /// Provides extension methods for combining and manipulating expressions.
    /// </summary>
    public static class ExpressionExtensions
    {
        /// <summary>
        /// Combines two expressions with a logical "AND" operation.
        /// </summary>
        /// <typeparam name="T">The type of the input parameter for the expression.</typeparam>
        /// <param name="expr1">The first expression.</param>
        /// <param name="expr2">The second expression to combine with the first.</param>
        /// <returns>An expression representing the logical "AND" of the two expressions.</returns>
        public static Expression<Func<T, bool>> AndAlso<T>(
            this Expression<Func<T, bool>> expr1,
            Expression<Func<T, bool>> expr2)
        {
            var parameter = Expression.Parameter(typeof(T));
            var body = Expression.AndAlso(
                Expression.Invoke(expr1, parameter),
                Expression.Invoke(expr2, parameter));
            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }

        /// <summary>
        /// Combines two expressions with a logical "OR" operation.
        /// </summary>
        /// <typeparam name="T">The type of the input parameter for the expression.</typeparam>
        /// <param name="expr1">The first expression.</param>
        /// <param name="expr2">The second expression to combine with the first.</param>
        /// <returns>An expression representing the logical "OR" of the two expressions.</returns>
        public static Expression<Func<T, bool>> OrElse<T>(
            this Expression<Func<T, bool>> expr1,
            Expression<Func<T, bool>> expr2)
        {
            var parameter = Expression.Parameter(typeof(T));
            var body = Expression.OrElse(
                Expression.Invoke(expr1, parameter),
                Expression.Invoke(expr2, parameter));
            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }

        /// <summary>
        /// Negates an expression with a logical "NOT" operation.
        /// </summary>
        /// <typeparam name="T">The type of the input parameter for the expression.</typeparam>
        /// <param name="expr">The expression to negate.</param>
        /// <returns>An expression representing the logical "NOT" of the input expression.</returns>
        public static Expression<Func<T, bool>> Not<T>(
            this Expression<Func<T, bool>> expr)
        {
            var parameter = expr.Parameters[0];
            var body = Expression.Not(expr.Body);
            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
    }
}
