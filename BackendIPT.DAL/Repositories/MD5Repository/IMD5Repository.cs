using BackendIPT.DAL.Entities;

namespace BackendIPT.DAL.Repositories;

public interface IMD5Repository
{
    public Task<List<MD5HashItem>> GetAllMD5Hash();

    public Task CreateHash(MD5HashItem newHash);

    public void DeleteHash(string id);
}