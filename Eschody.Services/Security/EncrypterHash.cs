using Eschody.Domain.Contracts.Services.Security;
using System.Security.Cryptography;
using System.Text;

namespace Eschody.Services.Security;

public class EncrypterHash : IHashEncrypter
{
    /// <summary>
    /// Algoritmo de Hash utilizado
    /// </summary>
    private readonly HashAlgorithm hashAlgorithm = SHA256.Create();


    /// <summary>
    /// Método para encriptar alguma informação
    /// </summary>
    /// <param name="value">Valor a ser encriptado</param>
    /// <returns></returns>
    public string Encrypt(string value)
    {
        var encodedValue = Encoding.UTF8.GetBytes(value);
        var encryptedPassword = hashAlgorithm.ComputeHash(encodedValue);
        var sb = new StringBuilder();
        foreach (var caracter in encryptedPassword) sb.Append(caracter.ToString("X2"));
        return sb.ToString();
    }


    /// <summary>
    /// Método para verificar uma informação encriptada à um valor não encriptado
    /// </summary>
    /// <param name="valueEncrypted">Valor Encriptado com Hashing</param>
    /// <param name="valueNotEncrypted">Valor Não Encriptado</param>
    public bool VerifyInformationEncrypted(string valueEncrypted, string valueNotEncrypted)
    {
        if (valueEncrypted == Encrypt(valueNotEncrypted))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
