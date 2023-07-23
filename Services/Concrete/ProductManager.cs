using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Services.Contracts;
using Repository;
using Services.Dtos;
using AutoMapper;
using Domain.RequestParameters;

namespace Services.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _rpManager;
        private readonly IMapper _mapper;

        public ProductManager(IRepositoryManager rpManager, IMapper mapper)
        {
            _rpManager = rpManager;
            _mapper = mapper;
        }

        public void CreateOneProduct(ProductDtoForCreate dtoForCreate)
        {
            Product product = _mapper.Map<Product>(dtoForCreate);
            _rpManager.ProductRepository.CreateOneProduct(product);
            _rpManager.SaveChanges();
        }

        public List<ProductDto> GetAllProducts(bool isTrackChanges)
        {
            var products = _rpManager.ProductRepository.GetAllProducts
            (isTrackChanges);

            return _mapper.Map<List<ProductDto>>(products);
        }

        public List<ProductDto> GetAllProductsWithDetails(bool isTrackChanges, ProductRequestParameter parameters)
        {
            var products = _rpManager.ProductRepository.GetAllProductsWithDetails(false,parameters);
            
            return _mapper.Map<List<ProductDto>>(products);
        }

        public ProductDto? GetOneProductById(bool isTrackChanges, int id)
        {
            Product? product =  _rpManager.ProductRepository.GetOneProductById(id,isTrackChanges);

            ProductDto productDto = _mapper.Map<ProductDto>(product);
            
            return productDto;
        }

        public int GetTotalProduct()
        {
            return _rpManager.ProductRepository.GetTotalProduct();
        }

        public void UpdateOneProduct(ProductDtoForUpdate dtoForUpdate)
        {
            Product product = _mapper.Map<Product>(dtoForUpdate);
            
            _rpManager.ProductRepository.UpdateOneProduct(product);
            _rpManager.SaveChanges();
        }
    }
}