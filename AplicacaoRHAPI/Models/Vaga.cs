using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplicacaoRHAPI.Models
{
    public class Vaga
    {
        [Key]
        public int VagaId { get; set; }
        public string DescricaoVaga { get; set; }
        public List<Candidato> Candidatos { get; set; }
        public List<VagasTecnologias> VagasTecnologias { get; set; }

    }
}