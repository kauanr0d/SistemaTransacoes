import React from "react";
import PessoaLista from "../components/PessoaLista";
import PessoaFormulario from "../components/PessoaFormulario";

const Pessoa = () => {
  return (
    <div>
      <h1>Pessoas</h1>
      <PessoaFormulario />
      <PessoaLista />
    </div>
  );
};

export default Pessoa;
