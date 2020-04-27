using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductsFilter.Model.Common
{
    public interface IQueryWithParamsSpecification<TEntity, in TQueryParams>
        where TEntity : IAgregateRoot
        where TQueryParams : QueryParameters
    {
        Task<IReadOnlyCollection<TEntity>> IsSatisfiedBy(TQueryParams parameters);
    }
}
