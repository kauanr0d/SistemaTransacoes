using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model;
using Backend.Model.DTO;
using Backend.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controller
{
    [Route("/pessoas")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService service)
        {
            this._pessoaService = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pessoa>>> Listar()
        {
            var pessoas = await _pessoaService.Listar();
            return Ok(pessoas);
        }

        [HttpPost]
        public async Task<IActionResult> Salvar([FromBody] Pessoa pessoa)
        {
            var pessoaAdicionada = await _pessoaService.Salvar(pessoa);
            return CreatedAtAction(nameof(Salvar), new { id = pessoaAdicionada.Id }, pessoaAdicionada);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(long id)
        {
            _pessoaService.Deletar(id);
            return NoContent();
        }

        [HttpPost("{id}/transacoes")]
        public async Task<IActionResult> AdicionarTransacao(long id, [FromBody] TransacaoRequestDTO transacao)
        {
            var pessoa = await _pessoaService.BuscarPorId(id);
            if (pessoa != null)
            {
                _pessoaService.AdicionarTransacaoPorPessoa(pessoa, transacao.ConverteParaTransacao());
                return Ok();
            }
            return BadRequest();

        }


    }
}
