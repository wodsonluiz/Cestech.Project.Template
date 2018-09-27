using Cestech.Application.Dto;
using Cestech.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cestech.Api.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [Authorize(Policy = "UsuarioApi")]
    public class UsuarioController : Controller
    {
        private readonly IApplicationServiceUsuario _service;
        public UsuarioController(IApplicationServiceUsuario service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("List")]
        public ServiceResponse<List<UsuarioDto>> List()
        {
            return _service.List();
        }

        [HttpGet]
        [Route("Pesquisa")]
        public ServiceResponse<List<UsuarioDto>> Pesquisa(string str)
        {
            return _service.Pesquisa(str);
        }

        [HttpPost]
        [Route("Insert")]
        public ServiceResponse<bool> Insert([FromBody]UsuarioDto usuario)
        {
            return _service.Insert(usuario);
        }

        [HttpDelete]
        [Route("Delete")]
        public ServiceResponse<bool> Delete(int id)
        {
            return _service.Delete(id);
        }

        [HttpPut]
        [Route("Update")]
        public ServiceResponse<bool> Update([FromBody] UsuarioDto usuario)
        {
            return _service.Update(usuario);
        }
    }
}