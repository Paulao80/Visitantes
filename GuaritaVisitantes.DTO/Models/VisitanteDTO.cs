using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace GuaritaVisitantes.DTO.Models
{
    public class VisitanteDTO
    {
        /// <summary>
        /// Id do Visitante.
        /// </summary>
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
        [Display(Name = "CNH/RG")]
        public string CnhRg { get; set; }

        /// <summary>
        /// Caminho da Foto da CNH ou RG do Visitante.
        /// </summary>
        public string CnhRgPath { get; set; }

        /// <summary>
        /// Imagem da CNH ou RG.
        /// </summary>
        [Display(Name = "CNH/RG Imagem")]
        public HttpPostedFileBase CnhRgFile { get; set; }

        /// <summary>
        /// Caminho da Foto de perfil do Visitante.
        /// </summary>
        [Display(Name = "Foto do Visitante")]
        [Required]
        public string FotoPath { get; set; }


        /// <summary>
        /// Id do Usuário que fez o cadastro do Visitante.
        /// </summary>
        public string IdUser { get; set; }

        /// <summary>
        /// Entradas ou Saidas Relacionadas.
        /// </summary>
        public virtual ICollection<EntradasSaidasDTO> EntradasSaidas { get; set; }
    }
}
