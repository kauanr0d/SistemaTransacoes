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

# Documentação da API

Ao rodar o backend, a documentação da API poderá ser acessada na rota a seguir:

http://localhost:5257/index.html






---

### Arquitetura utilizada
- Arquitetura em camadas
    - Model
    - Service
    - Repository
    - Controller

### Diagrama no modelo relacional e banco de dados
![Diagrama Relacional](./diagrama%20relacional.png)

O banco de dados utilizado é o SQLite, está presente como
"banco.db" no diretório do backend.


## 🛠️ Funcionalidades

- Cadastrar pessoa
- Listar pessoas
- Cadastrar transação associada a uma pessoa
- Listar transações
- Listar pessoas com suas respectivas receitas, despesas e saldo final
- Listar a receita, despesa e saldo final de todas as transações
- Excluir pessoa
    - Ao excluir uma pessoa, todas suas transações associadas também são removidas

> **Regra de negócio:**  
> Pessoas **menores de idade** **não podem** cadastrar transações do tipo **receita**.



