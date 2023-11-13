using Shared.Models;

namespace FileData;

public class DataContainer
{
    public ICollection<Owner> Users { get; set; }
    public ICollection<Post> Posts { get; set; }
}