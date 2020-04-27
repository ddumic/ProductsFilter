using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProductsFilter.Model.Common
{
    public class QueryExpression<TEntity>
        where TEntity : IAgregateRoot
    {
        public IList<Expression<Func<TEntity, bool>>> WhereExpression { get; }

        public QueryExpression()
        {
            WhereExpression = new List<Expression<Func<TEntity, bool>>>();
        }

        public void AddWhereExpression(Expression<Func<TEntity, bool>> expression)
        {
            WhereExpression.Add(expression);
        }
    }
}
