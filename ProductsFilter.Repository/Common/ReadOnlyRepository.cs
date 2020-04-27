using ProductsFilter.Model.Common;
using System.Linq;

namespace ProductsFilter.Repository.Common
{
    public class ReadOnlyRepository
    {
        protected IQueryable<T> AppendWhereExpressions<T>(IQueryable<T> dynamicQuery, QueryExpression<T> queryMetadata)
            where T : IAgregateRoot
        {
            if (queryMetadata == null) return dynamicQuery;

            if (queryMetadata.WhereExpression.Any())
            {
                foreach (var whereExpression in queryMetadata.WhereExpression)
                {
                    dynamicQuery = dynamicQuery.Where(whereExpression);
                }
            }

            return dynamicQuery;
        }
    }
}
