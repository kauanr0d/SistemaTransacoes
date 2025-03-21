import React from 'react';

import { BrowserRouter as Router, Routes, Route, Link } from 'react-router-dom';


import PessoaLista from './components/Pessoas/PessoaLista';
import PessoaFormulario from './components/Pessoas/CadastroPessoa';
import ConsultaTotal from './components/ConsultaTotais/ConsultaTotal';
import TransacaoFormulario from './components/Transacao/TransacaoFormulario';
import TransacaoLista from './components/Transacao/TransacaoLista';

function App() {
  return (
  
    <Router>
      <div>
        <nav>
          <Link to="/pessoas">Lista de Pessoas</Link> | 
          <Link to="/pessoas/cadastro">Cadastrar Pessoa</Link> | 
          <Link to="/pessoas/consulta">Consultar Totais</Link> | 
          <Link to="/transacoes">Lista de Transações</Link> | 
          <Link to="/transacoes/cadastro">Cadastrar Transação</Link>
        </nav>
        {/* Definindo as rotas */}
        <Routes>
          {/* Rotas para Pessoas */}
          <Route path="/pessoas" element={<PessoaLista />} />
          <Route path="/pessoas/cadastro" element={<PessoaFormulario />} />
          <Route path="/pessoas/consulta" element={<ConsultaTotal />} />

          {/* Rotas para Transações */}
          <Route path="/transacoes" element={<TransacaoLista />} />
          <Route path="/transacoes/cadastro" element={<TransacaoFormulario />} />
        </Routes>
      </div>
    </Router>
  );
  
}

export default App;
