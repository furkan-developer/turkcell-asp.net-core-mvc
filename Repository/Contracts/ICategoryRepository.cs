using Domain.Entities;

namespace Repository.Contracts
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories(bool isTrackChanges);
    }
}