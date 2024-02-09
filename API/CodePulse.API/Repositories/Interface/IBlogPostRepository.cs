using CodePulse.API.Models.Domini;

namespace CodePulse.API.Repositories.Interface
{
    public interface IBlogPostRepository
    {
        Task <BlogPost>CreateAsync(BlogPost blogPost);
        Task<IEnumerable<BlogPost>> GetAllAsync();
    }
}
