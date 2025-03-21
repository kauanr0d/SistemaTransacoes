import React, { useState, useEffect } from "react";
import { cadastrarTransacaoPorPessoa, listarPessoas } from "../../services/pessoaService";
import "./css/TransacaoFormulario.css"; 

const TransacaoFormulario = ({ idPessoa }) => {
  const [descricao, setDescricao] = useState("");
  const [valor, setValor] = useState("");
  const [pessoaId, setPessoaId] = useState(idPessoa || "");
  const [tipo, setTipo] = useState("");
  const [erro, setErro] = useState("");
  const [pessoas, setPessoas] = useState([]);

  useEffect(() => {
    const fetchPessoas = async () => {
      try {
        const response = await listarPessoas();
        setPessoas(response);
      } catch (error) {
        console.error("Erro ao carregar pessoas:", error);
      }
    };

    fetchPessoas();
  }, []);

  const handleSubmit = async (e) => {
    e.preventDefault();

    const valorNum = parseFloat(valor);
    if (isNaN(valorNum)) {
      setErro("Por favor, insira um valor válido.");
      return;
    }

    if (!pessoaId) {
      setErro("Por favor, selecione uma pessoa.");
      return;
    }

    const transacaoDTO = {
      descricao,
      valor: valorNum,
      tipo: tipo || (valorNum >= 0 ? "RECEITA" : "DESPESA"),
    };

    try {
      await cadastrarTransacaoPorPessoa(pessoaId, transacaoDTO);
      alert("Transação cadastrada com sucesso!");
      setDescricao("");
      setValor("");
      setTipo("");
      setErro("");
    } catch (error) {
      if (error.response && error.response.status === 403) {
        setErro(error.response.data.message || "Houve um problema na transação.");
      } else {
        console.error("Erro ao cadastrar transação:", error);
        setErro("Erro ao cadastrar transação. Tente novamente.");
      }
    }
  };

  return (
    <div className="form-container">
      <h2>Cadastro de Transação</h2>
      <p>Caso o usuário seja menor de idade, as transações do tipo receita não serão cadastradas!</p>
      {erro && <p className="error-message">{erro}</p>}
      <form onSubmit={handleSubmit} className="transacao-form">
        <div className="form-group">
          <label htmlFor="descricao">Descrição</label>
          <input
            type="text"
            id="descricao"
            placeholder="Descrição"
            value={descricao}
            onChange={(e) => setDescricao(e.target.value)}
            required
          />
        </div>

        <div className="form-group">
          <label htmlFor="valor">Valor</label>
          <input
            type="number"
            id="valor"
            placeholder="Valor"
            value={valor}
            onChange={(e) => setValor(e.target.value)}
            required
          />
        </div>

        {!idPessoa && (
          <div className="form-group">
            <label htmlFor="pessoaId">Pessoa</label>
            <select
              id="pessoaId"
              value={pessoaId}
              onChange={(e) => setPessoaId(e.target.value)}
              required
            >
              <option value="">Selecione a Pessoa</option>
              {pessoas.map((pessoa) => (
                <option key={pessoa.id} value={pessoa.id}>
                  {pessoa.nome}
                </option>
              ))}
            </select>
          </div>
        )}

        <div className="form-group">
          <label htmlFor="tipo">Tipo</label>
          <select
            id="tipo"
            value={tipo}
            onChange={(e) => setTipo(e.target.value)}
            required
          >
            <option value="">Selecione o Tipo</option>
            <option value="RECEITA">RECEITA</option>
            <option value="DESPESA">DESPESA</option>
          </select>
        </div>

        <button type="submit" className="submit-button">
          Salvar
        </button>
      </form>
    </div>
  );
};

export default TransacaoFormulario; 