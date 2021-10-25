using AutoMapper;
using GuaritaVisitantes.DAL.Repositories.Interfaces;
using GuaritaVisitantes.DTO.Models;
using GuaritaVisitantes.Entities.Models;
using GuaritaVisitantes.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GuaritaVisitantes.Services.Models
{
    public class VisitanteService : IVisitanteService
    {
        private readonly IVisitanteRepository _VisitanteRepository;
        private readonly IMapper _Mapper;

        public VisitanteService(IVisitanteRepository visitanteRepository, IMapper mapper)
        {
            _VisitanteRepository = visitanteRepository;
            _Mapper = mapper;
        }

        public void Add(VisitanteDTO entity)
        {
            _VisitanteRepository.Add(_Mapper.Map<Visitante>(entity));
        }

        public int Count()
        {
            return _VisitanteRepository.Count();
        }

        public void Dispose()
        {
            _VisitanteRepository.Dispose();
        }

        public VisitanteDTO FindById(int id)
        {
            return _Mapper.Map<VisitanteDTO>(_VisitanteRepository.FindById(id));
        }

        public IEnumerable<VisitanteDTO> GetAll()
        {
            return _Mapper.Map<IEnumerable<VisitanteDTO>>(_VisitanteRepository.GetAll());
        }

        public void Remove(VisitanteDTO entity)
        {
            _VisitanteRepository.Remove(_Mapper.Map<Visitante>(entity));
        }

        public void Update(VisitanteDTO entity)
        {
            _VisitanteRepository.Update(_Mapper.Map<Visitante>(entity));
        }

        public object[] GetVisitantesArray()
        {
            return _VisitanteRepository.GetVisitantesArray();      
        }

        public VisitanteDTO FindByRgCnh(string RgCnh)
        {
            return _Mapper.Map<VisitanteDTO>(_VisitanteRepository.FindByRgCnh(RgCnh));
        }
    }
}
