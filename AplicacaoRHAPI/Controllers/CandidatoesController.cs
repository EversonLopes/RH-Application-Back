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
    public class CandidatoesController : ApiController
    {
        //Objeto responsável direta com os métodos que se relacionam com o banco de dados
        CandidatoRepository candidatoRepository = new CandidatoRepository();

        /// <summary>
        /// Método que retorno todos os candidatos
        /// </summary>
        /// <returns>Retorna lista de objeto candidatos</returns>
        // GET: api/Candidatoes
        [HttpGet]
        public IEnumerable<Candidato> GetCandidatos()
        {
            try
            {
                var lista = candidatoRepository.GetCandidatos();
                
                return lista;
            }
            catch(Exception e )
            {
                return null;
            }
        }


        /// <summary>
        /// Método que buscar o candidato por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um objeto candidato</returns>
        // GET: api/Candidatoes/5
        [ResponseType(typeof(Candidato))]
        public IHttpActionResult GetCandidato(int id)
        {
            Candidato candidato = candidatoRepository.GetCandidato(id);
           
            if (candidato == null)
            {
                return NotFound();
            }

            return Ok(candidato);
        }

        /// <summary>
        /// Método que editar o candidato.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="candidato"></param>
        /// <returns>Retorna um objeto candidato</returns>
        // PUT: api/Candidatoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCandidato(int id, Candidato candidato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != candidato.Id)
            {
                return BadRequest();
            }

            try
            {
                candidatoRepository.PutCandidato(candidato);

                return Ok(candidato);
            }
            catch (Exception e)
            {
                return null;
            }

        }

        /// <summary>
        /// Método para salvar um candidato
        /// </summary>
        /// <param name="candidato"></param>
        /// <returns>Retorna um objeto candidato</returns>
        // POST: api/Candidatoes
        [ResponseType(typeof(Candidato))]
        public IHttpActionResult PostCandidato(Candidato candidato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            candidatoRepository.PostCandidato(candidato);

            return CreatedAtRoute("DefaultApi", new { id = candidato.Id }, candidato);
        }

        /// <summary>
        /// Método para excluir um candidato
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um objeto candidato</returns>
        // DELETE: api/Candidatoes/5
        [ResponseType(typeof(Candidato))]
        public IHttpActionResult DeleteCandidato(int id)
        {
            Candidato candidato = candidatoRepository.GetCandidato(id);
            if (candidato == null)
            {
                return NotFound();
            }

            candidatoRepository.DeleteCandidato(candidato.Id);

            return Ok(candidato);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                candidatoRepository.GetDb().Dispose();
            }
            base.Dispose(disposing);
        }

    }
}