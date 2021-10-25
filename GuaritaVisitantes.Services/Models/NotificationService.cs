using AutoMapper;
using GuaritaVisitantes.DAL.Repositories.Interfaces;
using GuaritaVisitantes.DTO.Models;
using GuaritaVisitantes.DTO.Models.Enums;
using GuaritaVisitantes.Entities.Models;
using GuaritaVisitantes.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace GuaritaVisitantes.Services.Models
{
    public class NotificationService : INotificationService
    {

        private readonly INotificationRepository _NotificationRepository;
        private readonly IMapper _Mapper;

        public NotificationService(INotificationRepository notificationRepository, IMapper mapper)
        {
            _NotificationRepository = notificationRepository;
            _Mapper = mapper;
        }

        public void Add(NotificationDTO entity)
        {
            _NotificationRepository.Add(_Mapper.Map<Notification>(entity));
        }

        public void Add(NotificationType Type, string UserId)
        {
            string Message = "";

            switch (Type)
            {
                case NotificationType.EntradaGuarita:
                    Message = "Foi Adicionado uma Entrada de um Visitante!";
                    break;

                case NotificationType.SaidaGuarita:
                    Message = "Foi Adicionado uma Saída de um Visitante!";
                    break;

                case NotificationType.SaidaTransporte:
                    Message = "Foi Adicionado uma Saída de um Veiculo";
                    break;

                case NotificationType.EntradaTransporte:
                    Message = "Foi Adicionado uma Entrada de um Veiculo";
                    break;

                case NotificationType.TrocaSenha:
                    Message = "Sua Senha foi alterada!";
                    break;

                default: break;
            }

            Add(new NotificationDTO
            {
                Message = Message,
                Type = Type,
                DateTime = DateTime.Now,
                Read = false,
                UserId = UserId
            });
        }

        public int Count()
        {
            return _NotificationRepository.Count();
        }

        public void Dispose()
        {
            _NotificationRepository.Dispose();
        }

        public NotificationDTO FindById(int id)
        {
            return _Mapper.Map<NotificationDTO>(_NotificationRepository.FindById(id));
        }

        public IEnumerable<NotificationDTO> GetAll()
        {
            return _Mapper.Map<IEnumerable<NotificationDTO>>(_NotificationRepository.GetAll());
        }

        public IEnumerable<NotificationDTO> GetNotificationByUserId(string UserId)
        {
            return _Mapper.Map<IEnumerable<NotificationDTO>>(_NotificationRepository.GetNotificationByUserId(UserId));
        }

        public object[] GetNotificationByUserIdArray(string UserId)
        {
            return _NotificationRepository.GetNotificationByUserIdArray(UserId);
        }

        public void Remove(NotificationDTO entity)
        {
            _NotificationRepository.Remove(_Mapper.Map<Notification>(entity));
        }

        public void Update(NotificationDTO entity)
        {
            _NotificationRepository.Update(_Mapper.Map<Notification>(entity));
        }

        public void Update(int Key, bool Read)
        {

            _NotificationRepository.Update(Key, Read);
        }
    }
}
