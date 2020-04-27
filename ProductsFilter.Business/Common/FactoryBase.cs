using AutoMapper;
using ProductsFilter.Configuration.Common;

namespace ProductsFilter.Business.Common
{
    public class FactoryBase
    {
        protected readonly IMapper _mapper;
        protected readonly IAppSettingsConfiguration _configuration;

        public FactoryBase(IMapper mapper, IAppSettingsConfiguration configuration)
        {
            _mapper = mapper;
            _configuration = configuration;
        }
    }
}
