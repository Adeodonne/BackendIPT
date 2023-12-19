using System.Text;
using BackendIPT.DAL.Entities;
using BackendIPT.DAL.Repositories;

namespace BackendIPT.BLL.Lab2;

public class Md5Service : IMD5Service
{
    private readonly IMD5Repository _md5Repository;

    public Md5Service(IMD5Repository md5Repository)
    {
        _md5Repository = md5Repository;
    }

    public async Task<List<MD5HashItem>> GetAllMd5HashItems()
    {
        return await _md5Repository.GetAllMD5Hash();
    }
    
    public async Task<MD5HashItem> CreateEntity(MD5DTO newHashDto)
    {
        var newHash = new MD5HashItem
        {
            Id = Guid.NewGuid().ToString(),
            Text = newHashDto.Text,
            Date = newHashDto.Date,
            Hash = MD5.GetHash(newHashDto.Text)
        };
        await _md5Repository.CreateHash(newHash);
        
        return newHash;
    }
    
    public async Task DeleteHash(string id)
    {
        _md5Repository.DeleteHash(id);
    }
}