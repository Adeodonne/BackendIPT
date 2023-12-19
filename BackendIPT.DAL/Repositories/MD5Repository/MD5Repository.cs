using BackendIPT.DAL.Entities;
using BackendIPT.DAL.Persistance;

namespace BackendIPT.DAL.Repositories;

public class MD5Repository : IMD5Repository
{
    private readonly IPTDBContext _context;

    public MD5Repository(IPTDBContext context)
    {
        _context = context;
    }
    
    public async Task<List<MD5HashItem>> GetAllMD5Hash()
    {
        try
        {
            List<MD5HashItem> md5HashItems = _context.Md5HashItems.ToList();

            return md5HashItems;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving entity: {ex.Message}");
            throw;
        }
    }
    
    public async Task CreateHash(MD5HashItem newHash)
    {
        try
        {
            _context.Md5HashItems.Add(newHash);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating entity: {ex.Message}");
            throw;
        }
    }
    
    public void DeleteHash(string id)
    {
        try
        {
            var hashToDelete = _context.Md5HashItems.Find(id);

            if (hashToDelete != null)
            {

                _context.Md5HashItems.Remove(hashToDelete);
                
                _context.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting entity: {ex.Message}");
            throw;
        }
    }
}