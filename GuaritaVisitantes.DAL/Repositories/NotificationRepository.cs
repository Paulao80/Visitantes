using GuaritaVisitantes.DAL.Context;
using GuaritaVisitantes.DAL.Repositories.Interfaces;
using GuaritaVisitantes.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace GuaritaVisitantes.DAL.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        GuaritaVisitantesContext context = new GuaritaVisitantesContext();

        public void Add(Notification entity)
        {
            context.Notifications.Add(entity);
            context.SaveChanges();
        }

        public int Count()
        {
            return context.Notifications.Count();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public Notification FindById(int id)
        {
            return context.Notifications.Where(x => x.NotificationId == id).FirstOrDefault();
        }

        public IEnumerable<Notification> GetAll()
        {
            return context.Notifications.ToList();
        }

        public IEnumerable<Notification> GetNotificationByUserId(string UserId)
        {
            return GetAll().Where(x => x.UserId == UserId && x.Read == false).ToList();
        }

        public object[] GetNotificationByUserIdArray(string UserId)
        {
            var menores = GetNotificationByUserId(UserId).Where(x => x.DateTime.AddHours(12) < DateTime.Now).ToList();
            foreach(var menor in menores)
            {
                menor.Read = true;
                Update(menor);
            }

            return GetNotificationByUserId(UserId).Where(x => x.DateTime.AddHours(12) >= DateTime.Now).Select(x => new
            {
                Id = x.NotificationId,
                x.Message,
                Type = x.Type.ToString(),
                DateTime = x.DateTime.ToString("dd/MM/yyyy HH:mm")
            }).ToArray();
        }

        public void Remove(Notification entity)
        {
            context.Notifications.Remove(FindById(entity.NotificationId));
            context.SaveChanges();
        }

        public void Update(Notification entity)
        {
            //context.Entry(entity).State = EntityState.Modified;
            context.Set<Notification>().AddOrUpdate(entity);
            context.SaveChanges();
        }

        public void Update(int Key, bool Read)
        {
            Notification notification = FindById(Key);
            notification.Read = Read;
            Update(notification);
        }
    }
}
