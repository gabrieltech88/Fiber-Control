# 🚀 FiberControl

**FiberControl** é um **software web** que facilita o processo de **limpeza de CTOs (Caixas de Terminação Óptica)** em OLTs **Huawei**, de forma **interativa, rápida e eficiente**.  
Ele conecta-se diretamente à OLT via SSH, executa comandos de limpeza e fornece feedback dinâmico através de uma interface leve baseada em web.

---

## 🧠 Principais recursos

- 🔌 Conexão automática via SSH com a OLT Huawei  
- 🧹 Execução de comandos para limpeza de CTOs  
- 🔎 Visualização do status dos clientes afetados  
- 📦 Banco de dados com gerenciamento de OLTs  
- 🌐 Interface web dinâmica com frontend puro (HTML, CSS e JS)

---

## ⚙️ Tecnologias utilizadas

### Backend (.NET C#)
- ASP.NET Core
- [SSH.NET](https://github.com/sshnet/SSH.NET) — conexão via SSH
- Pomelo.EntityFrameworkCore.MySql — ORM para MySQL
- AutoMapper — mapeamento entre DTOs e entidades
- Padrões de projeto: **DAL**, **DTO**, **Repository**

### Frontend
- HTML5 + CSS3
- JavaScript (Vanilla)

### Banco de Dados
- MySQL

---

## 🔧 Rotas da API

| Método | Rota | Descrição |
|--------|------|-----------|
| `GET` | `/app` | Verifica se a API está online |
| `GET` | `/oltDal` | Lista todas as OLTs registradas |
| `POST/PUT/DELETE` | `/oltDal` | CRUD de OLTs no banco de dados |
| `POST` | `/olt/clear` | Rota principal para conectar à OLT e executar a limpeza |
| `GET` | `/oltDal/{nome}` | Busca uma OLT específica pelo nome, para obter porta GPON |
| `GET` | `/olt/status` | Verifica o status do cliente durante/antes/depois da limpeza |

---

## 🔐 Configuração da Connection String com Secrets

A **string de conexão com o banco de dados** é armazenada usando o sistema de **User Secrets** do .NET, garantindo segurança durante o desenvolvimento.

### Como configurar a `ConnectionString` localmente:

1. Navegue até a pasta do projeto no terminal:
   ```bash
   cd fibercontrol
2. Inicialize os secrets do projeto
  ```bash
  dotnet user-secrets init
  ```
3. Defina a ConnectionString com suas credenciais do MySQL
   ```bash
   dotnet user-secrets set "ConnectionString" "server=localhost;user=root;password=suasenha;database=fiberdb"

---

## 💻 Como rodar o projeto localmente
### Requisitos:
- .NET SDK instalado
- MySQL instalado e configurado
- Editor de código (Visual Studio / VS Code)
  
  ```bash
  git clone https://github.com/seu-usuario/fibercontrol.git
  cd fibercontrol
  # Configure a string de conexão com o comando acima
  # Execute o projeto
  dotnet run
A API será iniciada normalmente em https://localhost:7155
Abra o arquivo index.html no navegador ou utilize um servidor como live-server

### 📄 Licença
Este projeto está licenciado sob a MIT License.
Consulte o arquivo LICENSE para mais detalhes.

###📬 Contato
Desenvolvido por [Gabriel Ramos]
📧 Contato: [gabrieltech209@gmail.com]




