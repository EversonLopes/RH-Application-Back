using AplicacaoRHAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AplicacaoRHAPI.Repositories.Contracts
{
    //Interface utilizada pelo modelo candidato, definindo quais métodos serão usados.
    public interface ICandidatoRepository 
    {
        List<Candidato> GetCandidatos();

        Candidato PostCandidato(Candidato candidato);

        Candidato PutCandidato(Candidato candidato);

        Candidato GetCandidato(int id);

        Candidato DeleteCandidato(int id);

        void DeleteTecnologiasCandidatos(Candidato candidato);

        void PostTecnologiasCandidatos(Candidato candidato);

        List<TecnologiasCandidatos> GetTecnologiaCandidato(int CandidatoId);
    }
}