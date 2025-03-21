import api from "./api";

export const listarPessoas = async () => {
  const response = await api.get("/pessoas");
  return response.data;
};

export const cadastrarPessoa = async (pessoa) => {
  await api.post("/pessoas", pessoa);
};

export const deletarPessoa = async (id) => {
  await api.delete(`/pessoas/${id}`);
};

export const buscarPessoaPorId = async (id) => {
  await api.get(`/pessoas/${id}`);
};

export const cadastrarTransacaoPorPessoa = async (pessoaId, transacao) => {
  return await fetch(`http://localhost:5257/pessoas/${pessoaId}/transacoes`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(transacao),
  });
};

