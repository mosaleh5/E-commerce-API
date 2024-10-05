using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Repository.Specification.ProductSpecs;
using Store.Services.Services;
using Store.Services.Services.ProductServices.Dtos;
using Store.Web.Helper;

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
        [Cache(10)]
        public async Task<ActionResult<IReadOnlyList<ProductDetailsDto>>> GetAllProducts([FromQuery] ProductSpecification input)
      => Ok(await _productService.GetAllProductsAsync(input));

        [HttpGet]
        public async Task<ActionResult<ProductDetailsDto>> GetAllProductById(int? Id)
       /* {
            var product = await _productService.GetProductByIdAsync(Id);
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }*/
      => Ok(await _productService.GetProductByIdAsync(Id));
    }
}
