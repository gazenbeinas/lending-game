# LendingGame

O sistema foi feito com o uso de .NET Core, Entity Framework, Identity e AutoMapper

- Utilizado: Injeção de dependências, DI, ISP, SRP
- Embora o serviço de domínio esteja com ISP implementado, este ainda é consumido pela camada de Application, sendo injetado por uma interface especifica para o tipo de operação em questão.


Pontos futuros
- Aumentar a cobertura de código com testes unitários
- Melhorar camada Web com mais detalhes e exibições de validações de entidades que o backend processa e com mensagens em caso de erro
- Implementar Log de exceptions (hoje inclusive elas não estão sendo utilizadas), isto pode ser feito criando uma nova camada em Infra para conter o serviço.