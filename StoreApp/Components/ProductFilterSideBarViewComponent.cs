using Microsoft.AspNetCore.Mvc;
using StoreApp.Models.Product;

namespace StoreApp.Components;

public class ProductFilterSideBarViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var filters = new ProductFilterViewModel();

        return View(filters);
    }
}