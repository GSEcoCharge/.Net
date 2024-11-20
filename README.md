# EcoCharge - .NET

- 98078 - Augusto Barcelos Barros
- 551423 - Izabelly De Oliveira Menezes
- 97707 - Lucas Pinheiro de Melo
- 99578 - Marcos Henrique Garrido da Silva
- 98266 - Mel Maia Rodrigues

## Definição da Arquitetura da API

A solução foi desenvolvida utilizando uma arquitetura monolítica. Essa escolha se baseia em atender a necessidade de criar uma solução integrada e eficiente que abranja as funcionalidades centrais de um sistema de gestão de veículos elétricos, com subdomínios interconectados.

O principal objetivo é resolver problemas do cliente, como planejamento de viagens, carregamento eficiente de veículos e gerenciamento de usuários, de forma simples e direta. A abordagem monolítica facilita a implementação inicial, reduzindo a complexidade e os custos de desenvolvimento e manutenção.

A integração de componentes, como controle de viagens, pontos de recarga e avaliações, em uma única unidade, permite uma comunicação fluida e evita a sobrecarga inicial de configurar e gerenciar múltiplos serviços. Caso o projeto cresça em complexidade, será avaliada uma migração para uma arquitetura de microserviços, garantindo escalabilidade e manutenção otimizada.

## Implementação da API e Justificativa da Arquitetura Escolhida

A implementação da API centraliza toda a lógica de negócios e operações em um único aplicativo. Entre os principais componentes estão:  

- **Usuários e Veículos:** Gerenciamento de perfis, veículos registrados e preferências.  
- **Viagens e Pontos de Parada:** Planejamento de viagens e integração com estações de recarga.  
- **Postos de Recarga:** Localização e avaliações.  
- **Histórico e Reservas:** Registro de recargas e gestão de reservas em pontos de recarga.  

Essa abordagem monolítica é ideal para o contexto atual do projeto, permitindo entregas rápidas e manutenção simplificada, ao mesmo tempo que estabelece uma base sólida para expansões futuras.

## Testes unitários

Focamos nos testes unitários das classes centrais, como **User** e **Vehicle**, para validar os fluxos críticos de nossa aplicação.  

Com especial atenção ao **Customer**, realizamos uma cobertura de 100% em todos os endpoints relacionados, garantindo a confiabilidade do sistema. O uso de testes automáticos permite identificar e corrigir falhas rapidamente, mantendo o alto padrão de qualidade do código.

## IA generativa

Para aprimorar a experiência do usuário, incluímos funcionalidades baseadas em IA generativa:  

1. **Recomendações Personalizadas:** Sugestão de estações de recarga e paradas com base no histórico e preferências do usuário.  
2. **Análise de Sentimento:** Interpretação do tom das mensagens para interações mais empáticas e dinâmicas.

Essas implementações personalizam a interação e tornam o sistema mais intuitivo e centrado no cliente.

---

## Instruções para rodar o código:
Clone o repositório ou obtenha o código-fonte:

Certifique-se de ter o código .NET localmente.
Instale as dependências:

Execute dotnet restore na raiz do projeto para restaurar os pacotes NuGet necessários.
Configurar o ambiente:

Defina as variáveis de ambiente e conexões com banco de dados, se aplicável. Verifique os arquivos de configuração como appsettings.json.
Rodar o projeto:

Execute o comando dotnet run para iniciar a aplicação. Ela estará disponível na porta configurada (por padrão, http://localhost:5000 ou https://localhost:5001).
Acessar a API:

Utilize um cliente HTTP como o Postman ou curl para interagir com os endpoints expostos.
Endpoints disponíveis:
# Documentação da API EcoCharge

Este documento apresenta um resumo dos endpoints disponíveis na API EcoCharge, organizados por seus respectivos controllers.

---

## **BookingController**
Rota Base: `api/booking`

| Método | Endpoint            | Descrição                                       |
|--------|---------------------|-------------------------------------------------|
| GET    | `/{id}`             | Obtém uma reserva pelo seu ID.                 |
| POST   | `/`                 | Cria uma nova reserva.                         |
| PUT    | `/{id}`             | Atualiza uma reserva existente pelo seu ID.    |
| DELETE | `/{id}`             | Remove uma reserva pelo seu ID.                |

---

## **ChargingHistoryController**
Rota Base: `api/chargingHistory`

| Método | Endpoint            | Descrição                                           |
|--------|---------------------|-----------------------------------------------------|
| GET    | `/{id}`             | Obtém o histórico de carregamento pelo ID.         |
| POST   | `/`                 | Cria um novo registro de histórico de carregamento. |
| PUT    | `/{id}`             | Atualiza um registro existente de histórico.        |
| DELETE | `/{id}`             | Remove um registro de histórico de carregamento.    |

---

## **ChargingPointController**
Rota Base: `api/chargingPoint`

| Método | Endpoint            | Descrição                                |
|--------|---------------------|------------------------------------------|
| GET    | `/{id}`             | Obtém um ponto de carregamento pelo ID. |
| POST   | `/`                 | Cria um novo ponto de carregamento.     |
| PUT    | `/{id}`             | Atualiza um ponto de carregamento.      |
| DELETE | `/{id}`             | Remove um ponto de carregamento.        |

---

## **ChargingPostController**
Rota Base: `api/chargingPost`

| Método | Endpoint            | Descrição                              |
|--------|---------------------|----------------------------------------|
| GET    | `/{id}`             | Obtém um posto de carregamento pelo ID. |
| POST   | `/`                 | Cria um novo posto de carregamento.     |
| PUT    | `/{id}`             | Atualiza um posto de carregamento.      |
| DELETE | `/{id}`             | Remove um posto de carregamento.        |

---

## **EvaluationController**
Rota Base: `api/evaluation`

| Método | Endpoint            | Descrição                        |
|--------|---------------------|----------------------------------|
| GET    | `/{id}`             | Obtém uma avaliação pelo ID.    |
| POST   | `/`                 | Cria uma nova avaliação.        |
| PUT    | `/{id}`             | Atualiza uma avaliação existente. |
| DELETE | `/{id}`             | Remove uma avaliação.           |

---

## **StopingPointController**
Rota Base: `api/stopingPoint`

| Método | Endpoint            | Descrição                                  |
|--------|---------------------|--------------------------------------------|
| GET    | `/{id}`             | Obtém um ponto de parada pelo ID.         |
| POST   | `/`                 | Cria um novo ponto de parada.             |
| PUT    | `/{id}`             | Atualiza um ponto de parada existente.    |
| DELETE | `/{id}`             | Remove um ponto de parada.                |

---

## **TravelController**
Rota Base: `api/travel`

| Método | Endpoint            | Descrição                                |
|--------|---------------------|------------------------------------------|
| GET    | `/{id}`             | Obtém uma viagem pelo seu ID.           |
| POST   | `/`                 | Cria uma nova viagem.                   |
| PUT    | `/{id}`             | Atualiza uma viagem existente pelo ID.  |
| DELETE | `/{id}`             | Remove uma viagem pelo ID.              |

---

## **UserController**
Rota Base: `api/user`

| Método  | Endpoint                      | Descrição                                                        |
|---------|-------------------------------|------------------------------------------------------------------|
| GET     | `/{id}`                       | Obtém um usuário pelo seu ID.                                   |
| POST    | `/`                           | Cria um novo usuário.                                           |
| PUT     | `/{id}`                       | Atualiza os dados de um usuário existente pelo ID.              |
| DELETE  | `/{id}`                       | Remove um usuário pelo ID.                                      |
| POST    | `/analyze-sentiment`          | Analisa o sentimento de um texto enviado.                       |
| GET     | `/{id}/recommend-charging`    | Recomenda estações de carregamento com base no histórico do usuário. |

---

## **VehicleController**
Rota Base: `api/vehicle`

| Método | Endpoint            | Descrição                                    |
|--------|---------------------|----------------------------------------------|
| GET    | `/{id}`             | Obtém um veículo pelo seu ID.               |
| POST   | `/`                 | Cria um novo veículo.                       |
| PUT    | `/{id}`             | Atualiza os dados de um veículo pelo ID.    |
| DELETE | `/{id}`             | Remove um veículo pelo ID.                  |

---

