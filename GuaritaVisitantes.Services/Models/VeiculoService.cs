using AutoMapper;
using GuaritaVisitantes.DAL.Repositories.Interfaces;
using GuaritaVisitantes.DTO.Models;
using GuaritaVisitantes.Entities.Models;
using GuaritaVisitantes.Services.Interfaces;
using System.Collections.Generic;

namespace GuaritaVisitantes.Services.Models
{
    public class VeiculoService : IVeiculoService
    {

        private readonly IVeiculoRepository _VeiculoRepository;
        private readonly IMapper _Mapper;

        public VeiculoService(IVeiculoRepository veiculoRepository, IMapper mapper)
        {
            _VeiculoRepository = veiculoRepository;
            _Mapper = mapper;
        }

        public void Add(VeiculoDTO entity)
        {
            _VeiculoRepository.Add(_Mapper.Map<Veiculo>(entity));
        }

        public int Count()
        {
            return _VeiculoRepository.Count();
        }

        public void Dispose()
        {
            _VeiculoRepository.Dispose();
        }

        public VeiculoDTO FindById(int id)
        {
            return _Mapper.Map<VeiculoDTO>(_VeiculoRepository.FindById(id));
        }

        public VeiculoDTO FindByPlaca(string placa)
        {
            return _Mapper.Map<VeiculoDTO>(_VeiculoRepository.FindByPlaca(placa));
        }

        public IEnumerable<VeiculoDTO> GetAll()
        {
            return _Mapper.Map<IEnumerable<VeiculoDTO>>(_VeiculoRepository.GetAll());
        }

        public object[] GetVeiculosArray()
        {
            return _VeiculoRepository.GetVeiculosArray();
        }

        public void Remove(VeiculoDTO entity)
        {
            _VeiculoRepository.Remove(_Mapper.Map<Veiculo>(entity));
        }

        public void Update(VeiculoDTO entity)
        {
            _VeiculoRepository.Update(_Mapper.Map<Veiculo>(entity));
        }
    }
}
