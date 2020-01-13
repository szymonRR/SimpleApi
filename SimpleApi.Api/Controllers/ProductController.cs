using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleApi.Infrastructure.Commands.Products;
using SimpleApi.Infrastructure.Services;

namespace SimpleApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ApiControllerBase
    {
        private readonly IProductService _productService;
        

        public ProductController(IProductService productService)
        {
            _productService = productService;
            
        }

        

        [HttpGet("{productId}")]
        [Authorize]
        public async Task<IActionResult> GetOrders(Guid productId)
         => Json(await _productService.GetAsyc(productId));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AddProduct command)
        {

            await _productService.AddAsync(command.Name, command.Description, command.Price);
            return Created("/product", null);
        }
        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(Guid productId)
        {
            await _productService.DeleteAsync(productId);
            
            return NoContent();
        }
        [HttpPut("{productId}")]

        public async Task<IActionResult> Update(Guid productId)
        {
           await _productService.UpdateAsync(productId);
            return Ok();
        }


    }


}
