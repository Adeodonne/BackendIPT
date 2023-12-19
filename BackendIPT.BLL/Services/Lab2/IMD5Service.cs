using BackendIPT.DAL.Entities;

namespace BackendIPT.BLL.Lab2;

public interface IMD5Service
{
    public Task<List<MD5HashItem>> GetAllMd5HashItems();

    public Task<MD5HashItem> CreateEntity(MD5DTO newHashDto);

    public Task DeleteHash(string id);
}