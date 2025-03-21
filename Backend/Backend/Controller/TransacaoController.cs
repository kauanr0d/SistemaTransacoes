using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Model;
using Backend.Model.DTO;
using Backend.Model.DTO.Response;
using Backend.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controller
{
    [Route("/transacoes")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private readonly ITransacaoService _transacaoService;

        public TransacaoController(ITransacaoService service)
        {
            _transacaoService = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<TransacaoResponseDTO>>> Listar()
        {
            var transacoes = await _transacaoService.Listar();
            var transacoesDTO = transacoes.Select(t => new TransacaoResponseDTO(
                t.Descricao, t.Valor, t.Tipo, t.NomePessoa
            )).ToList();
            return Ok(transacoesDTO);
        }

        [HttpPost]
        public async Task<ActionResult<Transacao>> Post([FromBody] Transacao transacao)
        {
            var transacaoAdicionada = await _transacaoService.Salvar(transacao);
            return Ok(transacaoAdicionada);
        }
    }
}
