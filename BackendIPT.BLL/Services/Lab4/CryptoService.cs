using System.Security.Cryptography;
using BackendIPT.DAL.Entities;
using BackendIPT.DAL.Persistance;

namespace BackendIPT.BLL.Services.Lab4;

public class CryptoService : ICryptoService
{
    public async Task<RSAKey> GenerateKeys(int keySize)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(keySize))
        {
            try
            {
                string publicKey = rsa.ToXmlString(false);
                string privateKey = rsa.ToXmlString(true);

                await using (var context = new IPTDBContext())
                {
                    var keys = context.RSAKeys.FirstOrDefault();
                    if (keys == null)
                    {
                        keys = new RSAKey();
                        context.RSAKeys.Add(keys);
                    }

                    keys.PublicKey = publicKey;
                    keys.PrivateKey = privateKey;

                    await context.SaveChangesAsync();
                    return keys;
                }
            }
            finally
            {
                rsa.PersistKeyInCsp = false;
            }
        }
    }

    public async Task<RSAKey> GetKeys()
    {
        using (var context = new IPTDBContext())
        {
            var keys = context.RSAKeys.FirstOrDefault();
            if (keys != null)
            {
                return keys;
            }
            else
            {
                throw new InvalidOperationException("Keys not found in the database.");
            }
        }
    }
    
    public async Task<byte[]> EncryptFile(byte[] fileData)
    {
        var publicKey = (await GetKeys()).PublicKey;

        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            rsa.FromXmlString(publicKey);

            using (MemoryStream inputStream = new MemoryStream(fileData))
            using (MemoryStream outputStream = new MemoryStream())
            {
                int bufferSize = 4096; // You can adjust the buffer size as needed
                byte[] buffer = new byte[bufferSize];
                int bytesRead;

                while ((bytesRead = inputStream.Read(buffer, 0, bufferSize)) > 0)
                {
                    byte[] encryptedData = rsa.Encrypt(buffer, false);
                    outputStream.Write(encryptedData, 0, encryptedData.Length);
                }

                return outputStream.ToArray();
            }
        }
    }

    static byte[] Decrypt(string privateKey, byte[] encryptedMessage)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            rsa.FromXmlString(privateKey);
            byte[] decryptedBytes = rsa.Decrypt(encryptedMessage, false);
            return decryptedBytes;
        }
    }
}