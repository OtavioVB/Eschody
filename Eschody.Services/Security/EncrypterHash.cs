using System.Security.Cryptography;

namespace Eschody.Services.Security;

public class EncrypterHash
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
        return "null";
    }


    /// <summary>
    /// Método para verificar uma informação encriptada à um valor não encriptado
    /// </summary>
    /// <param name="valueEncrypted">Valor Encriptado com Hashing</param>
    /// <param name="valueNotEncrypted">Valor Não Encriptado</param>
    public string VerifyInformationEncrypted(string valueEncrypted, string valueNotEncrypted)
    {
        return "Need To Implement";
    }
}
