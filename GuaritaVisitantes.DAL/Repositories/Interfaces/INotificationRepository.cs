using GuaritaVisitantes.Entities.Models;
using System.Collections.Generic;

namespace GuaritaVisitantes.DAL.Repositories.Interfaces
{
    public interface INotificationRepository : IRepository<Notification>
    {
        IEnumerable<Notification> GetNotificationByUserId(string UserId);

        object[] GetNotificationByUserIdArray(string UserId);

        void Update(int Key, bool Read);
    }
}
