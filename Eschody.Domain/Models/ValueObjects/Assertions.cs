using Flunt.Validations;
using static Eschody.Domain.Models.ValueObjects.Assertions;

namespace Eschody.Domain.Models.ValueObjects;

public static class Assertions
{
    public static class Email
    {
        /// <summary>
        /// Criar contrato de notificação de email
        /// </summary>
        public static Contract Create(string email)
        {
            return new Contract()
                .IsEmail(email, "Email", "Esse email é inválido!");
        }
    }

    public static class Name
    {
        /// <summary>
        /// Criar contrato de notificação de nome completo
        /// </summary>
        public static Contract Create(string name)
        {
            return new Contract()
                .IsNotNullOrEmpty(name, "Nome", "O seu nome não pode ser nulo ou vazio.")
                .IsLowerOrEqualsThan(5, name.Length, "Nome", "O nome tem que conter no mínimo 5 caracteres.")
                .IsGreaterOrEqualsThan(25, name.Length, "Nome", "O nome não pode conter mais que 25 caracteres.")
                .IsTrue(VerifyExistsOnlyLetters(name), "Nome", "O nome deve conter apenas letras como caracteres.");
        }

        private static bool VerifyExistsOnlyLetters(string name)
        {
            var characters = name.ToCharArray();

            foreach (var character in characters)
            {
                if (char.IsLetter(character) is false && char.IsWhiteSpace(character) is false)
                {
                    return false;
                }
            }

            return true;
        }
    }

    public static class Nickname
    {
        /// <summary>
        /// Criar contrato de notificação de nome de usuário
        /// </summary>
        public static Contract Create(string nickname)
        {
            return new Contract()
                .IsNullOrWhiteSpace(nickname, "Nome", "O seu nome não pode ser nulo ou conter espaços em branco.")
                .IsLowerOrEqualsThan(5, nickname.Length, "Nome", "O nome de usuário pode conter no mínimo 5 caracteres.")
                .IsGreaterOrEqualsThan(25, nickname.Length, "Nome", "O nome de usuário pode conter no máximo 25 caracteres.")
                .IsTrue(VerifyExistsOnlyLetters(nickname), "Nome", "O nome deve conter apenas letras como caracteres.");
        }

        private static bool VerifyExistsOnlyLetters(string name)
        {
            var characters = name.ToCharArray();

            foreach (var character in characters)
            {
                if (char.IsLetter(character) is false && char.IsWhiteSpace(character) is false)
                {
                    return false;
                }
            }

            return true;
        }
    }

    public static class PasswordNotEncrypted
    {
        /// <summary>
        /// Criar contrato de notificação de senha não encriptada
        /// </summary>
        public static Contract Create(string passwordNotEncrypted)
        {
            return new Contract()
                .IsNotNullOrEmpty(passwordNotEncrypted, "Senha", "A sua senha não pode ser nula ou vazia.")
                .IsGreaterOrEqualsThan(24, passwordNotEncrypted.Length, "Senha", "Essa senha é grande demais! Você irá acabar esquecendo, escolha uma menor.")
                .IsLowerOrEqualsThan(6, passwordNotEncrypted.Length, "Senha", "A sua senha não pode conter menos que 6 caracteres.")
                .IsTrue(VerifyTextContainsSpecialChars(passwordNotEncrypted), "Senha", "A senha deve conter caracteres especiais.")
                .IsTrue(VerifyTextContainsNumbers(passwordNotEncrypted), "Senha", "A senha deve conter dígitos.")
                .IsTrue(VerifyTextContainsLetter(passwordNotEncrypted), "Senha", "A senha deve conter letras.");
        }

        private static bool VerifyTextContainsSpecialChars(string text)
        {
            foreach (char character in text)
            {
                if (char.IsPunctuation(character) || char.IsSymbol(character) || char.IsWhiteSpace(character))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool VerifyTextContainsNumbers(string text)
        {
            foreach (char character in text)
            {
                if (char.IsNumber(character) || char.IsDigit(character))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool VerifyTextContainsLetter(string text)
        {
            foreach (char character in text)
            {
                if (char.IsLetter(character) || char.IsUpper(character) || char.IsLower(character))
                {
                    return true;
                }
            }

            return false;
        }
    }

    public static class PasswordEncrypted
    {
        /// <summary>
        /// Criar contrato de notificação para senhas encriptadas
        /// </summary>
        public static Contract Create(string passwordEncrypted)
        {
            return new Contract().Matches(passwordEncrypted, "^[A-Za-z0-9]{64}$", "Senha", "Um erro interno do servidor ocorreu e não foi possível realizar a encriptação da sua senha.");
        }
    }
}
