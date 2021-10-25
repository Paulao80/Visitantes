using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuaritaVisitantes.Entities.Models
{
    public class Veiculo
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
        /// Saidas e Entradas de Veículos relacionados.
        /// </summary>
        public virtual ICollection<SaidasEntradas> SaidasEntradas { get; set; }
    }
}
