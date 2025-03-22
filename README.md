# Sistema de Transações

Sistema para cadastro de pessoas e de transações.

---

## Como executar o projeto

### Frontend

Para iniciar o frontend, entre na pasta raiz do frontend execute o seguinte comando:

```bash
npm run dev
```

### Backend

Para iniciar o backend, navegue até a pasta raiz do Backend e execute:

```bash
dotnet run
```

---

### Arquitetura utilizada
- Arquitetura em camadas
    - Model
    - Service
    - Repository
    - Controller

### Diagrama no modelo relacional
![Diagrama Relacional](./diagrama_relacional.png)




## 🛠️ Funcionalidades

- Cadastrar pessoa
- Cadastrar transação associada a uma pessoa
- Excluir pessoa

> **Regra de negócio:**  
> Pessoas **menores de idade** **não podem** cadastrar transações do tipo **receita**.
