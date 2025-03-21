import React from 'react';
import './css/PessoaForm.css'; 

const PessoaForm = ({ nome, setNome, idade, setIdade, handleSubmit }) => {
  
  const handleIdadeChange = (e) => {
    const value = e.target.value;
    if (value >= 1 && value <= 100) {
      setIdade(value); 
    } else {
      setIdade(''); 
    }
  };

  return (
    <form onSubmit={handleSubmit} className="pessoa-form">
      <h2 className="form-title">Formulario de cadastro</h2>
      
      <div className="input-group">
        <label htmlFor="nome" className="label">Nome</label>
        <input
          id="nome"
          type="text"
          placeholder="Digite seu nome"
          value={nome}
          onChange={(e) => setNome(e.target.value)}
          className="input-field"
          required
        />
      </div>

      <div className="input-group">
        <label htmlFor="idade" className="label">Idade</label>
        <input
          id="idade"
          type="number"
          placeholder="Digite sua idade"
          value={idade}
          onChange={handleIdadeChange} // Chamando a função para validar a idade
          className="input-field"
          min="1"
          max="100"
          required
        />
      </div>

      <button
        type="submit"
        className="submit-btn"
      >
        Salvar
      </button>
    </form>
  );
};

export default PessoaForm;
