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
    public class CandidatoRepository : ICandidatoRepository
    {
        //Objeto responsável por realizar a conexão com o bando de dados através do EntityFramework
        private RHContext db = new RHContext();

        //Métodos responsável por excluir um candidato
        public Candidato DeleteCandidato(int id)
        {
            try
            {
                var candidato = GetCandidato(id);

                if (candidato == null)
                {
                    throw new Exception("Candidato não encotrado");
                }
                db.Candidatos.Remove(candidato);
                db.SaveChanges();

                return candidato;
            }
            catch(Exception e) 
            {
                throw new Exception(e.Message);
            }
        }

        //Métodos responsável por buscar um candidato
        public Candidato GetCandidato(int id)
        {
            try
            {
                return db.Candidatos.Include(c => c.Vaga).Include(c => c.TecnologiasCandidatos).Where(c => c.Id == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //Métodos responsável por listar todos os candidatos
        public List<Candidato> GetCandidatos()
        {
            try
            {
                return db.Candidatos.Include(c => c.Vaga).Include(c => c.TecnologiasCandidatos).ToList();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //Métodos responsável por cadastrar um candidato
        public Candidato PostCandidato(Candidato candidato)
        {
            try
            {
                db.Candidatos.Add(candidato);
                db.SaveChanges();

                return candidato;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        //Métodos responsável por editar um candidato
        public Candidato PutCandidato(Candidato candidato)
        {
            try
            {
                db.Entry(candidato).State = EntityState.Modified;
                db.SaveChanges();

                //Ao editar um candidato, sempre são apagados todas as tecnologias relacionadas ao candidato, e na sequencia inseridos as novas tecnologias
                DeleteTecnologiasCandidatos(candidato);
                PostTecnologiasCandidatos(candidato);

                return candidato;
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

        //Métodos responsável por excluir as tecnologias do candidato
        public void DeleteTecnologiasCandidatos(Candidato candidato)
        {
            try
            {
                var candidatoTecnologia = GetTecnologiaCandidato(candidato.Id);

                if (candidatoTecnologia != null)
                {
                    foreach (var item in candidatoTecnologia)
                    {
                        db.TecnologiasCandidatos.Remove(item);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //Métodos responsável por cadastrar as tecnologias do candidato
        public void PostTecnologiasCandidatos(Candidato candidato)
        {
            try
            {

                foreach (var item in candidato.TecnologiasCandidatos.ToList())
                {
                    var candidatosTecnologia = new TecnologiasCandidatos();
                    candidatosTecnologia.TecnologiaId = item.TecnologiaId;
                    candidatosTecnologia.CandidatoId = item.CandidatoId;

                    db.TecnologiasCandidatos.Add(candidatosTecnologia);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //Métodos responsável por buscar as tecnologias do candidato
        public List<TecnologiasCandidatos> GetTecnologiaCandidato(int CandidatoId)
        {
            try
            {
                return db.TecnologiasCandidatos.Where(t => t.CandidatoId == CandidatoId).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}