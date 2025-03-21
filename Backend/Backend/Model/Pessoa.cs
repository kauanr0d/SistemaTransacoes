using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.Enums;

namespace Backend.Model
{
    public class Pessoa
    {
        private long _id;
        public long Id
        {
            get { return _id; }
        }

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        private int _idade;
        public int Idade
        {
            get { return _idade; }
            set { _idade = value; }
        }

        public double Saldo
        {
            get { return CalcularReceitas() - CalcularDespesas(); }
        }

        private List<Transacao> _transacoes = new List<Transacao>();
        public List<Transacao> Transacoes
        {
            get { return _transacoes; }
        }

        public Pessoa()
        {

        }

        /// <summary>
        /// Este método verifica se a pessoa é menor de idade.
        /// </summary>
        /// <returns>Retorna true se for menor que 18 anos; retornal false se for maior que 18 anos</returns>
        public bool MenorDeIdade()
        {
            return _idade < 18;
        }

        /// <summary>
        /// Este método calcula todas as transações do tipo receita de uma pessoa.
        /// </summary>
        /// <returns>Retorna o somatório do valor de receitas do usuário.</returns>
        public double CalcularReceitas()
        {
            var receita = (from Transacao in Transacoes
                           where Transacao.Tipo.Equals(TipoTransacao.RECEITA)
                           select Transacao.Valor).Sum();

            return receita;
        }

        /// <summary>
        /// Este método calcula todas as transações do tipo despesa de uma pessoa.
        /// </summary>
        /// <returns>Retorna o somatório do valor de despesas do usuário.</returns>
        public double CalcularDespesas()
        {
            var despesas = (from Transacao in Transacoes
                            where Transacao.Tipo.Equals(TipoTransacao.DESPESA)
                            select Transacao.Valor).Sum();


            return despesas;
        }




    }


}
