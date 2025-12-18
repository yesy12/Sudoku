# 🧩 Sudoku Project - C# & .NET

Este é um projeto de estudo focado no desenvolvimento da lógica do jogo Sudoku, utilizando **C#** e práticas de **Test-Driven Development (TDD)** com o framework **NUnit**. O objetivo principal é exercitar a lógica de programação e a organização de estruturas de dados complexas.

## 🚀 Funcionalidades Atuais

- **NodeCell:** Estrutura base da célula com validação rigorosa (aceita apenas valores entre 1 e 9).
- **Validação de Regras:** O sistema já realiza a verificação completa de integridade:
  - Verificação por Linhas.
  - Verificação por Colunas.
  - Verificação por Grupos 3x3.
- **Estrutura de Tabuleiro (Board):** Gerenciamento centralizado das células e suas relações.
- **Testes Automatizados:** Cobertura de testes para garantir que as regras do Sudoku e os limites das células sejam respeitados.

## 🛠️ Tecnologias Utilizadas

- **Linguagem:** C#
- **Plataforma:** .NET
- **Testes:** NUnit (incluindo testes de caso para validação de erros e limites).

## 📂 Estrutura do Código

- `NodeCell.cs`: Define a unidade básica do tabuleiro e garante que nenhum valor inválido seja inserido.
- `Board.cs`: Gerencia a grade 9x9 e distribui as células entre linhas, colunas e grupos.
- `MultiStruct.cs`: Classe abstrata que serve de base para as estruturas de Linhas, Colunas e Grupos.
- `Test/`: Pasta contendo todos os testes unitários para validar a lógica do motor do jogo.

## 🚧 Próximos Passos

- [ ] Implementar algoritmo de **Backtracking** para gerar tabuleiros aleatórios.
- [ ] Criar lógica para remoção de células baseada em níveis de dificuldade.
- [ ] Desenvolver interface visual (Console ou UI).

## ⚙️ Como rodar os testes

Para executar os testes automatizados e validar o motor do jogo:

```bash
dotnet test
