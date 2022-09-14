using Flunt.Validations;

namespace Eschody.Domain.Models.ValueObjects.UserObject.Assertions;

public static class EmailAssertion
{
    public static Contract CreateEmailAssertionContract(string email)
    {
        return new Contract().IsEmail(email, "User.Email", "O endereço de e-mail inserido é inválido!");
    }
}
