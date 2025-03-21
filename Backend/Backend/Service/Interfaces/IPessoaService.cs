using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model;

namespace Backend.Service.Interfaces
{
    public interface IPessoaService
    {
        Task<List<Pessoa>> Listar();
        Task<Pessoa> Salvar(Pessoa pessoa);
        Task Deletar(long id);
        Task<Pessoa?> BuscarPorId(long id);
        void AdicionarTransacaoPorPessoa(Pessoa pessoa, Transacao transacao);


    }
}