import api from "./api";

export const listarTotais = async () => {
  try {
    const [pessoas, despesas, receitas, saldo] = await Promise.all([
      api.get("/consultaTotais"), 
      api.get("/consultaTotais/totalDespesas"), 
      api.get("/consultaTotais/totalReceitas"), 
      api.get("/consultaTotais/saldoFinal"), 
    ]);

    return [
      ...pessoas.data, 
      {
        nomePessoa: "Geral", 
        receitaTotal: receitas.data,
        despesaTotal: despesas.data,
        saldo: saldo.data,
      },
    ];
  } catch (error) {
    console.error("Erro ao buscar os totais:", error);
    return []; 
  }
};
