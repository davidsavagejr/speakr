using AutoMapper;

namespace Web
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings(IMapperConfiguration config)
        {
            config.AddProfile<MappingProfile>();
            config.AddProfile<Core.MappingProfile>();
        }
    }
}