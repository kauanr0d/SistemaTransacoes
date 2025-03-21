using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model;

namespace Backend.Repository.Interface
{
    public interface IPessoaRepository
    {
        Task<Pessoa> Salvar(Pessoa pessoa);
        Task<List<Pessoa>> Listar();
        Task<Pessoa?> BuscarPorId(long id);
        Task DeletarPorId(long id); 
    }
}