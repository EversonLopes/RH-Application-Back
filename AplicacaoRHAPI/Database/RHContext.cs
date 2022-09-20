using AplicacaoRHAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AplicacaoRHAPI.Database
{
    public class RHContext : DbContext
    {
        //Construitor da classe, no qual é definido suas propriedades no arquivo web.config
        public RHContext() : base("name=RHContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Criação das chaves para as tabelas com associação muitos para muitos
            modelBuilder.Entity<VagasTecnologias>().HasKey(vt => new { vt.VagaId, vt.TecnologiaId, vt.Id});
            modelBuilder.Entity<TecnologiasCandidatos>().HasKey(tc => new { tc.CandidatoId, tc.TecnologiaId, tc.Id });
        }

        //Modelos que serão espelhadas no banco de dados
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Tecnologia> Tecnologias { get; set; }
        public DbSet<Vaga> Vagas { get; set; }
        public DbSet<VagasTecnologias> VagasTecnologias { get; set; }
        public DbSet<TecnologiasCandidatos> TecnologiasCandidatos { get; set; }
    }

}
