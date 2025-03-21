using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model;

namespace Backend.Service.Interfaces
{
    public interface ITransacaoService
    {

        Task<Transacao> Salvar(Transacao transacao);


        Task<List<Transacao>> Listar();

        public Task Deletar(long id);
        Task<double> CalcularReceitaTotal();
        Task<double> CalcularDespesaTotal();
        Task<double> CalcularSaldoFinal();

    }
}