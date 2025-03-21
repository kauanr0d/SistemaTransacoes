using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kauan.Backend.Service.Exceptions
{
    public class MenorDeIdadeReceitaException : Exception
    {
        public MenorDeIdadeReceitaException(string mensagem) : base(mensagem)
        {
        }
    }
}
