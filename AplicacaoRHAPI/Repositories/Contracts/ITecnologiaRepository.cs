using AplicacaoRHAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacaoRHAPI.Repositories.Contracts
{
    //Interface utilizada pelo modelo tecnologia, definindo quais métodos serão usados.
    public interface ITecnologiaRepository
    {
        List<Tecnologia> GetTecnologias();

        Tecnologia PostTecnologia(Tecnologia tecnologia);

        Tecnologia PutTecnologia(Tecnologia tecnologia);

        Tecnologia GetTecnologia(int id);

        Tecnologia DeleteTecnologia(int id);
    }
}
