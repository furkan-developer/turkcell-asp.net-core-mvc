using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace StoreApp.Components
{
    public class CategoriesSideBarViewComponent : ViewComponent
    {
        private readonly IServiceManager _serviceManager;

        public CategoriesSideBarViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = _serviceManager.CategoryService.GetAllCategories(false);
            
            return View(result);
        }
    }
}