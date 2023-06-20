using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Services.Contracts
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories(bool isTrackingChanges);
    }
}