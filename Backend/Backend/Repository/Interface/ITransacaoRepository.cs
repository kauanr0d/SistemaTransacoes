using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model;

namespace Backend.Repository.Interface
{
    public interface ITransacaoRepository
    {
        Task<Transacao> Salvar(Transacao transacao);
        Task Deletar(long id);

        Task<List<Transacao>> Listar();
        
    }
}