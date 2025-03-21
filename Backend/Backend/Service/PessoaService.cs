using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model;
using Backend.Model.Enums;
using Backend.Repository.Interface;
using Backend.Service.Interfaces;
using Kauan.Backend.Service.Exceptions;

namespace Backend.Service
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly ITransacaoService _transacaoService;

        public PessoaService(IPessoaRepository pessoaRepository, ITransacaoService transacaoService)
        {
            _pessoaRepository = pessoaRepository;
            _transacaoService = transacaoService;
        }

        public Task<List<Pessoa>> Listar()
        {
            return _pessoaRepository.Listar();
        }

        public Task<Pessoa> Salvar(Pessoa pessoa)
        {
            return _pessoaRepository.Salvar(pessoa);
        }

        public Task Deletar(long id)
        {
            return _pessoaRepository.DeletarPorId(id);
        }

        public Task<Pessoa?> BuscarPorId(long id)
        {
            return _pessoaRepository.BuscarPorId(id);
        }




        /// <summary>
        /// Este método salva uma transação e a associa com uma pessoa
        /// </summary>
        /// <param name="pessoa"> pessoa  </param>
        /// <param name="transacao"> transação </param>
        public void AdicionarTransacaoPorPessoa(Pessoa pessoa, Transacao transacao)
        {
            if (pessoa.MenorDeIdade() && transacao.Tipo.Equals(TipoTransacao.RECEITA))
            {
                throw new MenorDeIdadeReceitaException("Menores de idade podem cadastrar apenas despesas!");
            }
            else
            {
                transacao.Pessoa = pessoa;

                _transacaoService.Salvar(transacao);

                _pessoaRepository.Salvar(pessoa);
            }
        }




    }
}