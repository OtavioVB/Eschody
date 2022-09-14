using Flunt.Validations;

namespace Eschody.Domain.Models.ValueObjects.UserObject.Assertions;

public static class LastnameAssertion
{
    public static Contract CreateLastnameAssertion(string lastName)
    {
        return new Contract()
            .IsNotNullOrEmpty(lastName, "Firstname", "O seu sobrenome não pode ser nulo ou vazio.")
            .IsBetween(lastName.Length, 3, 28, "Firstname", "O seu sobrenome não pode conter menos que três caracteres ou mais que 28 caracteres.");
    }
}
