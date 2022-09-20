using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AplicacaoRHAPI.Models
{
    public class Tecnologia
    {
        [Key]
        public int TecnologiaID { get; set; }
        public string Nome { get; set; }
        public List<VagasTecnologias> VagasTecnologias { get; set; }
        public List<TecnologiasCandidatos> TecnologiasCandidatos { get; set; }
    }
}