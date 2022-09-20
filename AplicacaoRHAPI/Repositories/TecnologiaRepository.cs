using AplicacaoRHAPI.Database;
using AplicacaoRHAPI.Models;
using AplicacaoRHAPI.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AplicacaoRHAPI.Repositories
{
    public class TecnologiaRepository : ITecnologiaRepository
    {
        //Objeto responsável por realizar a conexão com o bando de dados através do EntityFramework
        private RHContext db = new RHContext();

        //Métodos responsável por excluir uma tecnologia
        public Tecnologia DeleteTecnologia(int id)
        {
            try
            {
                var tecnologia = GetTecnologia(id);

                if (tecnologia == null)
                {
                    throw new Exception("Tecnologia não encotrado");
                }

                db.Tecnologias.Remove(tecnologia);
                db.SaveChanges();

                return tecnologia;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //Métodos responsável por listar todas as tecnologia
        public List<Tecnologia> GetTecnologias()
        {
            try
            {
                return db.Tecnologias.Include(t => t.VagasTecnologias).Include(t => t.TecnologiasCandidatos).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //Métodos responsável por buscar uma tecnologia
        public Tecnologia GetTecnologia(int id)
        {
            try
            {
                return db.Tecnologias.Include(t => t.VagasTecnologias).Include(t => t.TecnologiasCandidatos).Where(t => t.TecnologiaID == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //Métodos responsável por cadastrar uma tecnologia
        public Tecnologia PostTecnologia(Tecnologia tecnologia)
        {
            try
            {
                db.Tecnologias.Add(tecnologia);
                db.SaveChanges();

                return tecnologia;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //Métodos responsável por editar uma tecnologia
        public Tecnologia PutTecnologia(Tecnologia tecnologia)
        {
            try
            {
                db.Entry(tecnologia).State = EntityState.Modified;
                db.SaveChanges();

                return tecnologia;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public DbContext GetDb()
        {
            return db;
        }
    }
}