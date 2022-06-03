using Contracts.Products.Dtos;
using Contracts.Products.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Endpoint.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public IActionResult Post(ProductAddDto addDto)
        {
            var result = _productService.Add(addDto);
            return StatusCode((int)result.Status,result);
        }
        [HttpPut]
        public IActionResult Put(ProductEditDto editDto)
        {
            var result = _productService.Edit(editDto);
            return StatusCode((int)result.Status, result);
        }
        [HttpDelete]
        public IActionResult Delete(ProductDeleteDto deleteDto)
        {
            var result = _productService.Delete(deleteDto);
            return StatusCode((int)result.Status, result);
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _productService.GetAll();
            return StatusCode((int)result.Status, result);
        }
    }
}
