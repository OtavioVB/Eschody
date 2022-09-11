using System.Security.Cryptography;

namespace Eschody.Domain.Contracts.Infrascructure.Security.Cryptography;

public interface IHashEncrypter : IDisposable
{
    public HashAlgorithm HashAlgorithm { get; }
    public string Encrypt(string Texto);
}
