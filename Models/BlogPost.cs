namespace BlazorBlog.Models;

public class BlogPost
{
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public string Slug { get; set; } = String.Empty;
    public string? Summary { get; set; }
    public string Content { get; set; } = String.Empty;
    public DateTime PublishedDate { get; set; } = DateTime.Now;
    public string? Author { get; set; }

    public static string GenerateSlug(string title)
    {
        if (string.IsNullOrEmpty(title))
            return string.Empty;

        var slug = title.ToLowerInvariant()
            .Replace(" ", "-")
            .Replace("?", "")
            .Replace("&", "and");
        
        slug = System.Text.RegularExpressions.Regex.Replace(slug, @"-+", "-");
        return slug.Trim('-');
    }
}