import React, { useEffect, useState } from "react";
import { listarPessoas, deletarPessoa } from "../../services/pessoaService";
import './css/PessoaLista.css';

const PessoaLista = () => {
  const [pessoas, setPessoas] = useState([]);
  const [confirmDelete, setConfirmDelete] = useState(null); 

  useEffect(() => {
    const fetchPessoas = async () => {
      const response = await listarPessoas();
      setPessoas(response);
    };

    fetchPessoas();
  }, []);

  const handleDelete = async (id) => {
    if (confirmDelete === id) {
      try {
        await deletarPessoa(id);
        setPessoas(pessoas.filter(pessoa => pessoa.id !== id));
        setConfirmDelete(null); 
      } catch (error) {
        console.error("Erro ao excluir pessoa:", error);
      }
    } else {
      setConfirmDelete(id); 
    }
  };

  return (
    <div className="pessoa-container">
      <h2 className="title">Lista de Pessoas</h2>
      {pessoas.length > 0 ? (
        <table className="pessoa-table">
          <thead>
            <tr>
              <th>Nome</th>
              <th>Idade</th>
              <th>Ações</th>
            </tr>
          </thead>
          <tbody>
            {pessoas.map((pessoa) => (
              <tr key={pessoa.id}>
                <td>{pessoa.nome}</td>
                <td>{pessoa.idade} anos</td>
                <td>
                  <button 
                    className={`delete-btn ${confirmDelete === pessoa.id ? 'confirm' : ''}`}
                    onClick={() => handleDelete(pessoa.id)}
                    aria-label="Excluir"
                  >
                    {confirmDelete === pessoa.id ? 'Tem certeza? 🗑️' : '🗑️'}
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      ) : (
        <p className="no-data">Nenhuma pessoa encontrada.</p>
      )}
    </div>
  );
};

export default PessoaLista;
