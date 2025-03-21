import React, { useEffect, useState } from "react";
import { listarTotais } from "../../services/totaisService";
import './css/ConsultaTotal.css';

const TotalTable = ({ totais }) => (
  <div className="table-container">
    <table className="total-table">
      <thead>
        <tr>
          <th className="table-header">Nome</th>
          <th className="table-header">Receita Total</th>
          <th className="table-header">Despesa Total</th>
          <th className="table-header">Saldo</th>
        </tr>
      </thead>
      <tbody>
        {totais.map((total, index) => (
          <tr key={index} className="table-row">
            <td className="table-cell table-name">{total.nomePessoa}</td>
            <td className="table-cell">R$ {total.receitaTotal.toFixed(2)}</td>
            <td className="table-cell">R$ {total.despesaTotal.toFixed(2)}</td>
            <td className={`table-cell table-saldo ${total.saldo >= 0 ? 'positive' : 'negative'}`}>
              R$ {total.saldo.toFixed(2)}
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  </div>
);

const ConsultaTotal = () => {
  const [totais, setTotais] = useState([]);

  useEffect(() => {
    const fetchTotais = async () => {
      const response = await listarTotais();
      setTotais(response);
    };

    fetchTotais();
  }, []);

  return (
    <div className="container">
      <h2 className="title">Consulta Total</h2>
      {totais.length > 0 ? <TotalTable totais={totais} /> : <p className="no-data">Não há dados disponíveis.</p>}
    </div>
  );
};

export default ConsultaTotal;
