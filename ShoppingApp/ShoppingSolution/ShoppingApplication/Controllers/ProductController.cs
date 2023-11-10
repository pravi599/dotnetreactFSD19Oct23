using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingApplication.Exceptions;
using ShoppingApplication.Interfaces;
using ShoppingApplication.Models;

namespace ShoppingApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public ActionResult Get()
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _productService.GetProducts();
                return Ok(result);
            }
            catch (NoProductsAvailableException e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }
        [HttpPost]
        [Authorize]
        public ActionResult Create(Product product)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _productService.Add(product);
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }
    }
}
