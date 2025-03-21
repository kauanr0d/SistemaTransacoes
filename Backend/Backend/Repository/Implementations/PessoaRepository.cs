using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Model;
using Backend.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository.Implementations
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly AppDBContext appDBContext;

        public PessoaRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }


        /// <summary>
        /// Este método busca um usuário no banco com base me seu ID
        /// </summary>
        /// <param name="id"> id </param>
        /// <returns>Retorna uma pessoa ou null caso não exista no banco</returns>
        public Task<Pessoa?> BuscarPorId(long id)
        {
            return appDBContext.Pessoas
                                .Include(p => p.Transacoes)
                               .FirstOrDefaultAsync(p => p.Id == id);
        }

        /// <summary>
        /// Este método remove uma pessoa do banco com base no seu ID
        /// </summary>
        /// <param name="id"> id </param>
        public async Task DeletarPorId(long id)
        {
            var pessoa = appDBContext.Pessoas.Find(id);
            if (pessoa is not null)
            {
                appDBContext.Pessoas.Remove(pessoa);
                await appDBContext.SaveChangesAsync();
            }

        }

        /// <summary>
        /// Este método busca todos as pessoas registradas no banco de dados
        /// </summary>
        /// <returns>Retorna uma List de Pessoa</returns>
        public Task<List<Pessoa>> Listar()
        {
            return appDBContext.Pessoas
                                .Include(p => p.Transacoes)
                                .ToListAsync();
        }

        /// <summary>
        /// Este método salva uma pessoa no banco 
        /// </summary>
        /// <param name="pessoa"> pessoa </param>
        /// <returns>Retorna uma pessoa </returns>
        public async Task<Pessoa> Salvar(Pessoa pessoa)
        {
            var pessoaAdicionada = await appDBContext.Pessoas.AddAsync(pessoa);
            await appDBContext.SaveChangesAsync();
            return pessoaAdicionada.Entity;
        }
    }
}