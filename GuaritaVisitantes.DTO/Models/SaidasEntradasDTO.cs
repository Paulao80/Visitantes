using GuaritaVisitantes.DTO.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace GuaritaVisitantes.DTO.Models
{
    public class SaidasEntradasDTO
    {
        /// <summary>
        /// Id da Saida ou Entrada. 
        /// </summary>
        public int SaidaEntradaId { get; set; }

        /// <summary>
        /// Tipo Saida ou Entrada.
        /// </summary>
        public Tipo Tipo { get; set; }

        /// <summary>
        /// Data/Hora da Entrada ou Saida.
        /// </summary>
        public DateTime Data { get; set; }

        /// <summary>
        /// Quilômetros na Saida ou Entrada.
        /// </summary>
        public double? KM { get; set; }

        /// <summary>
        /// Observações da Saida ou Entrada.
        /// </summary>
        [Display(Name = "Observações")]
        public string Observacoes { get; set; }

        /// <summary>
        /// Id do Veiculo relacionado.
        /// </summary>
        [Required]
        [Display(Name = "Veiculo")]
        public int VeiculoId { get; set; }

        /// <summary>
        /// Id do Motorista relacionado.
        /// </summary>
        [Required]
        [Display(Name = "Motorista")]
        public int MotoristaId { get; set; }

        /// <summary>
        /// Id da Saida referente a Entrada.
        /// </summary>
        [Display(Name = "Saida")]
        public int? SaidaId { get; set; }

        /// <summary>
        /// Id do Usuario.
        /// </summary>
        [Display(Name = "Usuario")]
        public string UserId { get; set; }

        /// <summary>
        /// Veiculo relacionado.
        /// </summary>
        public virtual VeiculoDTO Veiculo { get; set; }

        /// <summary>
        /// Motorista relacionado.
        /// </summary>
        public virtual MotoristaDTO Motorista { get; set; }
    }
}
