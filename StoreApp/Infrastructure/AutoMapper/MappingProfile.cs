using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Services.Dtos;
using Domain.Entities;
using StoreApp.Models.Product;

namespace StoreApp.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product,ProductDto>().ReverseMap();
            CreateMap<ProductDto,Product>();
            CreateMap<ProductCreateViewModel,ProductDtoForCreate>();
            CreateMap<ProductDto,ProductUpdateViewModel>();
            CreateMap<ProductUpdateViewModel,ProductDtoForUpdate>();
        }
    }
}