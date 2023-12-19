using BackendIPT.BLL.Services.Lab4;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CryptoController : ControllerBase
{
    private readonly ICryptoService _cryptoService;

    public CryptoController(ICryptoService cryptoService)
    {
        _cryptoService = cryptoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetKeys()
    {
        try
        {
            var keys = await _cryptoService.GetKeys();
            return Ok(keys);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPost("generate-keys")]
    public async Task<IActionResult> GenerateKeys([FromQuery] int keySize)
    {
        try
        {
            var keys = await _cryptoService.GenerateKeys(keySize);
            return Ok(keys);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("encrypt-file")]
    public async Task<IActionResult> EncryptFile([FromBody] byte[] fileData)
    {
        try
        {
            var encryptedData = await _cryptoService.EncryptFile(fileData);
            return Ok(encryptedData);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}