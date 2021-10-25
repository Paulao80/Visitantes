using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuaritaVisitantes.DTO.Models
{
    public class MotoristaDTO
    {
        /// <summary>
        /// Id do Motorista.
        /// </summary>
        public int MotoristaId { get; set; }

        /// <summary>
        /// Nome do Motorista.
        /// </summary>
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// CNH ou RG do Motorista.
        /// </summary>
        [Display(Name = "CNH/RG")]
        public string CnhRg { get; set; }

        /// <summary>
        /// Id do Usuario.
        /// </summary>
        [Display(Name = "Usuario")]
        public string UserId { get; set; }

        /// <summary>
        /// Saidas ou Entradas dos Veiculos relacionados.
        /// </summary>
        public virtual ICollection<SaidasEntradasDTO> SaidasEntradas { get; set; }
    }
}
