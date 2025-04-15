namespace Application.Interfaces
{
    public interface IEncryptorService
    {
        public string Encrypt(string text);
        public string Decrypt(string base64);
    }
}
