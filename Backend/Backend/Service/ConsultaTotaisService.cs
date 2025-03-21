using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model;
using Backend.Model.DTO;
using Backend.Service.Interfaces;

namespace Backend.Service
{
    public class ConsultaTotaisService : IConsultaTotaisService
    {
        private readonly IPessoaService pessoarService;

        public ConsultaTotaisService(IPessoaService service)
        {
            pessoarService = service;
        }


        /// <summary>
        /// Este método retorna uma lista da consulta total, contendo nome da pessoa, receitas, depesas e seu saldo final
        /// </summary>
        /// <returns>Retorna uma ConsultaTotalResponseDTO </returns>
        public async Task<List<ConsultaTotalResponseDTO>> ConsultaTotais()
        {
            List<Pessoa> pessoas = await pessoarService.Listar();
            var totais = pessoas
                .Select(pessoa => new ConsultaTotalResponseDTO
                (
                    pessoa.Nome,
                    pessoa.CalcularReceitas(),
                    pessoa.CalcularDespesas(),
                    pessoa.Saldo
                )).ToList();

            return totais;
        }

     
    }
}
