--DML (DATABASE Manipulation Language)

--Inserir os dados emtodas as tabelas agora
USE HealthClinic_Manha;

--inserindo valores em tipos de usuarios
INSERT INTO Tb_TiposDeUsuario(TituloTipoDeUsuario)
VALUES ('Administrador'), ('Medico'), ('Paciente')

--inserindo em clinicas
INSERT INTO Tb_Clinica (RazaoSocial, NomeFantasia, CNPJ, HorarioAbertura, HorarioFechamento, Endereco)
VALUES ('Health Clinic', 'Health Clinic', '12345678901234', '08:00:00', '18:00:00', 'Rua Principal, 123');

--inserindo em especialidades
INSERT INTO Tb_Especialidades (TituloEspecialidade)
VALUES ('Cardiologia');

-- Inserindo usuários
INSERT INTO Tb_Usuario (IdTipoDeUsuario, Email, Senha)
VALUES (1, 'adm@gmail.com', '1234'), (2, 'med@gmail.com', '1234'), (3, 'pac@gmail.com', '1234');

-- Inserindo pacientes
INSERT INTO Tb_Paciente (IdUsuario, Nome, CPF, DataNascimento, RG, Telefone)
VALUES (3, 'João', '12345678901', '1990-08-15', '987654321', '11959549521');

-- Inserindo médicos
INSERT INTO Tb_Medico (IdUsuario, IdEspecialidade, IdClinica, Nome, CRM, CPF)
VALUES (2, 1, 1, 'Jose', '123456', '98765432101');

-- Inserindo consultas
INSERT INTO Tb_Consulta (IdMedico, IdPacinte, Descricao, DataConsulta)
VALUES (2, 1, 'Consulta de rotina', '2023-08-15');

--inserindo presenca consulta
INSERT INTO Tb_PresencaConsulta(IdConsulta, Situacao)
VALUES (1, '0')

--inserindo presenca consulta
INSERT INTO Tb_Prontuario(IdConsulta, Descricao)
VALUES (1, 'O paciente foi orientado a repousar, manter-se bem hidratado e a utilizar medicamentos sintomáticos para alívio da febre, dor e congestão nasal, conforme necessário. Foi aconselhado a praticar a etiqueta respiratória e o isolamento domiciliar para evitar a disseminação da doença.')

--inserindo em feedback
INSERT INTO Tb_Feedback(IdPaciente, IdConsulta, Descricao)
VALUES (1, 1, 'Consulta muito boa')

UPDATE Tb_Feedback
SET Descricao = 'Ansioso para a consulta'
WHERE Descricao = 'Consulta muito boa';
