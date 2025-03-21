import React, { useEffect, useState } from "react";
import { listarTransacoes } from "../../services/transacaoService";
import "./css/TransacaoLista.css"; // Importando o CSS

const TransacaoLista = () => {
  const [transacoes, setTransacoes] = useState([]);

  useEffect(() => {
    const fetchTransacoes = async () => {
      try {
        const transacoesData = await listarTransacoes();
        setTransacoes(transacoesData);
      } catch (error) {
        console.error("Erro ao buscar transações:", error);
      }
    };

    fetchTransacoes();
  }, []);

  return (
    <div>
      <h2>Lista de Transações</h2>
      {transacoes.length > 0 ? (
        <table className="transacao-table">
          <thead>
            <tr>
              <th>Descrição</th>
              <th>Valor</th>
              <th>Tipo</th>
              <th>Pessoa</th>
            </tr>
          </thead>
          <tbody>
            {transacoes.map((transacao, index) => (
              <tr key={index}>
                <td>{transacao.descricao}</td>
                <td>R$ {transacao.valor.toLocaleString('pt-BR', { minimumFractionDigits: 2, maximumFractionDigits: 2 })}</td>
                <td>{transacao.tipo}</td>
                <td>{transacao.nomePessoa}</td>
              </tr>
            ))}
          </tbody>
        </table>
      ) : (
        <p className="no-transactions">Nenhuma transação encontrada.</p>
      )}
    </div>
  );
};

export default TransacaoLista;
