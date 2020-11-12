# Sistema de Imposto de Renda

Este projeto foi criado com Asp.Net Core 3.1 e Angular 10.2.3.

## Escopo

O sistema deve solicitar o valor do Salário Mínimo e então calcular e escrever o IR de cada contribuinte, em ordem crescente de valor de IR e ordem crescente de nome.
Deverá conter também um cadastro de contribuintes.

Regras para cálculo do IR do contribuinte: Para cada contribuinte será concedido um desconto de 5% do valor Salário Mínimo por dependente.

Valores da alíquota para cálculo do imposto são:

Renda Líquida Alíquota

até 2 salários mínimos = isento / acima de 2 até 4 salários mínimos = 7,5% / acima de 4 até 5 salários mínimos = 15% / acima de 5 até 7 salários mínimos = 22,5% / acima de 7 salários mínimos = 27,5%

Renda Líquida = Renda Bruta - Descontos por Dependente;

## Servidor de desenvolvimento

- Dentro do diretório ClienteApp, instale as dependências usando `npm install`.
- Execute `ng serve` para um servidor de desenvolvimento. Navegue até `http://localhost: 4200/`. O aplicativo será recarregado automaticamente se você alterar qualquer um dos arquivos de origem.
- Configurar conexão do banco de dados em `appsettings.Development.json`
- Para funcionar o code first não pode existir nenhuma tabela no banco de dados

## Observações

- Persistido em um banco de dados
- Frontend Angular
- Interface REST
- Framework de ORM
- Estilo monolítico
- Arquitetura baseada em camadas (Closed)
- Modelagem
- Chain of Responsability (Design patterns)
- Testes unitários
- Unit Of Work

## Dúvidas
Caso há alguma dúvida em relação a este repositório, envie para pathydruma@gmail.com.
