﻿using RestCode_WebApplication.Domain.Models;
using RestCode_WebApplication.Domain.Repositories;
using RestCode_WebApplication.Domain.Services;
using RestCode_WebApplication.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestCode_WebApplication.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        //private readonly IUnitOfWork _unitOfWork;
        //public ProductService(IProductRepository  productRepository, IProductTagRepository productTagRepository, IUnitOfWork unitOfWork)
        //{
        //    _productRepository = productRepository;
        //    _productTagRepository = productTagRepository;
        //    _unitOfWork = unitOfWork;
        //}
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
            return await _productRepository.ListAsync();
        }

        //public async Task<IEnumerable<Product>> ListByCategoryIdAsync(int ProductId)
        //{
        //    return await _productRepository.ListByCategoryIdAsync(ProductId);
        //}

        public async Task<ProductResponse> GetByIdAsync(int id)
        {
            var existingProduct = await _productRepository.FindById(id);

            if (existingProduct == null)
                return new ProductResponse("Product not found");
            return new ProductResponse(existingProduct);
        }

        public async Task<ProductResponse> SaveAsync(Product product)
        {
            try
            {
                await _productRepository.AddAsync(product);

                return new ProductResponse(product);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"An error ocurred while saving the Product: {ex.Message}");
            }
        }

        public async Task<ProductResponse> UpdateAsync(int id, Product Product)
        {
            var existingProduct = await _productRepository.FindById(id);

            if (existingProduct == null)
                return new ProductResponse("Product not found");

            existingProduct.Name = Product.Name;

            try
            {
                _productRepository.Update(existingProduct);

                return new ProductResponse(existingProduct);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"An error ocurred while updating Product: {ex.Message}");
            }

        }

        public async Task<ProductResponse> DeleteAsync(int id)
        {
            var existingProduct = await _productRepository.FindById(id);

            if (existingProduct == null)
                return new ProductResponse("Product not found");

            try
            {
                _productRepository.Remove(existingProduct);

                return new ProductResponse(existingProduct);
            }
            catch (Exception ex)
            {
                return new ProductResponse($"An error ocurred while deleting Product: {ex.Message}");
            }
        }


    }
}
