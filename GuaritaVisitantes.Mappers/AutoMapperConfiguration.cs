using AutoMapper;
using GuaritaVisitantes.Mappers.Profiles;

namespace GuaritaVisitantes.Mappers
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration ConfigureMappings()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new GuaritaVisitantesProfiles());
            });
            return mapperConfiguration;
        }

    }
}
