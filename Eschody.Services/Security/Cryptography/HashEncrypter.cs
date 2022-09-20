using Eschody.Domain.Contracts.Infrascructure.Security.Cryptography;
using System.Security.Cryptography;
using System.Text;

namespace Eschody.Services.Security.Cryptography;

public class HashEncrypter : IHashEncrypter, IDisposable
{
    public HashAlgorithm HashAlgorithm { get; private set; }

    public HashEncrypter()
    {
        HashAlgorithm = SHA256.Create();
    }

    public string Encrypt(string Texto)
    {
        var encodedValue = Encoding.UTF8.GetBytes(Texto);

        var encryptedPassword = HashAlgorithm.ComputeHash(encodedValue);

        var sb = new StringBuilder();

        foreach (var caracter in encryptedPassword)
        {
            sb.Append(caracter.ToString("X2"));
        }

        return sb.ToString();
    }

    public bool VerifyValueWithEncrypter(string encryptedValue, string notEncryptedValue)
    {
        if (encryptedValue == Encrypt(notEncryptedValue)) return true;
        else return false;
    }

    public void Dispose()
    {
        HashAlgorithm.Dispose();
    }
}
