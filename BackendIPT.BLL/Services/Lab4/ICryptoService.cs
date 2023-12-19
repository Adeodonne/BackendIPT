using BackendIPT.DAL.Entities;

namespace BackendIPT.BLL.Services.Lab4;

public interface ICryptoService
{
    public Task<RSAKey> GenerateKeys(int keySize);
    public Task<RSAKey> GetKeys();
    public Task<byte[]> EncryptFile(byte[] fileData);
}