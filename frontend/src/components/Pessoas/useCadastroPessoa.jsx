import { useState } from "react";
import { cadastrarPessoa } from "../../services/pessoaService";


const useCadastroPessoa = () => {
  const [nome, setNome] = useState("");
  const [idade, setIdade] = useState("");

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      await cadastrarPessoa({ nome, idade });
      alert("Pessoa cadastrada com sucesso!");
      setNome("");
      setIdade("");
    } catch (error) {
      console.error("Erro ao cadastrar pessoa:", error);
    }
  };

  return { nome, setNome, idade, setIdade, handleSubmit };
};

export default useCadastroPessoa;
