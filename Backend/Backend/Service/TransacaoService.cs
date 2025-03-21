using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model;
using Backend.Model.Enums;
using Backend.Repository.Interface;
using Backend.Service.Interfaces;

namespace Backend.Service
{
    public class TransacaoService : ITransacaoService
    {
        private readonly ITransacaoRepository __transacaoRepository;
        public TransacaoService(ITransacaoRepository repository)
        {
            this.__transacaoRepository = repository;
        }

        public Task<Transacao> Salvar(Transacao transacao)
        {
            return __transacaoRepository.Salvar(transacao);
        }

        public Task<List<Transacao>> Listar()
        {
            return __transacaoRepository.Listar();
        }

        public Task Deletar(long id)
        {
            return __transacaoRepository.Deletar(id);
        }



        /// <summary>
        /// Este método calcula as transações do tipo despesa
        /// </summary>
        /// <returns>Retorna o somatório de todas as transações de despesa</returns>
        public async Task<double> CalcularDespesaTotal()
        {
            var transacoes = await __transacaoRepository.Listar();
            var despesaTotal = (from transacao in transacoes
                                where transacao.Tipo.Equals(TipoTransacao.DESPESA)
                                select transacao.Valor
                                ).Sum();
            return despesaTotal;

        }

        /// <summary>
        /// Este método calcula as transações do tipo receita
        /// </summary>
        /// <returns>Retorna o somatório de todas as transações de receita</returns>
        public async Task<double> CalcularReceitaTotal()
        {
            var transacoes = await __transacaoRepository.Listar();
            var receitaTotal = (from transacao in transacoes
                                where transacao.Tipo.Equals(TipoTransacao.RECEITA)
                                select transacao.Valor
                                ).Sum();
            return receitaTotal;

        }

        /// <summary>
        /// Este método calcula o saldo final de todas as transações
        /// </summary>
        /// <returns>Retorna a diferença entre o total de receitas e depesas</returns>
        public async Task<double> CalcularSaldoFinal()
        {
            var totalReceitas = await CalcularReceitaTotal();
            var totalDespesas = await CalcularDespesaTotal();
            return totalReceitas - totalDespesas;
        }

       
    }
}