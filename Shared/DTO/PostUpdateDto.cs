using System.Net;
using Shared.Models;

namespace Shared.DTO;

public class PostUpdateDto
{
    public int Id { get; }

    public Comment Comment { get; set; }

    public PostUpdateDto(int id,Comment comment)
    {
        Id = id;
        Comment = comment;
    }
}