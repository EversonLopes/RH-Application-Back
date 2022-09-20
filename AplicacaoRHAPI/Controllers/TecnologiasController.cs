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
    public class TecnologiasController : ApiController
    {
        //Objeto responsável direta com os métodos que se relacionam com o banco de dados
        TecnologiaRepository tecnologiaRepository = new TecnologiaRepository();

        /// <summary>
        /// Método que retorno todos as tecnologias
        /// </summary>
        /// <returns>etorna lista de objeto tecnologia</returns>
        // GET: api/Tecnologias
        public IHttpActionResult GetTecnologias()
        {
            try
            {
                var lista = tecnologiaRepository.GetTecnologias();

                return Ok(lista);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Método que buscar a tecnologia por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um objeto tecnologia</returns>
        // GET: api/Tecnologias/5
        [ResponseType(typeof(Tecnologia))]
        public IHttpActionResult GetTecnologia(int id)
        {
            Tecnologia tecnologia = tecnologiaRepository.GetTecnologia(id);

            if (tecnologia == null)
            {
                return NotFound();
            }

            return Ok(tecnologia);
        }

        /// <summary>
        /// Método que editar a tecnologia.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tecnologia"></param>
        /// <returns>Retorna um objeto tecnologia</returns>
        // PUT: api/Tecnologias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTecnologia(int id, Tecnologia tecnologia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tecnologia.TecnologiaID)
            {
                return BadRequest();
            }

            try
            {
                tecnologiaRepository.PutTecnologia(tecnologia);
            }
            catch (Exception e)
            {
                return null;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Método para salvar uma tecnologia
        /// </summary>
        /// <param name="tecnologia"></param>
        /// <returns>Retorna um objeto tecnologia</returns>
        // POST: api/Tecnologias
        [ResponseType(typeof(Tecnologia))]
        public IHttpActionResult PostTecnologia(Tecnologia tecnologia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tecnologiaRepository.PostTecnologia(tecnologia);

            return CreatedAtRoute("DefaultApi", new { id = tecnologia.TecnologiaID }, tecnologia);
        }

        /// <summary>
        /// Método para excluir uma tecnologia
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um objeto tecnologia</returns>
        // DELETE: api/Tecnologias/5
        [ResponseType(typeof(Candidato))]
        public IHttpActionResult DeleteTecnologia(int id)
        {
            Tecnologia tecnologia = tecnologiaRepository.GetTecnologia(id);
            if (tecnologia == null)
            {
                return NotFound();
            }

            tecnologiaRepository.DeleteTecnologia(id);

            return Ok(tecnologia);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                tecnologiaRepository.GetDb().Dispose();
            }
            base.Dispose(disposing);
        }
    }
}