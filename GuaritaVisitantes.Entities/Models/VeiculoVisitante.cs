using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuaritaVisitantes.Entities.Models
{
    public class VeiculoVisitante
    {
        /// <summary>
        /// Id do Veículo.
        /// </summary>
        [Key]
        public int VeiculoId { get; set; }

        /// <summary>
        /// Descrição do veículo.
        /// </summary>
        [Required]
        public string Descricao { get; set; }

        /// <summary>
        /// Placa do veículo
        /// </summary>
        [Required]
        public string Placa { get; set; }

        /// <summary>
        /// Id do Usuario.
        /// </summary>
        [Required]
        public string UserId { get; set; }


        /// <summary>
        /// Entradas e Saidas de Veículos relacionados.
        /// </summary>
        public virtual ICollection<EntradasSaidas> EntradasSaidas { get; set; }
    }
}
