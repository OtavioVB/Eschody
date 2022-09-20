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
            .IsLowerOrEqualsThan(3, username.Length, "Nome de Usuário", "O nome de usuário não pode ter menos que 4 caracteres.")
            .IsGreaterOrEqualsThan(20, username.Length, "Nome de Usuário", "O nome de usuário não pode conter mais que 20 caracteres.");
        }
    }

    public static class FullnameAssertion
    {
        public static Contract CreateContract(string fullname)
        {
            return new Contract()
                .IsNotNullOrEmpty(fullname, "Nome", "Seu nome não pode ser nulo ou vazio")
                .IsLowerOrEqualsThan(3, fullname.Length, "Nome", "Seu nome não pode conter menos que 3 caracteres")
                .IsGreaterOrEqualsThan(30, fullname.Length, "Nome ", "O nome de usuário não pode conter mais que 30 caracteres."); ;
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
                .IsLowerOrEqualsThan(6,pwd.Length, "Senha", "A senha deve conter pelo menos 6 caracteres.")
                .IsGreaterOrEqualsThan(36, pwd.Length, "Senha", "A senha deve conter até 36 caracteres.")
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
