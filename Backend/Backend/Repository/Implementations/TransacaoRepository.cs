using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Model;
using Backend.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.Implementations
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly AppDBContext appDBContext;

        public TransacaoRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }

        /// <summary>
        /// Este método exclui uma transação no banco com base em seu ID
        /// </summary>
        /// <param name="id"> id </param>
        public async Task Deletar(long id)
        {
            var transacao = appDBContext.Transacoes.Find(id);
            if (transacao is not null)
            {
                appDBContext.Transacoes.Remove(transacao);
                await appDBContext.SaveChangesAsync();
            }


        }



        /// <summary>
        /// Este método salva uma transação no banco
        /// </summary>
        /// <param name="transacao"> transacao</param>
        /// <returns>Retorna uma transacao</returns>
        public async Task<Transacao> Salvar(Transacao transacao)
        {
            appDBContext.Transacoes.Add(transacao);
            await appDBContext.SaveChangesAsync();
            return transacao;
        }



        /// <summary>
        /// Este método lista todas as transacoes registradas no banco de dados
        /// </summary>
        /// <returns>Retorna uma List de Transacao</returns>
        public Task<List<Transacao>> Listar()
        {
            var transacoes = appDBContext.Transacoes
                                          .Include(t => t.Pessoa)
                                          .ToListAsync();
            return transacoes;
        }




    }
}