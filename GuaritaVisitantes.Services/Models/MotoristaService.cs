using AutoMapper;
using GuaritaVisitantes.DAL.Repositories.Interfaces;
using GuaritaVisitantes.DTO.Models;
using GuaritaVisitantes.Entities.Models;
using GuaritaVisitantes.Services.Interfaces;
using System.Collections.Generic;

namespace GuaritaVisitantes.Services.Models
{
    public class MotoristaService : IMotoristaService
    {

        private readonly IMotoristaRepository _MotoristaRepository;
        private readonly IMapper _Mapper;

        public MotoristaService(IMotoristaRepository motoristaRepository, IMapper mapper)
        {
            _MotoristaRepository = motoristaRepository;
            _Mapper = mapper;
        }

        public void Add(MotoristaDTO entity)
        {
            _MotoristaRepository.Add(_Mapper.Map<Motorista>(entity));
        }

        public int Count()
        {
            return _MotoristaRepository.Count();
        }

        public void Dispose()
        {
            _MotoristaRepository.Dispose();
        }

        public MotoristaDTO FindByCnhRg(string CnhRg)
        {
            return _Mapper.Map<MotoristaDTO>(_MotoristaRepository.FindByCnhRg(CnhRg));
        }

        public MotoristaDTO FindById(int id)
        {
            return _Mapper.Map<MotoristaDTO>(_MotoristaRepository.FindById(id));
        }

        public IEnumerable<MotoristaDTO> GetAll()
        {
            return _Mapper.Map<IEnumerable<MotoristaDTO>>(_MotoristaRepository.GetAll());
        }

        public object[] GetMotoristaArray()
        {
            return _MotoristaRepository.GetMotoristaArray();
        }

        public void Remove(MotoristaDTO entity)
        {
            _MotoristaRepository.Remove(_Mapper.Map<Motorista>(entity));
        }

        public void Update(MotoristaDTO entity)
        {
            _MotoristaRepository.Update(_Mapper.Map<Motorista>(entity));
        }
    }
}
