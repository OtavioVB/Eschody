using Flunt.Validations;

namespace Eschody.Domain.Models.ValueObjects.UserObject;

public static class Assertions
{
    public static class UsernameAssertion
    {
        public static Contract CreateContract(string username)
        {
            return new Contract()
            .IsNotNullOrWhiteSpace(username, "Nome de usuário", "O nome de usuário não pode conter espaços vazios.")
            .IsLowerOrEqualsThan(username.Length, 3, "Nome de Usuário", "O nome de usuário não pode ter menos que 4 caracteres.")
            .IsGreaterOrEqualsThan(username.Length, 20, "Nome de Usuário", "O nome de usuário não pode conter mais que 28 caracteres.");
        }
    }

    public static class EmailAssertion
    {
        public static Contract CreateContract(string email)
        {
            return new Contract().IsEmail(email, "User.Email", "O endereço de e-mail inserido é inválido!");
        }
    }

    public static class PasswordNotEncryptedAssertion
    {
        public static Contract CreateContract(string pwd)
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

    public static class PasswordEncryptedAssertion
    {
        public static Contract CreateContract(string value)
        {
            return new Contract().Matches(value, "^[A-Za-z0-9]{64}$", "Encriptação de Senha", "Um erro ocorreu com o servidor para encriptação da senha.");
        }
    }
}
