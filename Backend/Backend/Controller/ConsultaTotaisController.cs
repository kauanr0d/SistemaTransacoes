using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.DTO;
using Backend.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Backend.Controller
{
    [Route("/consultaTotais")]
    [ApiController]
    public class ConsultaTotaisController : ControllerBase
    {
        private readonly IConsultaTotaisService _service;
        private readonly IPessoaService _pessoaService;
        private readonly ITransacaoService _transacaoService;
        public ConsultaTotaisController(IConsultaTotaisService service, IPessoaService pessoaService, ITransacaoService transacaoService)
        {
            this._service = service;
            this._pessoaService = pessoaService;
            this._transacaoService = transacaoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ConsultaTotalResponseDTO>>> consultaTotais()
        {
            var consultaTotal = await _service.ConsultaTotais();
            return Ok(consultaTotal);
        }


        [HttpGet("totalDespesas")]
        public async Task<ActionResult<double>> TotalDespesas()
        {
            var totalDespesas = await _transacaoService.CalcularDespesaTotal();
            return Ok(totalDespesas);

        }

        [HttpGet("totalReceitas")]
        public async Task<ActionResult<double>> TotalReceitas()
        {
            var totalReceitas = await _transacaoService.CalcularReceitaTotal();
            return Ok(totalReceitas);

        }

        [HttpGet("saldoFinal")]
        public async Task<ActionResult<double>> SaldoFinal()
        {
            var saldoFinal = await _transacaoService.CalcularSaldoFinal();
            return Ok(saldoFinal);
        }

    }
}