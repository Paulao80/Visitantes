using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuaritaVisitantes.Entities.Models
{
    public class Visitante
    {
        /// <summary>
        /// Id do Visitante.
        /// </summary>
        [Key]
        public int VisitanteId { get; set; }

        /// <summary>
        /// Nome do Visitante.
        /// </summary>
        [Required]
        public string Nome { get; set; }

        /// <summary>
        /// Telefone do Visitante.
        /// </summary>
        [Required]
        public string Telefone { get; set; }

        /// <summary>
        /// CNH ou RG do Visitante.
        /// </summary>
        [Required]
        public string CnhRg { get; set; }

        /// <summary>
        /// Caminho da Foto da CNH ou RG do Visitante.
        /// </summary>
        public string CnhRgPath { get; set; }

        /// <summary>
        /// Caminho da Foto de perfil do Visitante.
        /// </summary>
        public string FotoPath { get; set; }


        /// <summary>
        /// Id do Usuário que fez o cadastro do Visitante.
        /// </summary>
        [Required]
        public string IdUser { get; set; }

        /// <summary>
        /// Entradas ou Saidas Relacionadas.
        /// </summary>
        public virtual ICollection<EntradasSaidas> EntradasSaidas { get; set; }

    }
}
