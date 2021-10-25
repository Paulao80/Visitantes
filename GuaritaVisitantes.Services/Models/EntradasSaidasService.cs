using AutoMapper;
using GuaritaVisitantes.DAL.Repositories.Interfaces;
using GuaritaVisitantes.DTO.Models;
using GuaritaVisitantes.Entities.Models;
using GuaritaVisitantes.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace GuaritaVisitantes.Services.Models
{
    public class EntradasSaidasService : IEntradasSaidasService
    {
        private readonly IEntradasSaidasRepository _EntradasSaidasRepository;
        private readonly IMapper _Mapper;

        public EntradasSaidasService(IEntradasSaidasRepository entradasSaidasRepository, IMapper mapper)
        {
            _EntradasSaidasRepository = entradasSaidasRepository;
            _Mapper = mapper;
        }

        public void Add(EntradasSaidasDTO entity)
        {
            _EntradasSaidasRepository.Add(_Mapper.Map<EntradasSaidas>(entity));
        }

        public int Count()
        {
            return _EntradasSaidasRepository.Count();
        }

        public void Dispose()
        {
            _EntradasSaidasRepository.Dispose();
        }

        public EntradasSaidasDTO FindById(int id)
        {
            return _Mapper.Map<EntradasSaidasDTO>(_EntradasSaidasRepository.FindById(id));
        }

        public IEnumerable<EntradasSaidasDTO> GetAll()
        {
            return _Mapper.Map<IEnumerable<EntradasSaidasDTO>>(_EntradasSaidasRepository.GetAll());
        }

        public IEnumerable<EntradasSaidasDTO> GetAll(DateTime date)
        {
            return _Mapper.Map<IEnumerable<EntradasSaidasDTO>>(_EntradasSaidasRepository.GetAll(date));
        }

        public IEnumerable<EntradasSaidasDTO> GetEntradas()
        {
            return _Mapper.Map<IEnumerable<EntradasSaidasDTO>>(_EntradasSaidasRepository.GetEntradas());
        }

        public IEnumerable<EntradasSaidasDTO> GetEntradas(DateTime date)
        {
            return _Mapper.Map<IEnumerable<EntradasSaidasDTO>>(_EntradasSaidasRepository.GetEntradas(date));
        }

        public IEnumerable<EntradasSaidasDTO> GetSaidas()
        {
            return _Mapper.Map<IEnumerable<EntradasSaidasDTO>>(_EntradasSaidasRepository.GetSaidas());
        }

        public IEnumerable<EntradasSaidasDTO> GetSaidas(DateTime date)
        {
            return _Mapper.Map<IEnumerable<EntradasSaidasDTO>>(_EntradasSaidasRepository.GetSaidas(date));
        }

        public IEnumerable<EntradasSaidasDTO> GetVisitantes()
        {
            return _Mapper.Map<IEnumerable<EntradasSaidasDTO>>(_EntradasSaidasRepository.GetVisitantes());
        }

        public IEnumerable<EntradasSaidasDTO> GetVisitantes(DateTime date)
        {
            return _Mapper.Map<IEnumerable<EntradasSaidasDTO>>(_EntradasSaidasRepository.GetVisitantes(date));
        }

        public void Remove(EntradasSaidasDTO entity)
        {
            _EntradasSaidasRepository.Remove(_Mapper.Map<EntradasSaidas>(entity));
        }

        public void Update(EntradasSaidasDTO entity)
        {
            _EntradasSaidasRepository.Update(_Mapper.Map<EntradasSaidas>(entity));
        }

        //public object[] GetTiposArray()
        //{
        //    var listaTipos = (from Tipo t in Enum.GetValues(typeof(Tipo))
        //                     select new
        //                     {
        //                         id = ((int)t),
        //                         text = Enum.GetName(typeof(Tipo), t)
        //                     })
        //                     .ToArray();

        //    return listaTipos;
        //}

        public object[] GetEntradasArray()
        {
            return _EntradasSaidasRepository.GetEntradasArray();
        }

        public IEnumerable<EntradasSaidasDTO> FilterByEntradaId(int EntradaId)
        {
            return _Mapper.Map<IEnumerable<EntradasSaidasDTO>>(_EntradasSaidasRepository.FilterByEntradaId(EntradaId));
        }
    }
}
