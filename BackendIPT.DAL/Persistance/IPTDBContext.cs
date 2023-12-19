using BackendIPT.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackendIPT.DAL.Persistance;

public class IPTDBContext : DbContext
{
    public IPTDBContext()
    {
    }
    
    public IPTDBContext(DbContextOptions<IPTDBContext> options) : base(options)
    {
    }
    
    public DbSet<MD5HashItem> Md5HashItems { get; set; }
    public DbSet<RSAKey> RSAKeys { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=127.0.0.1;Database=IPTDB;User Id=sa;Password=Admin@1234;MultipleActiveResultSets=true;TrustServerCertificate=True");
        }
    }
}