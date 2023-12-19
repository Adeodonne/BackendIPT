using System.ComponentModel.DataAnnotations.Schema;

namespace BackendIPT.DAL.Entities;

[Table("MD5Hash")]
public class MD5HashItem
{
    public string? Id { get; set; }
    public string Text { get; set; }
    public string Hash { get; set; }
    public string Date { get; set; }
}