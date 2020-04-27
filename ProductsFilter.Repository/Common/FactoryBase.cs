using AutoMapper;

namespace ProductsFilter.Repository.Common
{
    public class FactoryBase
    {
        protected IMapper _mapper;

        public FactoryBase(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
