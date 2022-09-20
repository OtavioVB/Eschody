using Eschody.Domain.Contracts.Infrascructure.Security.Cryptography;
using System.Security.Cryptography;

namespace Eschody.Services.Tests.FakeServices;

public class FakeHashEncrypter : IHashEncrypter
{
    public HashAlgorithm HashAlgorithm { get; private set; }

    public void Dispose()
    {
        HashAlgorithm.Dispose();
    }

    public string Encrypt(string Texto)
    {
        return "errorencrypt";
    }
}
