--DML (DATABASE Manipulation Language)

--Inserir os dados emtodas as tabelas agora
USE HealthClinic_Manha;

--inserindo valores em tipos de usuarios
INSERT INTO Tb_TiposDeUsuario(TituloTipoDeUsuario)
VALUES ('Administrador'), ('Medico'), ('Paciente')

INSERT INTO Tb_Clinica(
/*
-- Inserindo tipos de usuário
INSERT INTO Tb_TiposDeUsuario (TituloTipoDeUsuario)
VALUES ('Paciente');

INSERT INTO Tb_TiposDeUsuario (TituloTipoDeUsuario)
VALUES ('Médico');

-- Inserindo clínicas
INSERT INTO Tb_Clinica (RazaoSocial, NomeFantasia, CNPJ, HorarioAbertura, HorarioFechamento, Endereco)
VALUES ('Clínica ABC', 'ABC Saúde', '12345678901234', '08:00:00', '18:00:00', 'Rua Principal, 123');

-- Inserindo especialidades
INSERT INTO Tb_Especialidades (TituloEspecialidade)
VALUES ('Cardiologia');

INSERT INTO Tb_Especialidades (TituloEspecialidade)
VALUES ('Dermatologia');

-- Inserindo usuários
INSERT INTO Tb_Usuario (IdTipoDeUsuario, Email, Senha)
VALUES (1, 'paciente1@example.com', 'hashed_password');

INSERT INTO Tb_Usuario (IdTipoDeUsuario, Email, Senha)
VALUES (2, 'medico1@example.com', 'hashed_password');

-- Inserindo pacientes
INSERT INTO Tb_Paciente (IdUsuario, Nome, CPF, DataNascimento, RG, Telefone)
VALUES (1, 'João Paciente', '12345678901', '1990-08-15', '987654321', '999999999');

-- Inserindo médicos
INSERT INTO Tb_Medico (IdUsuario, IdEspecialidade, IdClinica, Nome, CRM, CPF)
VALUES (2, 1, 1, 'Dr. Médico', '123456', '98765432101');

-- Inserindo consultas
INSERT INTO Tb_Consulta (IdMedico, IdPaciente, Descricao, DataConsulta)
VALUES (1, 1, 'Consulta de rotina', '2023-08-15');

-- E assim por diante para as outras tabelas...

*/