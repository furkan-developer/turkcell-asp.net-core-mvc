using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Dtos;
using Domain.Entities;
using Domain.RequestParameters;

namespace Services.Contracts
{
    public interface IProductService
    {
        void CreateOneProduct(ProductDtoForCreate dtoForCreate);
        List<ProductDto> GetAllProducts(bool isTrackChanges);
        List<ProductDto> GetAllProductsWithDetails(bool isTrackChanges, ProductRequestParameter parameters);
        ProductDto? GetOneProductById(bool isTrackChanges, int id);
        int GetTotalProduct();
        void UpdateOneProduct(ProductDtoForUpdate dtoForUpdate);
    }
}