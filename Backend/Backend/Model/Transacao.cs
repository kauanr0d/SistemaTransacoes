using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Model.DTO;
using Backend.Model.Enums;

namespace Backend.Model
{
    public class Transacao
    {
        private long _id;
        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _descricao;
        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        private double _valor;
        public double Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

        private TipoTransacao _tipo;
        public TipoTransacao Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }


        public Pessoa Pessoa;
        public long PessoaId;

        public string NomePessoa
        {
            get { return Pessoa?.Nome; }
        }

        public Transacao()
        {

        }

        public TransacaoRequestDTO ConverteParaDto()
        {
            return new TransacaoRequestDTO(
                Descricao,
                Valor,
                Tipo );
        }



    }
}