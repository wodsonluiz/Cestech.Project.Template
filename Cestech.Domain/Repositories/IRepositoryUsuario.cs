using Cestech.Domain.Entities;
using System.Collections.Generic;

namespace Cestech.Domain.Repositories
{
    public interface IRepositoryUsuario : IRepositoryBase<Usuario>
    {
        List<Usuario> List();
        List<Usuario> Pesquisa(string str);
        bool Exists(string NomeUsuario, string Senha);
    }
}
