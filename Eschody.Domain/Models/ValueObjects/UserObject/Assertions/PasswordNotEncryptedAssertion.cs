using Flunt.Validations;

namespace Eschody.Domain.Models.ValueObjects.UserObject.Assertions;

public static class PasswordNotEncryptedAssertion
{
    public static Contract CreateAssert(string pwd)
    {
        return new Contract()
            .IsLowerOrEqualsThan(pwd.Length, 6, "Senha", "A senha deve conter pelo menos 6 caracteres.")
            .IsGreaterOrEqualsThan(pwd.Length, 36, "Senha", "A senha deve conter até 36 caracteres.")
            .IsNotNullOrEmpty(pwd, "Senha", "A senha não pode ser nula ou vazia.");
    }

    private static int VerifyPasswordLevel(string pwd)
    {
        var characters = pwd.ToCharArray();

        int pwdLevel = 0;

        foreach (var character in characters)
        {
            if (char.IsLetter(character) && char.IsUpper(character)) { pwdLevel++; }
            if (char.IsLetter(character) && char.IsLower(character)) { pwdLevel++; }
            if (char.IsDigit(character)) { pwdLevel++; }
            if (char.IsSymbol(character) || char.IsPunctuation(character) || char.IsWhiteSpace(character)) { pwdLevel++; }
        }

        return pwdLevel;
    }
}