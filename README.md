# BLContainerManager

Sistema web desenvolvido em ASP.NET Core MVC para gerenciamento de BLs (Bill of Lading) e seus respectivos Containers.

## 📦 Funcionalidades

- Cadastro, edição, visualização e exclusão de BLs
- Cadastro de Containers vinculados a BLs
- Relatório agrupado por BL com containers associados
- Interface moderna com Bootstrap e layout responsivo
- Navegação fluida entre páginas com rotas personalizadas

## 🧠 Tecnologias Utilizadas

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server (via AppDbContext)
- Bootstrap 5
- C#

## 🖥️ Estrutura do Projeto

- `Models/` → Classes BL e Container com validações
- `Controllers/` → Lógica de CRUD e relatório
- `Views/` → Páginas estilizadas para cada funcionalidade
- `Data/` → Contexto de banco de dados (AppDbContext)

## 📊 Relatórios

A página de relatório exibe os dados agrupados por BL, mostrando os containers vinculados a cada um.

## Video 

![Teste Funcioanndo](./TP02_CBTSWE02.gif)

## 👨‍💻 Desenvolvedores

- Pedro Xavier Oliveira — CB3027376  
- Leandro Felix Nunes — CB3026159
