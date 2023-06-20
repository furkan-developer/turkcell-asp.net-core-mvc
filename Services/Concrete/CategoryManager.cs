using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Services.Contracts;
using Repository;

namespace Services.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _rp;

        public CategoryManager(IRepositoryManager rp)
        {
            _rp = rp;
        }

        public List<Category> GetAllCategories(bool isTrackingChanges)
        {
            return _rp.CategoryRepository.GetAllCategories(false);
        }
    }
}