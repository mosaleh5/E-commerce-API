﻿using AutoMapper;
using Store.Data.Entities;
using Store.Repository.Interfaces;
using Store.Repository.Specification.ProductSpecs;
using Store.Services.Helper;
using Store.Services.Services.ProductServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductEntity = Store.Data.Entities.Product;
namespace Store.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllBrandsAsync()
        {
            var brands = await _unitOfWork.Repository<ProductBrand, int>().GetAllAsync();

            var mappedBrands = _mapper.Map<IReadOnlyList<BrandTypeDetailsDto>>(brands);
              
            return mappedBrands;     
        }

        public async Task<IReadOnlyList<BrandTypeDetailsDto>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.Repository<ProductType, int>().GetAllAsync();
            
           var mappedTypes = _mapper.Map< IReadOnlyList < BrandTypeDetailsDto >>(types);
        
            return mappedTypes;

        }

        public async Task<ProductDetailsDto> GetProductByIdAsync(int? productId)
        {
            if (productId is null)
                throw new Exception("Id id null");
            var specs = new ProductWithSpecifications(productId);
            var Product = await _unitOfWork.Repository<ProductEntity, int>().GetWithSpecificationByIdAsync(specs);
            if (Product == null)
                throw new Exception("Product  Not Found ");
            var mappedProduct = _mapper.Map<ProductDetailsDto>(Product);
                
                
           
            return mappedProduct;
        }

        public async Task<PaginatedResultDto<ProductDetailsDto>> GetAllProductsAsync(ProductSpecification input)
        {
            var specs = new ProductWithSpecifications(input);    
            var products = await _unitOfWork.Repository<ProductEntity, int>().GetAllWithSpecificationAsync(specs);
            var countSpecs = new ProductWithCountSpecification(input);
            var count = await _unitOfWork.Repository<ProductEntity, int>().GetCountSpecificationAsync(countSpecs);
            var mappedProducts = _mapper.Map<IReadOnlyList<ProductDetailsDto>>(products);
            
            return new PaginatedResultDto<ProductDetailsDto>(input.PageSize ,input.PageIndex , products.Count , mappedProducts); 
        }
    }
}
