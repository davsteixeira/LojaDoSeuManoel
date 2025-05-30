# 🛍️ Loja do Seu Manoel - API

API responsável por embalar produtos em caixas de forma inteligente. Este projeto simula a lógica de um sistema de logística onde produtos são agrupados em caixas com base em suas dimensões. A autenticação JWT é usada para proteger as rotas.

---

## ✅ Requisitos

- [.NET 8 Core]
- [Docker](https://www.docker.com/)
- Arquivo `.env` com a variável:

```env
SA_PASSWORD=SuaSenha
```


## 🚀 Como rodar o projeto
### Clone o repositório:

```bash
git clone https://seu-repositorio.com/lojadoseumanoel.git
```

### Crie um arquivo .env na raiz do projeto (nível do docker-compose.yml):

```env
SA_PASSWORD=SuaSenha
```
e após isso altere também no arquivo docker-compose.yml

### Ajuste a string de conexão do banco de dados definindo uma variável de ambiente DB_PASSWORD:
```bash
export DB_PASSWORD=SuaSenha
```

### Suba os containers com Docker Compose:

```bash
docker compose up --build
```

A API estará disponível em:
http://localhost:8080

Ou se quiser acessar via swagger: http://localhost:8080/swagger/index.html

## 🔐 Autenticação
A API utiliza JWT. Para obter um token:

### 📥 Login
POST /api/auth/login

Exemplo de corpo da requisição:

```json
{
  "email": "admin@email.com",
  "senha": "admin"
}
```
### ❗ Errata de Segurança
O JWT está exposto no appsettings.json com uma chave secreta visível.

Para facilitar o acesso para testes as credenciais do usuário administrador (admin@seumanoel.com / admin) estão hardcoded no arquivo de configuração e não vêm do banco de dados.

Resposta esperada:
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6..."
}
```
Use o token no header Authorization em todas as requisições autenticadas com o prefixo Bearer na frente:

```makefile
Authorization: Bearer SEU_TOKEN
```

## 📦 Endpoint de Embalagem
POST /embalagem (protegido)
Recebe uma lista de pedidos e responde com a alocação de produtos em caixas.

Exemplo de corpo da requisição:
```json
{
  "pedidos": [
    {
      "pedido_Id": "PED123",
      "produtos": [
        {
          "produto_Id": "PROD1",
          "dimensoes": {
            "altura": 20,
            "largura": 15,
            "comprimento": 10
          }
        }
      ]
    }
  ]
}
```

Exemplo de resposta:
```json
[
  {
    "pedido_Id": "PED123",
    "caixas": [
      {
        "caixa_Id": "Caixa 1",
        "produtos": ["PROD1"]
      }
    ]
  }
]
```

Se algum produto não couber em nenhuma caixa disponível:
```json
{
  "caixa_Id": null,
  "produtos": ["PROD2"],
  "observacao": "Produto não cabe em nenhuma caixa disponível."
}
```
