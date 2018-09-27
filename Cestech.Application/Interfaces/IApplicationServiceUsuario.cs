using Cestech.Application.Dto;
using System.Collections.Generic;

namespace Cestech.Application.Interfaces
{
    public interface IApplicationServiceUsuario
    {
        ServiceResponse<List<UsuarioDto>> List();
        ServiceResponse<List<UsuarioDto>> Pesquisa(string str);
        ServiceResponse<bool> Insert(UsuarioDto usuario);
        ServiceResponse<bool> Delete(int id);
        ServiceResponse<bool> Update(UsuarioDto usuario);
        ServiceResponse<bool> Exists(string NomeUsuario, string Senha);
    }
}
