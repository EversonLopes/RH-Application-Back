using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicacaoRHAPI.Models
{
    public class TecnologiasCandidatos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int CandidatoId { get; set; }
        public Candidato Candidato { get; set; }

        public int TecnologiaId { get; set; }
        public Tecnologia Tecnologia { get; set; }
    }
}