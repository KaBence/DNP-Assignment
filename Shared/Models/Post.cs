using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Post
{
    [Key]
    public int Id { get; set; }
    public Owner Owner { get; set; }
    public int OwnerId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    
    public List<Comment> Comments { get; set; }

    public Post(int ownerID, string title, string body)
    {
        OwnerId = ownerID;
        Title = title;
        Body = body;
        Comments = new List<Comment>();
    }
    
    private Post(){}
}