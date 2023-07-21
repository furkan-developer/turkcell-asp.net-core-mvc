using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using StoreApp.Models.Carts;
using StoreApp.Models.Product;

namespace StoreApp.Pages.Carts;

public class CartPageModel : PageModel
{
    public Cart Cart { get; set; }
    public IServiceManager _serviceManager { get; set; }
    public IMapper _mapper { get; set; }

    public CartPageModel(Cart cart, IServiceManager serviceManager, IMapper _mapper)
    {
        this._mapper = _mapper;
        Cart = cart;
        _serviceManager = serviceManager;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    public IActionResult OnPost(int productId)
    {
        var productDto = _serviceManager.ProductService.GetOneProductById(false, productId);

        if (productDto is not null)
        {
            var productForCart = _mapper.Map<ProductForCartViewModel>(productDto);

            Cart.AddItem(productForCart, 1);

            return RedirectToPage("./Index");
        }
        else
        {
            // statments
            throw new NotImplementedException();
        }
    }

    public IActionResult OnPostRemove(int productId)
    {
        ProductForCartViewModel? line = Cart.Cartlines.SingleOrDefault(line => line.Product.Id == productId)?.Product;

        if (line is not null)
        {
            Cart.RemoveLine(line);
            return RedirectToPage("./Index");
        }
        else
        {
            throw new NotImplementedException();
        }
    }
}