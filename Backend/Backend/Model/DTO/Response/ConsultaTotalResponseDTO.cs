using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Model.DTO
{
    public record ConsultaTotalResponseDTO(string NomePessoa, double ReceitaTotal, double DespesaTotal, double Saldo);
}
