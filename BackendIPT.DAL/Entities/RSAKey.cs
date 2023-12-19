namespace BackendIPT.DAL.Entities;

public class RSAKey
{
    public int Id { get; set; }
    public string? PublicKey { get; set; }
    public string? PrivateKey { get; set; }
}