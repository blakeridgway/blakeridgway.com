using BlazorBlog.Models;

namespace BlazorBlog.Services;

public class InMemoryBlogService : IBlogService
{
    private readonly List<BlogPost> _posts;

    public InMemoryBlogService()
    {
        _posts = new List<BlogPost>
        {
            new BlogPost
            {
                Id = 1,
                Title = "My First Blog Post",
                Summary = "A short summary of my very first post on this new blog!",
                Content = """
                          ## Welcome to My New Blog!

                          This is the full content of my first blog post.
                          It's written in **Markdown** (though we'll need to render it).

                          ### Features
                          - Exciting content
                          - More to come
                          """,
                PublishedDate = new DateTime(2025, 5, 20),
                Author = "Blake Ridgway"
            },
            new BlogPost
            {
                Id = 2,
                Title = "Exploring Blazor",
                Summary = "Talking about the cool things you can do with Blazor.",
                Content = """
                          ## Blazor is Awesome

                          Blazor lets you build interactive web UIs using C# instead of JavaScript.
                          That's pretty neat!

                          ```csharp
                          // This is a C# code block
                          public class HelloWorld
                          {
                              public static void Main(string[] args)
                              {
                                  Console.WriteLine("Hello, Blazor!");
                              }
                          }
                          ```
                          """,
                PublishedDate = new DateTime(2025, 5, 22),
                Author = "Blake Ridgway"
            }
        };

        // Generate slugs for all posts
        foreach (var post in _posts)
        {
            post.Slug = BlogPost.GenerateSlug(post.Title);
        }
    }

    public Task<IEnumerable<BlogPost>> GetPostsAsync()
    {
        return Task.FromResult(_posts.OrderByDescending(p => p.PublishedDate).AsEnumerable());
    }

    public Task<BlogPost?> GetPostBySlugAsync(string slug)
    {
        return Task.FromResult(_posts.FirstOrDefault(p => p.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase)));
    }

    public Task<BlogPost?> GetPostByIdAsync(int id)
    {
        return Task.FromResult(_posts.FirstOrDefault(p => p.Id == id));
    }
}