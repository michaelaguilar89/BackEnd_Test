using AutoMapper;
using WebApi_Test.Models;

namespace WebApi_Test.Mapping
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Client_DTO, Client>();
                config.CreateMap<Client, Client_DTO>();
            });
            return mappingConfig;
        }
    }
}
