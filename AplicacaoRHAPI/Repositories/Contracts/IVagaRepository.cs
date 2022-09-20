using AplicacaoRHAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacaoRHAPI.Repositories.Contracts
{
    //Interface utilizada pelo modelo vaga, definindo quais métodos serão usados.
    public interface IVagaRepository
    {
        List<Vaga> GetVagas();

        Vaga PostVaga(Vaga vaga);

        Vaga PutVaga(Vaga vaga);

        Vaga GetVaga(int id);

        Vaga DeleteVaga(int id);

        void DeleteVagasTecnologias(Vaga vaga);

        void PostVagasTecnologias(Vaga vaga);

        List<VagasTecnologias> GetVagaTecnologia(int VagaId);
    }
}
