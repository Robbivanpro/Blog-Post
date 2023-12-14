using CodePulse.API.Models.Domini;
using System.ComponentModel;

namespace CodePulse.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync (Category category); 

        Task<IEnumerable<Category>> GetAllAsync ();

        Task<Category> GetByID(Guid Id);

        Task<Category> UpdateAsync(Category category);

        Task<Category?> DeleteAsync (Guid id);
    }
}
