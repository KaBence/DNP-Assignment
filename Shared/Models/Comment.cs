namespace Shared.Models;

public class Comment
{
    public string user { get; set; }
    
    public string body { get; set; }

    public Comment(string user, string body)
    {
        this.user = user;
        this.body = body;
    }
}