using Cestech.Shared.ValueObjects;
using Flunt.Validations;

namespace Cestech.Domain.ValueObjects
{
    public class Cep_Value : ValueObject
    {
        public string value { get; private set; }

        public Cep_Value(string cep)
        {
            value = cep;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty("", cep, "Por favor Insira um cep valido!"));
        }
}
}
