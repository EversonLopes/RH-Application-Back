using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AplicacaoRHAPI.Database;
using AplicacaoRHAPI.Models;
using AplicacaoRHAPI.Repositories;

namespace AplicacaoRHAPI.Controllers
{
    public class VagasController : ApiController
    {
        //Objeto responsável direta com os métodos que se relacionam com o banco de dados
        VagaRepository vagaRepository = new VagaRepository();

        /// <summary>
        /// Método que retorno todos as vagas
        /// </summary>
        /// <returns>etorna lista de objeto vaga</returns>
        // GET: api/Vagas
        public IEnumerable<Vaga> GetVagas()
        {
            try
            {
                var lista = vagaRepository.GetVagas();

                return lista;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Método que buscar a vaga por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um objeto vaga</returns>
        // GET: api/Vagas/5
        [ResponseType(typeof(Vaga))]
        public IHttpActionResult GetVaga(int id)
        {
            Vaga vaga = vagaRepository.GetVaga(id);

            var vagasTecnologias = vagaRepository.GetVagaTecnologia(id);

            vaga.VagasTecnologias = new List<VagasTecnologias>();

            foreach (var item in vagasTecnologias)
            {
                vaga.VagasTecnologias.Add(item);
            }

            if (vaga == null)
            {
                return NotFound();
            }

            return Ok(vaga);
        }

        /// <summary>
        /// Método que editar a vaga.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vaga"></param>
        /// <returns>Retorna um objeto vaga</returns>
        // PUT: api/Vagas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVaga(int id, Vaga vaga)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vaga.VagaId)
            {
                return BadRequest();
            }

            try
            {
                vagaRepository.PutVaga(vaga);

                return Ok(vaga);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Método para salvar uma vaga
        /// </summary>
        /// <param name="vaga"></param>
        /// <returns>Retorna um objeto vaga</returns>
        // POST: api/Vagas
        [ResponseType(typeof(Vaga))]
        public IHttpActionResult PostVaga(Vaga vaga)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            vagaRepository.PostVaga(vaga);

            return CreatedAtRoute("DefaultApi", new { id = vaga.VagaId }, vaga);
        }

        /// <summary>
        /// Método para excluir uma vaga
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um objeto vaga</returns>
        // DELETE: api/Vagas/5
        [ResponseType(typeof(Vaga))]
        public IHttpActionResult DeleteVaga(int id)
        {
            Vaga vaga = vagaRepository.GetVaga(id);
            if (vaga == null)
            {
                return NotFound();
            }

            vagaRepository.DeleteVaga(vaga.VagaId);

            return Ok(vaga);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                vagaRepository.GetDb().Dispose();
            }
            base.Dispose(disposing);
        }
    }
}