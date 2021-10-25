using AutoMapper;
using GuaritaVisitantes.DAL.Repositories.Interfaces;
using GuaritaVisitantes.DTO.Models;
using GuaritaVisitantes.Entities.Models;
using GuaritaVisitantes.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace GuaritaVisitantes.Services.Models
{
    public class SaidasEntradasService : ISaidasEntradasService
    {

        private readonly ISaidasEntradasRepository _SaidasEntradasRepository;
        private readonly IMapper _Mapper;

        public SaidasEntradasService(ISaidasEntradasRepository saidasEntradasRepository, IMapper mapper)
        {
            _SaidasEntradasRepository = saidasEntradasRepository;
            _Mapper = mapper;
        }

        public void Add(SaidasEntradasDTO entity)
        {
            _SaidasEntradasRepository.Add(_Mapper.Map<SaidasEntradas>(entity));
        }

        public int Count()
        {
            return _SaidasEntradasRepository.Count();
        }

        public void Dispose()
        {
            _SaidasEntradasRepository.Dispose();
        }

        public IEnumerable<SaidasEntradasDTO> FilterBySaidaId(int SaidaId)
        {
            return _Mapper.Map<IEnumerable<SaidasEntradasDTO>>(_SaidasEntradasRepository.FilterBySaidaId(SaidaId));
        }

        public SaidasEntradasDTO FindById(int id)
        {
            return _Mapper.Map<SaidasEntradasDTO>(_SaidasEntradasRepository.FindById(id));
        }

        public IEnumerable<SaidasEntradasDTO> GetAll(DateTime date)
        {
            return _Mapper.Map<IEnumerable<SaidasEntradasDTO>>(_SaidasEntradasRepository.GetAll(date));
        }

        public IEnumerable<SaidasEntradasDTO> GetAll()
        {
            return _Mapper.Map<IEnumerable<SaidasEntradasDTO>>(_SaidasEntradasRepository.GetAll());
        }

        public IEnumerable<SaidasEntradasDTO> GetEntradas()
        {
            return _Mapper.Map<IEnumerable<SaidasEntradasDTO>>(_SaidasEntradasRepository.GetEntradas());
        }

        public IEnumerable<SaidasEntradasDTO> GetEntradas(DateTime date)
        {
            return _Mapper.Map<IEnumerable<SaidasEntradasDTO>>(_SaidasEntradasRepository.GetEntradas(date));
        }

        public IEnumerable<SaidasEntradasDTO> GetSaidas()
        {
            return _Mapper.Map<IEnumerable<SaidasEntradasDTO>>(_SaidasEntradasRepository.GetSaidas());
        }

        public IEnumerable<SaidasEntradasDTO> GetSaidas(DateTime date)
        {
            return _Mapper.Map<IEnumerable<SaidasEntradasDTO>>(_SaidasEntradasRepository.GetSaidas(date));
        }

        public object[] GetSaidasArray()
        {
            return _SaidasEntradasRepository.GetSaidasArray();
        }

        public IEnumerable<SaidasEntradasDTO> GetVeiculos()
        {
            return _Mapper.Map<IEnumerable<SaidasEntradasDTO>>(_SaidasEntradasRepository.GetVeiculos());
        }

        public IEnumerable<SaidasEntradasDTO> GetVeiculos(DateTime date)
        {
            return _Mapper.Map<IEnumerable<SaidasEntradasDTO>>(_SaidasEntradasRepository.GetVeiculos(date));
        }

        public void Remove(SaidasEntradasDTO entity)
        {
            _SaidasEntradasRepository.Remove(_Mapper.Map<SaidasEntradas>(entity));
        }

        public void Update(SaidasEntradasDTO entity)
        {
            _SaidasEntradasRepository.Update(_Mapper.Map<SaidasEntradas>(entity));
        }
    }
}
