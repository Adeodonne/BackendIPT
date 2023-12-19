using BackendIPT.BLL.Lab2;
using BackendIPT.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackendIPT.Controllers;

[ApiController]
[Route("[controller]")]
public class Md5Controller: ControllerBase
{
    private readonly IMD5Service _md5Service;

    public Md5Controller(IMD5Service md5Service)
    {
        _md5Service = md5Service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllHashes()
    {
        List<MD5HashItem> hashes = await _md5Service.GetAllMd5HashItems();
        return Ok(hashes);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEntity([FromBody] MD5DTO newHashDto)
    {
        var newHash = await _md5Service.CreateEntity(newHashDto);
        return Ok(newHash);
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteEntity(string id)
    {
        _md5Service.DeleteHash(id);
        return NoContent();
    }
}