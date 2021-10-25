using GuaritaVisitantes.DTO.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace GuaritaVisitantes.DTO.Models
{
    public class EntradasSaidasDTO
    {
        /// <summary>
        /// Id da Entrada ou Saida.
        /// </summary>
        public int EntradasSaidasId { get; set; }


        /// <summary>
        /// Tipo = Entrada ou Saida.
        /// </summary>
        public Tipo Tipo { get; set; }

        /// <summary>
        /// Data da Entrada ou Saida.
        /// </summary>
        public DateTime Data { get; set; }

        /// <summary>
        /// Observações da Entrada ou Saida.
        /// </summary>
        [Display(Name = "Observações")]
        [DataType(DataType.MultilineText)]
        public string Observacoes { get; set; }

        /// <summary>
        /// Id do Visitante relacionado.
        /// </summary>
        [Required]
        [Display(Name = "Visitante")]
        public int VisitanteId { get; set; }

        /// <summary>
        /// Id do Veiculo do Visitante.
        /// </summary>
        [Display(Name = "Veiculo")]
        public int? VeiculoId { get; set; }

        /// <summary>
        /// Id da Entrada referente a Saida.
        /// </summary>
        [Display(Name = "Entrada")]
        public int? EntradaId { get; set; }

        /// <summary>
        /// Id do Usuário que fez o cadastro da Entrada ou Saida.
        /// </summary>
        public string IdUser { get; set; }

        /// <summary>
        /// Visitante relacionado.
        /// </summary>
        public virtual VisitanteDTO Visitante { get; set; }

        /// <summary>
        /// Veiculo relacionado.
        /// </summary>
        public virtual VeiculoVisitanteDTO VeiculoVisitante { get; set; }
    }
}
