using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicacaoRHAPI.Models
{
    public class Candidato
    {
        [Key]
        public int Id { get; set; } 
        public string Nome { get; set; }
        public List<TecnologiasCandidatos> TecnologiasCandidatos { get; set; }
        public int VagaID_FK { get; set; }

        [ForeignKey("VagaID_FK")]
        public virtual Vaga Vaga { get; set; }

    }
}