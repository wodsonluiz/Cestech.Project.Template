using Cestech.Domain.ValueObjects;
using Flunt.Validations;
using System;

namespace Cestech.Domain.Entities
{
    public class Usuario : Base
    {
        #region Value Objects
        private Cep_Value _Cep { get; set; }
        #endregion

        #region Propriedades
        public int IdUsuario { get; protected set; }
        public string Nome { get; protected set; }
        public DateTime Dt_Nascimento { get; protected set; }
        public string Cep
        {
            get { return _Cep.value; }

            protected set
            {
                _Cep = new Cep_Value(value);
            }
        }
        public string Password { get; set; }
        #endregion

        #region Constrututor
        public Usuario(string nome, DateTime dt_nascimento, string cep)
        {
            Nome = nome;
            Dt_Nascimento = dt_nascimento;
            Cep = cep;

            AddValidations();
        }
        #endregion

        #region Metodos
        public void Modify(string nome, DateTime dt_nascimento, string cep)
        {
            Nome = nome;
            Dt_Nascimento = dt_nascimento;
            Cep = cep;

            AddValidations();
        }

        private void AddValidations()
        {
            AddNotifications(new Contract()
               .Requires()
               .HasMinLen(Nome, 3, "Usuario.Nome", "Por favor insira um Usuario com no minimo 3 caracteres")
               .HasMaxLen(Nome, 255, "Usuario.Nome", "Por favor insira até 240 caractes"));

            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(Dt_Nascimento, "Usuario.Dt_Nascimento", "Insira uma data de nascimento"));


        }
        #endregion
    }
}
