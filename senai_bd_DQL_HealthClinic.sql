--DQL (Data query language)

SELECT
    P.Nome AS NomePaciente,
    U.IdUsuario AS IdUsuarioPaciente,
    C.Descricao AS DescricaoConsulta,
    C.DataConsulta,
    M.Nome AS NomeMedico,
    E.TituloEspecialidade AS EspecialidadeMedico,
    CL.NomeFantasia AS NomeClinica,
    CASE WHEN PC.Situacao = '0' THEN 'Não compareceu' ELSE PR.Descricao END AS DescricaoProntuario,
    F.Descricao AS FeedbackPaciente
FROM
    Tb_Consulta C
JOIN
    Tb_Paciente P ON C.IdPacinte = P.IdPaciente
JOIN
    Tb_Usuario U ON P.IdUsuario = U.IdUsuario
JOIN
    Tb_Medico M ON C.IdMedico = M.IdMedico
JOIN
    Tb_Especialidades E ON M.IdEspecialidade = E.IdEspecialidade
JOIN
    Tb_Clinica CL ON M.IdClinica = CL.IdClinica
LEFT JOIN
    Tb_Prontuario PR ON C.IdConsulta = PR.IdConsulta
LEFT JOIN
    Tb_Feedback F ON P.IdPaciente = F.IdPaciente AND C.IdConsulta = F.IdConsulta
LEFT JOIN
    Tb_PresencaConsulta PC ON C.IdConsulta = PC.IdConsulta;


/*
select * from Tb_TiposDeUsuario
select * from Tb_Clinica
select * from Tb_Usuario
select * from Tb_Especialidades
select * from Tb_Medico
select * from Tb_Consulta
select * from Tb_PresencaConsulta
select * from Tb_Prontuario
select * from Tb_Feedback
*/
select * from Tb_Feedback