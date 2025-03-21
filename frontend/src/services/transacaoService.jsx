import api from "./api";

export const listarTransacoes = async () => {
    try {
        const response = await api.get("/transacoes");
        return response.data;
    } catch (error) {
        console.error("Erro ao listar transações:", error);
        throw error;
    }
};

export const cadastrarTransacao = async (transacao) => {
    try {
        const response = await api.post("/transacoes", transacao);
        return response.data;
    } catch (error) {
        console.error("Erro ao cadastrar transação:", error);
        throw error;
    }
};


