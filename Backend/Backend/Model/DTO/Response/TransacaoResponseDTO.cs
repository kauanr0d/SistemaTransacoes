using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Backend.Model.Enums;

namespace Backend.Model.DTO.Response
{
    public record TransacaoResponseDTO(string Descricao, double Valor, [property: JsonConverter(typeof(JsonStringEnumConverter))] TipoTransacao Tipo, string NomePessoa)
    {


    }
}