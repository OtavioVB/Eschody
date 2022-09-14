using Flunt.Validations;

namespace Eschody.Domain.Models.ValueObjects.UserObject.Assertions;

public static class UsernameAssertion
{
    public static Contract CreateAssert(string username)
    {
        return new Contract()
            .IsNotNullOrWhiteSpace(username, "Nome de usuário", "O nome de usuário não pode conter espaços vazios.")
            .IsLowerOrEqualsThan(username.Length,3, "Nome de Usuário", "O nome de usuário não pode ter menos que 4 caracteres.")
            .IsGreaterOrEqualsThan(username.Length, 20, "Nome de Usuário", "O nome de usuário não pode conter mais que 28 caracteres.");
    }
}
