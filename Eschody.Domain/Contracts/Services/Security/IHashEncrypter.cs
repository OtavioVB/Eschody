namespace Eschody.Domain.Contracts.Services.Security;

public interface IHashEncrypter
{
    public string Encrypt(string value);
    public bool VerifyInformationEncrypted(string valueEncrypted, string valueNotEncrypted);
}
