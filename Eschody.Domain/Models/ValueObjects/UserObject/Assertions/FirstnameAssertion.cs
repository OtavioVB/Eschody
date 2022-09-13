using Flunt.Validations;

namespace Eschody.Domain.Models.ValueObjects.UserObject.Assertions;

public static class FirstnameAssertion
{
    public static Contract CreateFirstNameAssertion(string firstName)
    {
        return new Contract()
            .IsNotNullOrEmpty(firstName, "Firstname", "O seu nome não pode ser nulo ou vazio.")
            .IsBetween(firstName.Length, 3, 28, "Firstname", "O seu nome não pode conter menos que três caracteres ou mais que 28 caracteres.");
    }
   
}
