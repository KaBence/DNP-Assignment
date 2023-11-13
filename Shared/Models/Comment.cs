using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Comment
{
    [Key]
    public int Id { get; set; }
    public string User { get; set; }
    
    public string Body { get; set; }

    public Comment(string user, string body)
    {
        User = user;
        Body = body;
    }
    
    private Comment(){}
}