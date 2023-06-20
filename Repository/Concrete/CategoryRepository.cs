using Repository.Contracts;
using Domain.Entities;
using Repository.EfCore;

namespace Repository.Concrete
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public List<Category> GetAllCategories(bool isTrackChanges)
        {
            return FindAll(isTrackChanges).ToList();
        }
    }
}