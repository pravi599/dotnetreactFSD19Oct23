﻿using ShoppingApplication.Exceptions;
using ShoppingApplication.Interfaces;
using ShoppingApplication.Models;
namespace ShoppingApplication.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<int, Product> _productRepository;

        public ProductService(IRepository<int, Product> repository)
        {
            _productRepository = repository;
        }
        public Product Add(Product product)
        {
            if (product.Price > 5)
            {
                var result = _productRepository.Add(product);
                return result;
            }
            return null;
        }

        public List<Product> GetProducts()
        {
            var products = _productRepository.GetAll();
            if (products != null)
            {
                return products.ToList();
            }
            throw new NoProductsAvailableException();
        }
    }
}
