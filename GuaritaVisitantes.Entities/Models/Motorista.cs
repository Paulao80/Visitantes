using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuaritaVisitantes.Entities.Models
{
    public class Motorista
    {

        /// <summary>
        /// Id do Motorista.
        /// </summary>
        [Key]
        public int MotoristaId { get; set; }

        /// <summary>
        /// Nome do Motorista.
        /// </summary>
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// CNH ou RG do Motorista.
        /// </summary>
        public string CnhRg { get; set; }

        /// <summary>
        /// Id do Usuario.
        /// </summary>
        [Required]
        public string UserId { get; set; }

        /// <summary>
        /// Saidas ou Entradas dos Veiculos relacionados.
        /// </summary>
        public virtual ICollection<SaidasEntradas> SaidasEntradas { get; set; }

    }
}
