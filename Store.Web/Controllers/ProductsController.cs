﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Services.Services;
using Store.Services.Services.ProductServices.Dtos;

namespace Store.Web.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BrandTypeDetailsDto>>> GetAllBrands()
            =>Ok(await _productService.GetAllTypesAsync());
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BrandTypeDetailsDto>>> GetAllTypes()
     => Ok(await _productService.GetAllBrandsAsync());
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDetailsDto>>> GetAllProducts()
      => Ok(await _productService.GetAllProductsAsync());

        [HttpGet]
        public async Task<ActionResult<ProductDetailsDto>> GetAllProductById(int? Id)
      => Ok(await _productService.GetProductByIdAsync(Id));
    }
}
