using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Kauan.Backend.Controller.Exceptions
{

    
    //Classe para padronizar as respostas de erro

    public class StandardError
    {
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("error")]
        public string Error { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }

        public StandardError(int status, string error, string message, string path)
        {
            Timestamp = DateTime.UtcNow;
            Status = status;
            Error = error;
            Message = message;
            Path = path;
        }
    }
}