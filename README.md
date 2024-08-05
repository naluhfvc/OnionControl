# OnionControl
OnionControl é um sistema desenvolvido para a Onion S.A., uma empresa líder na indústria de eletrônicos. Este projeto tem como objetivo resolver problemas relacionados ao controle, manutenção das vendas e logística, oferecendo funcionalidades para importar planilhas de pedidos, visualizar gráficos de vendas por região e por produto, e listar vendas com detalhes.

## Funcionalidades
- Importação de Planilhas: Permite importar planilhas de pedidos no formato CSV.
- Visualização de Gráficos: Exibe gráficos interativos de vendas por região e por produto.
- Lista de Vendas: Mostra uma lista detalhada de todas as vendas com informações relevantes.
- Consulta de Localização: Utiliza o BrasilApi para consultar a localização com base no CEP.

## Tecnologias
- Backend: .NET 8, Entity Framework, SQLite, Epplus;
- Frontend: React, Vite, Tailwind, Framer-motion, Axios;

## Como Executar o Projeto
### Backend
1. Certifique-se de que o .NET 8 está instalado.
2. Clone o Repositório
3. Vá para o diretório do back-end
```bash
cd OnionControl/
```
4. Restaure
```bash
dotnet restore
```
5. Entre na pasta Server e inicie a aplicação
```bash
cd Server/
dotnet watch run
```
### FrontEnd
1. Certifique-se de que o Node está instalado.
2. Entre na pasta em que está o front-end e instale as dependencias
```bash
cd OnionControl/onion-client
npm i
```
3. Inicie a aplicação
```bash
npm run dev
```

