using GuaritaVisitantes.Entities.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace GuaritaVisitantes.Entities.Models
{
    public class EntradasSaidas
    {

        /// <summary>
        /// Id da Entrada ou Saida.
        /// </summary>
        [Key]
        public int EntradasSaidasId { get; set; }

        [Required]
        public Tipo Tipo { get; set; }

        /// <summary>
        /// Data da Entrada ou Saida.
        /// </summary>
        [Required]
        public DateTime Data { get; set; }

        /// <summary>
        /// Observações da Entrada ou Saida.
        /// </summary>
        public string Observacoes { get; set; }

        /// <summary>
        /// Id do Visitante relacionado.
        /// </summary>
        public int VisitanteId { get; set; }

        /// <summary>
        /// Id da Entrada referente a Saida.
        /// </summary>
        public int? EntradaId { get; set; }

        /// <summary>
        /// Id do Veiculo do Visitante.
        /// </summary>
        public int? VeiculoId { get; set; }

        /// <summary>
        /// Id do Usuário que fez o cadastro da Entrada ou Saida.
        /// </summary>
        [Required]
        public string IdUser { get; set; }

        /// <summary>
        /// Visitante relacionado.
        /// </summary>
        public virtual Visitante Visitante { get; set; }

        /// <summary>
        /// Veiculo relacionado.
        /// </summary>
        public virtual VeiculoVisitante VeiculoVisitante { get; set; }

    }
}
