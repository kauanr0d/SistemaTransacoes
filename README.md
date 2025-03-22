# Sistema de Transações

Sistema para cadastro de pessoas e de transações.

---

## Como executar o projeto:

### Frontend

Para iniciar o frontend, entre na pasta raiz do frontend execute o seguinte comando:

```bash
npm run dev
```
O front irá rodar na porta 5173
### Backend

Para iniciar o backend, navegue até a pasta raiz do Backend e execute:

```bash
dotnet run
```
O backend irá rodar na porta 5257

---

### Arquitetura utilizada
- Arquitetura em camadas
    - Model
    - Service
    - Repository
    - Controller

### Diagrama no modelo relacional e banco de dados
![Diagrama Relacional](./diagrama%20relacional.png)

O banco de dados utilizado é o SQLite, um banco de dados local, presente como
"banco.db" no diretório do backend.


## 🛠️ Funcionalidades

- Cadastrar pessoa
- Listar pessoas
- Cadastrar transação associada a uma pessoa
- Excluir pessoa
    - Ao excluir uma pessoa, todas suas transações associadas também são removidas

> **Regra de negócio:**  
> Pessoas **menores de idade** **não podem** cadastrar transações do tipo **receita**.
