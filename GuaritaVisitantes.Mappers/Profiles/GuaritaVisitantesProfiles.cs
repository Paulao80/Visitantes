using AutoMapper;
using GuaritaVisitantes.DTO.Models;
using GuaritaVisitantes.Entities.Models;

namespace GuaritaVisitantes.Mappers.Profiles
{
    public class GuaritaVisitantesProfiles : Profile
    {
        public GuaritaVisitantesProfiles()
        {
            CreateMap<VisitanteDTO, Visitante>();
            CreateMap<EntradasSaidasDTO, EntradasSaidas>();
            CreateMap<NotificationDTO, Notification>();
            CreateMap<VeiculoDTO, Veiculo>();
            CreateMap<MotoristaDTO, Motorista>();
            CreateMap<SaidasEntradasDTO, SaidasEntradas>();
            CreateMap<VeiculoVisitanteDTO, VeiculoVisitante>();
            CreateMap<VisitanteDTO, Visitante>().ReverseMap();
            CreateMap<EntradasSaidasDTO, EntradasSaidas>().ReverseMap();
            CreateMap<NotificationDTO, Notification>().ReverseMap();
            CreateMap<VeiculoDTO, Veiculo>().ReverseMap();
            CreateMap<MotoristaDTO, Motorista>().ReverseMap();
            CreateMap<SaidasEntradasDTO, SaidasEntradas>().ReverseMap();
            CreateMap<VeiculoVisitanteDTO, VeiculoVisitante>().ReverseMap();
        }
    }
}
