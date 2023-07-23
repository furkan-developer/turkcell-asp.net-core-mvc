using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Repository.Extensions
{
    public static class ProductRepositoryExtensions
    {
        public static IQueryable<Product> FilteredByCategoryId(this IQueryable<Product> products,int? categoryId){
            return categoryId is null ? products
                : products.Where(p => p.CategoryId.Equals(categoryId));
        }

        public static IQueryable<Product> SearchedByTermOnProductName(this IQueryable<Product> products,string searchTerm){
            return  String.IsNullOrEmpty(searchTerm) ? products
                : products.Where(p => p.Name.ToLower().Contains(searchTerm.Trim().ToLower()));
        }
    }
}