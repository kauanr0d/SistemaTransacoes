using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Backend.Model.Enums;

namespace Backend.Model.DTO
{
    public record TransacaoRequestDTO(string Descricao, double Valor, [property: JsonConverter(typeof(JsonStringEnumConverter))] TipoTransacao Tipo)
{
    public Transacao ConverteParaTransacao()
    {
        var transacao = new Transacao
        {
            Descricao = Descricao,
            Valor = Valor,
            Tipo = Tipo
        };
        return transacao;
    }
}

}