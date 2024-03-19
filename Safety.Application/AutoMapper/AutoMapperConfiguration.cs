using AutoMapper;

namespace Safety.Application.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration ConfigureMappings()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperMappingProfile());
                cfg.AllowNullCollections = true;
                cfg.AllowNullDestinationValues = true;
            });

            return mapperConfiguration;
        }
    }
}
