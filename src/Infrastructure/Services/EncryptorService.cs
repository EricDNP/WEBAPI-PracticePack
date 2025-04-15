using System.Text;
using Infrastructure.Models;
using Application.Interfaces;
using System.Security.Cryptography;

namespace Infrastructure.Services
{
    public class EncryptorService : IEncryptorService
    {
        private readonly byte[] _key;
        private readonly byte[] _iv;

        public EncryptorService(EncryptorSettings settings)
        {
            _key = Convert.FromBase64String(settings.Key ?? "");
            _iv = Convert.FromBase64String(settings.IV ?? "");
        }

        public string Encrypt(string text)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = _key;
                aes.IV = _iv;

                using (var encryptor = aes.CreateEncryptor())
                {
                    using (var ms = new MemoryStream())
                    {
                        ms.Write(aes.IV, 0, aes.IV.Length);

                        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            using (var sw = new StreamWriter(cs))
                            {
                                sw.Write(text);
                            }
                        }

                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }

        public string Decrypt(string base64)
        {
            using (Aes aes = Aes.Create())
            {
                byte[] encrypted = Convert.FromBase64String(base64);

                aes.Key = _key;
                aes.IV = _iv;

                using (var decryptor = aes.CreateDecryptor())
                {
                    using (var ms = new MemoryStream(encrypted))
                    {
                        using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        {
                            using (var sr = new StreamReader(cs))
                            {
                                return sr.ReadToEnd();
                            }
                        }
                    }
                }
            }
        }
    }


}
