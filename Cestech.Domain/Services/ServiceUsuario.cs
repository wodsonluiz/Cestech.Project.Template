using Cestech.Domain.Entities;
using Cestech.Domain.Interfaces;
using Cestech.Domain.Repositories;
using System.Collections.Generic;

namespace Cestech.Domain.Services
{
    public class ServiceUsuario : ServiceBase<Usuario>, IServiceUsuario
    {
        private readonly IRepositoryUsuario _repository;

        public ServiceUsuario(IRepositoryUsuario repository) : base(repository)
        {
            _repository = repository;
        }

        public List<Usuario> List()
        {
            return _repository.List();
        }

        public List<Usuario> Pesquisa(string str)
        {
            return _repository.Pesquisa(str);
        }

        public override bool Insert(Usuario usuario)
        {
            return _repository.Insert(usuario);
        }

        public override bool Delete(int idUduario)
        {
            return _repository.Delete(idUduario);
        }

        public override bool Update(Usuario usuario)
        {
            return _repository.Update(usuario);
        }

        public bool Exists(string NomeUsuario, string Senha)
        {
            return _repository.Exists(NomeUsuario, Senha);
        }
    }
}
