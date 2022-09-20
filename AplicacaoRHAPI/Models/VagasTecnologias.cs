using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicacaoRHAPI.Models
{
    public class VagasTecnologias
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int VagaId { get; set; }
        public Vaga Vaga { get; set; }

        public int TecnologiaId { get; set; }
        public Tecnologia Tecnologia { get; set; }

        public int PesoTecnologia { get; set; }

    }
}