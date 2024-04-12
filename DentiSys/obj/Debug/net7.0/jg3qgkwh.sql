IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Enderecos] (
    [Id] int NOT NULL IDENTITY,
    [CEP] nvarchar(max) NULL,
    [Pais] nvarchar(max) NULL,
    [Estado] nvarchar(max) NULL,
    [Cidade] nvarchar(max) NULL,
    [Rua] nvarchar(max) NULL,
    [Numero] nvarchar(max) NULL,
    CONSTRAINT [PK_Enderecos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Planos] (
    [Id] int NOT NULL IDENTITY,
    [Titulo] nvarchar(max) NOT NULL,
    [TipoDePlano] int NOT NULL,
    [Descricao] nvarchar(max) NOT NULL,
    [Coberturas] nvarchar(max) NOT NULL,
    [DataInicial] datetime2 NOT NULL,
    [DataFinal] datetime2 NOT NULL,
    CONSTRAINT [PK_Planos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Procedimento] (
    [Id] int NOT NULL IDENTITY,
    [Titulo] nvarchar(max) NOT NULL,
    [TipoDeProcedimento] int NOT NULL,
    [Descricao] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Procedimento] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Dentistas] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [SobreNome] nvarchar(max) NOT NULL,
    [Idade] int NOT NULL,
    [CPF] nvarchar(max) NOT NULL,
    [DataDeAniversario] datetime2 NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [NumeroDeTelefone] nvarchar(max) NOT NULL,
    [Especializacao] nvarchar(max) NOT NULL,
    [NumeroDeRegistro] nvarchar(max) NOT NULL,
    [IdEndereco] int NOT NULL,
    [EnderecoId] int NOT NULL,
    CONSTRAINT [PK_Dentistas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Dentistas_Enderecos_EnderecoId] FOREIGN KEY ([EnderecoId]) REFERENCES [Enderecos] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Pacientes] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [SobreNome] nvarchar(max) NULL,
    [Idade] int NULL,
    [CPF] nvarchar(max) NULL,
    [DataDeAniversario] datetime2 NULL,
    [Email] nvarchar(max) NULL,
    [NumeroDeTelefone] nvarchar(max) NULL,
    [IdEndereco] int NULL,
    [EnderecoId] int NULL,
    CONSTRAINT [PK_Pacientes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Pacientes_Enderecos_EnderecoId] FOREIGN KEY ([EnderecoId]) REFERENCES [Enderecos] ([Id])
);
GO

CREATE TABLE [PacientePlanos] (
    [Id] int NOT NULL IDENTITY,
    [IdPlano] int NOT NULL,
    [PlanoId] int NOT NULL,
    [IdPaciente] int NOT NULL,
    [PacienteId] int NOT NULL,
    [PlanoAtivo] bit NOT NULL,
    CONSTRAINT [PK_PacientePlanos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PacientePlanos_Pacientes_PacienteId] FOREIGN KEY ([PacienteId]) REFERENCES [Pacientes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PacientePlanos_Planos_PlanoId] FOREIGN KEY ([PlanoId]) REFERENCES [Planos] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [PacienteProcedimentos] (
    [Id] int NOT NULL IDENTITY,
    [IdPaciente] int NOT NULL,
    [PacienteId] int NOT NULL,
    [IdProcedimento] int NOT NULL,
    [ProcedimentoId] int NOT NULL,
    [DataProcedimento] datetime2 NOT NULL,
    [ProcedimentoRealizado] bit NOT NULL,
    CONSTRAINT [PK_PacienteProcedimentos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PacienteProcedimentos_Pacientes_PacienteId] FOREIGN KEY ([PacienteId]) REFERENCES [Pacientes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PacienteProcedimentos_Procedimento_ProcedimentoId] FOREIGN KEY ([ProcedimentoId]) REFERENCES [Procedimento] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Dentistas_EnderecoId] ON [Dentistas] ([EnderecoId]);
GO

CREATE INDEX [IX_PacientePlanos_PacienteId] ON [PacientePlanos] ([PacienteId]);
GO

CREATE INDEX [IX_PacientePlanos_PlanoId] ON [PacientePlanos] ([PlanoId]);
GO

CREATE INDEX [IX_PacienteProcedimentos_PacienteId] ON [PacienteProcedimentos] ([PacienteId]);
GO

CREATE INDEX [IX_PacienteProcedimentos_ProcedimentoId] ON [PacienteProcedimentos] ([ProcedimentoId]);
GO

CREATE INDEX [IX_Pacientes_EnderecoId] ON [Pacientes] ([EnderecoId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240412134227_First-Migration', N'7.0.18');
GO

COMMIT;
GO

