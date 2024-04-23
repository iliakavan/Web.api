using Microsoft.AspNetCore.Mvc;
using Webapi.services;
using Webapi.services.Dots;

namespace Webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductDto model)
        {
            var result = await _service.Add(model);
            if (!result.IsSuccessfull)
            {
                return NotFound(result);
            }
            return Ok();

        }
    }
}