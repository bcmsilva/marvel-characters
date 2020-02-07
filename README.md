# Marvel Characters

Marvel Characters é uma api de catologo de personagens da Marvel.

## Design Patterns Utilizados

Foram utilizados alguns design patterns na contrução deste projeto, a fim de simplicar o desenvolvimento e garantir boas práticas de desenvolvimento.

| Design Pattern      | Justificação |
| --------- | -----|
| CQS (Command Query Separation) | Separar regras consultas das regras de manipulação de dados. Simplifica as regras do sistema, é fácil de utilizar e força trabalhar orientado a casos de usos. |
| Repository |Isola regras de comunicação com base de dados das regras de negócio. Possibilita mudanças de tecnologia de armazenamento de dados de grandes alterações nas outras áreas da aplicação. |
| Notifications |Utilizado para validações em geral e evita que exceptions tenham este fim. Garante uma melhor performance do sistema (Exceptions tendem à ser custosas falando de processamento).  |

Além dos design patterns também foram aplicados conceitos e praticas de clean code.