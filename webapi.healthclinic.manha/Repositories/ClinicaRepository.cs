﻿using webapi.healthclinic.manha.Domains;
using webapi.healthclinic.manha.HealtClinicContext;
using webapi.healthclinic.manha.Interfaces;
using webapi.healthclinic.manha.Uteis;

namespace webapi.healthclinic.manha.Repositories
{
    public class ClinicaRepository : IClinica
    {
        private readonly HealthContext ctx;

        public ClinicaRepository()
        {
            ctx= new HealthContext();
        }

        public void Atualizar(Guid id, Clinica clinica)
        {
            throw new NotImplementedException();
        }

        public Clinica BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Clinica clinica)
        {

            clinica.IdClinica = Guid.NewGuid();

            ctx.Clinica!.Add(clinica);

            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Clinica> ListarTodos()
        {
            return ctx.Clinica!.ToList();
        }
    }
}