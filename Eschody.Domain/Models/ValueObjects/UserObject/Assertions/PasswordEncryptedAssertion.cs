using Flunt.Validations;

namespace Eschody.Domain.Models.ValueObjects.UserObject.Assertions;

public static class PasswordEncryptedAssertion
{
    public static Contract CreateAssert(string value)
    {
        return new Contract().Matches(value, "^[A-Za-z0-9]{64}$", "Encriptação de Senha", "Um erro ocorreu com o servidor para encriptação da senha.");
    }
}
