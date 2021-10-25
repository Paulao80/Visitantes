using GuaritaVisitantes.DTO.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace GuaritaVisitantes.DTO.Models
{
    public class NotificationDTO
    {
        /// <summary>
        /// Id da Notificação.
        /// </summary>
        public int NotificationId { get; set; }

        /// <summary>
        /// Messagem da Notificação.
        /// </summary>
        [Required]
        public string Message { get; set; }

        /// <summary>
        /// Tipo da Notificação.
        /// </summary>
        [Required]
        public NotificationType Type { get; set; }

        /// <summary>
        /// Data/Hora da Notificação.
        /// </summary>
        [Required]
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Se a Notificação foi lida ou não.
        /// </summary>
        public bool Read { get; set; }

        /// <summary>
        /// Id do Usuario.
        /// </summary>
        public string UserId { get; set; }
    }
}
