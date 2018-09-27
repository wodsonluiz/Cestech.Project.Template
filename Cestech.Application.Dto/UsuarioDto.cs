using System;

namespace Cestech.Application.Dto
{
    public class UsuarioDto
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public DateTime Dt_Nascimento { get; set; }
        public string Cep { get; set; }
        public string Password { get; set; }
    }
}
