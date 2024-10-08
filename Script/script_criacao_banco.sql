USE [Freelando0]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_Candidaturas] (
    [ID_Candidatura]   UNIQUEIDENTIFIER NOT NULL,
    [ID_Profissional]  UNIQUEIDENTIFIER NOT NULL,
    [ID_Servico]       UNIQUEIDENTIFIER NOT NULL,
    [Valor_Proposto]   FLOAT (53)       NOT NULL,
    [DS_Proposta]      NVARCHAR (MAX)   NULL,
    [Duracao_Proposta] NVARCHAR (50)    NOT NULL,
    [Status]           NVARCHAR (50)    NOT NULL
);


GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_Clientes] (
    [ID_Cliente] UNIQUEIDENTIFIER NOT NULL,
    [Nome]       NVARCHAR (MAX)   NULL,
    [Cpf]        NVARCHAR (MAX)   NULL,
    [Email]      NVARCHAR (MAX)   NULL,
    [Telefone]   NVARCHAR (MAX)   NULL
);


GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_Contratos] (
    [ID_Contrato]       UNIQUEIDENTIFIER NOT NULL,
    [ID_Servico]        UNIQUEIDENTIFIER NOT NULL,
    [ID_Profissional]   UNIQUEIDENTIFIER NOT NULL,
    [Valor]             FLOAT (53)       NOT NULL,
    [Data_Inicio]       DATETIME2 (7)    NOT NULL,
    [Data_Encerramento] DATETIME2 (7)    NOT NULL
);


GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_Especialidade_Profissional] (
    [Id_Especialidade] UNIQUEIDENTIFIER NOT NULL,
    [Id_Profissional]  UNIQUEIDENTIFIER NOT NULL
);



GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_Especialidade_Projeto] (
    [Id_Especialidade] UNIQUEIDENTIFIER NOT NULL,
    [Id_Projeto]       UNIQUEIDENTIFIER NOT NULL
);



GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_Especialidades] (
    [ID_Especialidade] UNIQUEIDENTIFIER NOT NULL,
    [DS_Especialidade] NVARCHAR (MAX)   NULL
);



GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_Profissionais] (
    [ID_Profissional] UNIQUEIDENTIFIER NOT NULL,
    [Nome]            NVARCHAR (MAX)   NULL,
    [Cpf]             NVARCHAR (MAX)   NULL,
    [Email]           NVARCHAR (MAX)   NULL,
    [Telefone]        NVARCHAR (MAX)   NULL
);



GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_Projetos] (
    [ID_Projeto] UNIQUEIDENTIFIER NOT NULL,
    [ID_Cliente] UNIQUEIDENTIFIER NOT NULL,
    [Titulo]     NVARCHAR (MAX)   NULL,
    [DS_Projeto] NVARCHAR (MAX)   NULL,
    [Status]     NVARCHAR (50)    NOT NULL
);



GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TB_Servicos] (
    [ID_Servico] UNIQUEIDENTIFIER NOT NULL,
    [ID_Projeto] UNIQUEIDENTIFIER NOT NULL,
    [Titulo]     NVARCHAR (MAX)   NULL,
    [DS_Projeto] NVARCHAR (MAX)   NULL,
    [Status]     NVARCHAR (50)    NOT NULL
);