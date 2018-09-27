using Cestech.Domain.Entities;
using Cestech.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cestech.Infrastructure.Repositories
{
    public class RepositoryUsuario : RepositoryBase<Usuario>, IRepositoryUsuario 
    {
        private readonly CestechContext _context;

        public RepositoryUsuario(CestechContext context) : base(context)
        {
            _context = context;
        }

        public List<Usuario> List()
        {
            return (from u in _context.Usuarios
                    select u).ToList();
        }

        public List<Usuario> Pesquisa(string str)
        {
            return (from u in _context.Usuarios
                    where u.Nome.Contains(str)
                    select u).ToList();
        }

        public bool Exists(string NomeUsuario, string Senha)
        {
            bool result = false;
            var usuarioExists = (from u in _context.Usuarios
                           where u.Nome == NomeUsuario && u.Password == Senha
                           select u.Nome).FirstOrDefault();

            if (usuarioExists.ToList().Count > 0)
            {
                result = true;
            }

            return result;
        }
    }
}
