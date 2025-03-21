import useCadastroPessoa from "./useCadastroPessoa";
import PessoaForm from "./PessoaForm";

const CadastroPessoa = () => {
  const { nome, setNome, idade, setIdade, handleSubmit } = useCadastroPessoa();

  return (
    <div className="flex items-center justify-center min-h-screen bg-green-100">
      <div className="bg-green-300 p-8 rounded-lg shadow-md w-80">
        <h2 className="text-2xl font-bold text-green-900 mb-4 text-center">
          Cadastro de Pessoa
        </h2>
        <PessoaForm
          nome={nome}
          setNome={setNome}
          idade={idade}
          setIdade={setIdade}
          handleSubmit={handleSubmit}
        />
      </div>
    </div>
  );
};

export default CadastroPessoa;
