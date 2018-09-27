using Cestech.Domain.Entities;
using System.Collections.Generic;

namespace Cestech.Domain.Interfaces
{
    public interface IServiceUsuario : IServiceBase<Usuario>
    {
        List<Usuario> List();
        List<Usuario> Pesquisa(string str);
        bool Exists(string NomeUsuario, string Senha);
    }
}
