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
    //Objeto responsável por realizar a conexão com o bando de dados através do EntityFramework
    public class VagaRepository : IVagaRepository
    {
        private RHContext db = new RHContext();

        //Métodos responsável por excluir uma vaga
        public Vaga DeleteVaga(int id)
        {
            try
            {
                var vaga = GetVaga(id);

                if (vaga == null)
                {
                    throw new Exception("Vaga não encotrada");
                }
                db.Vagas.Remove(vaga);
                db.SaveChanges();

                return vaga;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //Métodos responsável por buscar uma vaga
        public Vaga GetVaga(int id)
        {
            try
            {
                return db.Vagas.Include(v => v.VagasTecnologias).Include(v => v.Candidatos).Where(t => t.VagaId == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //Métodos responsável por listar todas as vaga
        public List<Vaga> GetVagas()
        {
            try
            {
                return db.Vagas.Include(v => v.VagasTecnologias).Include(v => v.Candidatos).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //Métodos responsável por cadastrar uma vaga
        public Vaga PostVaga(Vaga vaga)
        {
            try
            {
                db.Vagas.Add(vaga);
                db.SaveChanges();

                return vaga;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //Métodos responsável por editar uma vaga
        public Vaga PutVaga(Vaga vaga)
        {
            try
            {
                db.Entry(vaga).State = EntityState.Modified;
                db.SaveChanges();


                //Ao editar uma vaga, sempre são apagados todas as tecnologias relacionadas a vaga, e na sequencia inseridos as novas tecnologias.
               // DeleteVagasTecnologias(vaga);
              //  PostVagasTecnologias(vaga);

                return vaga;
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

        public List<VagasTecnologias> GetVagaTecnologia(int VagaId)
        {
            try
            {
                return db.VagasTecnologias.Include(vt => vt.Tecnologia).Include(vt => vt.Vaga).Where(t => t.VagaId == VagaId).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public void DeleteVagasTecnologias(Vaga vaga)
        {
            try
            {
                var vagaTecnologia = GetVagaTecnologia(vaga.VagaId);

                if (vagaTecnologia != null)
                {
                    foreach (var item in vagaTecnologia)
                    {
                        db.VagasTecnologias.Remove(item);
                    }
                    
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void PostVagasTecnologias(Vaga vaga)
        {
            try
            {

                foreach (var item in vaga.VagasTecnologias.ToList())
                {
                    var vagasTecnologia = new VagasTecnologias();
                    vagasTecnologia.TecnologiaId = item.TecnologiaId;
                    vagasTecnologia.VagaId  = item.VagaId;
                    vagasTecnologia.PesoTecnologia = item.PesoTecnologia;

                    db.VagasTecnologias.Add(vagasTecnologia);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}