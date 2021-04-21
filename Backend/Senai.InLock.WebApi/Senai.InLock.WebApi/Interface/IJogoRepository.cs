using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Interface
{
    interface IJogoRepository
    {
        List<JogoDomain> Listar();

        JogoDomain BuscarPorId(int id);

        List<JogoDomain> BuscarPorIdEstudio(int id);

        void Cadastrar(JogoDomain novoJogo);

        void Deletar(int id);
    }
}
