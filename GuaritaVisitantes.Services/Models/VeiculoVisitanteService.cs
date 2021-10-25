using AutoMapper;
using GuaritaVisitantes.DAL.Repositories.Interfaces;
using GuaritaVisitantes.DTO.Models;
using GuaritaVisitantes.Entities.Models;
using GuaritaVisitantes.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuaritaVisitantes.Services.Models
{
    public class VeiculoVisitanteService : IVeiculoVisitanteService
    {

        private readonly IVeiculoVisitanteRepository _VeiculoVisitanteRepository;
        private readonly IMapper _Mapper;

        public VeiculoVisitanteService(IVeiculoVisitanteRepository veiculoVisitanteRepository, IMapper mapper)
        {
            _VeiculoVisitanteRepository = veiculoVisitanteRepository;
            _Mapper = mapper;
        }

        public void Add(VeiculoVisitanteDTO entity)
        {
            _VeiculoVisitanteRepository.Add(_Mapper.Map<VeiculoVisitante>(entity));
        }

        public int Count()
        {
            return _VeiculoVisitanteRepository.Count();
        }

        public void Dispose()
        {
            _VeiculoVisitanteRepository.Dispose();
        }

        public VeiculoVisitanteDTO FindById(int id)
        {
            return _Mapper.Map<VeiculoVisitanteDTO>(_VeiculoVisitanteRepository.FindById(id));
        }

        public VeiculoVisitanteDTO FindByPlaca(string placa)
        {
            return _Mapper.Map<VeiculoVisitanteDTO>(_VeiculoVisitanteRepository.FindByPlaca(placa));
        }

        public IEnumerable<VeiculoVisitanteDTO> GetAll()
        {
            return _Mapper.Map<IEnumerable<VeiculoVisitanteDTO>>(_VeiculoVisitanteRepository.GetAll());
        }

        public object[] GetVeiculosArray()
        {
            return _VeiculoVisitanteRepository.GetVeiculosArray();
        }

        public void Remove(VeiculoVisitanteDTO entity)
        {
            _VeiculoVisitanteRepository.Remove(_Mapper.Map<VeiculoVisitante>(entity));
        }

        public void Update(VeiculoVisitanteDTO entity)
        {
            _VeiculoVisitanteRepository.Update(_Mapper.Map<VeiculoVisitante>(entity));
        }
    }
}
