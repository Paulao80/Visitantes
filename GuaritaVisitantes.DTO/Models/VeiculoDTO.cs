using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuaritaVisitantes.DTO.Models
{
    public class VeiculoDTO
    {

        /// <summary>
        /// Id do Veículo.
        /// </summary>
        public int VeiculoId { get; set; }

        /// <summary>
        /// Descrição do veículo.
        /// </summary>
        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        /// <summary>
        /// Placa do veículo
        /// </summary>
        [Required]
        public string Placa { get; set; }

        /// <summary>
        /// Id do Usuario.
        /// </summary>
        [Display(Name = "Usuario")]
        public string UserId { get; set; }

        /// <summary>
        /// Saidas e Entradas de Veículos relacionados.
        /// </summary>
        public virtual ICollection<SaidasEntradasDTO> SaidasEntradas { get; set; }
    }
}
