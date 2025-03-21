import React from "react";
import TransacaoLista from "../components/TransacaoLista";
import TransacaoFormulario from "../components/TransacaoFormulario";

const Transacao = () => {
  return (
    <div>
      <h1>Transações</h1>
      <TransacaoFormulario />
      <TransacaoLista />
    </div>
  );
};

export default Transacao;
