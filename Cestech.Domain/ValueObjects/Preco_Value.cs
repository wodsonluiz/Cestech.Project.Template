using Cestech.Shared.ValueObjects;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cestech.Domain.ValueObjects
{
    public class Preco_Value : ValueObject
    {
        public decimal Value { get; private set; }
        public Preco_Value(decimal value)
        {
            Value = value;

            AddNotifications(new Contract()
                .Requires()
                .IsLowerThan(0, value, "Preco_Value.Value", "Por favor, Insira o Preço"));
        }

        private bool Validar()
        {
            return Value >= 0;
        }
    }
}
