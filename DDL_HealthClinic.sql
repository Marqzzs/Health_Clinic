--DDL (DataBase Definition Language)

--Criando o banco de dados
CREATE DATABASE HealthClinic_Manha;
--Usando o banco de dados
USE HealthClinic_Manha;

--criando tabelas

--criando tabela tipos de usuario
CREATE TABLE Tb_TiposDeUsuario
(
	IdTipoDeUsuario INT PRIMARY KEY IDENTITY,
	TituloTipoDeUsuario VARCHAR(50) NOT NULL UNIQUE
)
--criando t clinica
CREATE TABLE Tb_Clinica
(
	IdClinica INT PRIMARY KEY IDENTITY,
	RazaoSocial VARCHAR(50) NOT NULL UNIQUE,
	NomeFantasia VARCHAR(50) NOT NULL UNIQUE,
	CNPJ VARCHAR(14) NOT NULL UNIQUE,
	HorarioAbertura TIME NOT NULL,
	HorarioFechamento TIME NOT NULL,
	Endereco VARCHAR(100) NOT NULL
)
--criando t especialidades
CREATE TABLE Tb_Especialidades
(
	IdEspecialidade INT PRIMARY KEY IDENTITY,
	TituloEspecialidade VARCHAR(30) NOT NULL UNIQUE,
)
--criando t usuario
CREATE TABLE Tb_Usuario
(
	IdUsuario INT PRIMARY KEY IDENTITY,
	IdTipoDeUsuario INT FOREIGN KEY REFERENCES Tb_TiposDeUsuario(IdTipoDeUsuario) NOT NULL UNIQUE,
	Email VARCHAR(60) NOT NULL UNIQUE,
	Senha VARCHAR(100) NOT NULL
)
--criando t paciente
CREATE TABLE Tb_Paciente
(
	IdPaciente INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Tb_Usuario(IdUsuario) NOT NULL UNIQUE,
	Nome VARCHAR(100) NOT NULL,
	CPF VARCHAR(11) NOT NULL UNIQUE,
	DataNascimento DATE NOT NULL,
	RG VARCHAR(10) NOT NULL UNIQUE,
	Telefone VARCHAR(11) NOT NULL
)
--criando t medico
CREATE TABLE Tb_Medico
(
	IdMedico INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES Tb_Usuario(IdUsuario) NOT NULL UNIQUE,
	IdEspecialidade INT FOREIGN KEY REFERENCES Tb_Especialidades(IdEspecialidade) NOT NULL,
	IdClinica INT FOREIGN KEY REFERENCES Tb_Clinica(IdClinica) NOT NULL,
	Nome VARCHAR(100) NOT NULL,
	CRM VARCHAR(10) NOT NULL UNIQUE,
	CPF VARCHAR(11) NOT NULL UNIQUE,
)
-- criando t consulta
CREATE TABLE Tb_Consulta
(
	IdConsulta INT PRIMARY KEY IDENTITY,
	IdMedico INT FOREIGN KEY REFERENCES Tb_Medico(IdMedico) NOT NULL,
	IdPacinte INT FOREIGN KEY REFERENCES Tb_Paciente(IdPaciente) NOT NULL,
	Descricao VARCHAR(500) NOT NULL,
	DataConsulta DATE NOT NULL
)
--criando t presenca consulta
CREATE TABLE Tb_PresencaConsulta
(
	IdPresencaConsulta INT PRIMARY KEY IDENTITY,
	IdConsulta INT FOREIGN KEY REFERENCES Tb_Consulta(IdConsulta) NOT NULL,
	Situacao VARCHAR(1) NOT NULL
)
--criando t prontuario
CREATE TABLE Tb_Prontuario
(
	IdProntuario INT PRIMARY KEY IDENTITY,
	IdConsulta INT FOREIGN KEY REFERENCES Tb_Consulta(IdConsulta) NOT NULL,
	Descricao TEXT NOT NULL
)
--criando t feedback
CREATE TABLE Tb_Feedback
(
	IdComentario INT PRIMARY KEY IDENTITY,
	IdPaciente INT FOREIGN KEY REFERENCES Tb_Paciente(IdPaciente) NOT NULL,
	IdConsulta INT FOREIGN KEY REFERENCES Tb_Consulta(IdConsulta) NOT NULL,
	Descricao VARCHAR(256) NOT NULL
)