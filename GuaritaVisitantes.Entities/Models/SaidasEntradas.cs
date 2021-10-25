using GuaritaVisitantes.Entities.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace GuaritaVisitantes.Entities.Models
{
    public class SaidasEntradas
    {
        
        /// <summary>
        /// Id da Saida ou Entrada. 
        /// </summary>
        [Key]
        public int SaidaEntradaId { get; set; }

        /// <summary>
        /// Tipo Saida ou Entrada.
        /// </summary>
        [Required]
        public Tipo Tipo { get; set; }

        /// <summary>
        /// Data/Hora da Entrada ou Saida.
        /// </summary>
        [Required]
        public DateTime Data { get; set; }

        /// <summary>
        /// Quilômetros na Saida ou Entrada.
        /// </summary>
        public double? KM { get; set; }

        /// <summary>
        /// Observações da Saida ou Entrada.
        /// </summary>
        public string Observacoes { get; set; }

        /// <summary>
        /// Id do Veiculo relacionado.
        /// </summary>
        public int VeiculoId { get; set; }

        /// <summary>
        /// Id do Motorista relacionado.
        /// </summary>
        public int MotoristaId { get; set; }

        /// <summary>
        /// Id da Saida referente a Entrada.
        /// </summary>
        public int? SaidaId { get; set; }

        /// <summary>
        /// Id do Usuario.
        /// </summary>
        [Required]
        public string UserId { get; set; }

        /// <summary>
        /// Veiculo relacionado.
        /// </summary>
        public virtual Veiculo Veiculo { get; set; }

        /// <summary>
        /// Motorista relacionado.
        /// </summary>
        public virtual Motorista Motorista { get; set; }

    }
}
