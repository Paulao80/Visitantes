using GuaritaVisitantes.DTO.Models;
using GuaritaVisitantes.DTO.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuaritaVisitantes.Services.Interfaces
{
    public interface INotificationService : IService<NotificationDTO>
    {
        IEnumerable<NotificationDTO> GetNotificationByUserId(string UserId);
        void Add(NotificationType Type, string UserId);
        object[] GetNotificationByUserIdArray(string UserId);

        void Update(int Key, bool Read);
    }
}
