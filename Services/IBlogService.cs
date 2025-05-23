using BlazorBlog.Models;

namespace BlazorBlog.Services;

public interface IBlogService
{
    Task<IEnumerable<BlogPost>> GetPostsAsync();
    Task<BlogPost?> GetPostBySlugAsync(string slug);
    Task<BlogPost?> GetPostByIdAsync(int id); // Optional, if you prefer ID
}