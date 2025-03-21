using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.DTO;

namespace Backend.Service.Interfaces
{
    public interface IConsultaTotaisService
    {
        Task<List<ConsultaTotalResponseDTO>> ConsultaTotais();
    }
}