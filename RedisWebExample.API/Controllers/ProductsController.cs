using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedisExampleWeb.Cache;
using RedisWebExample.API.Models;
using RedisWebExample.API.Repositories;

namespace RedisWebExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private readonly RedisService _redisService;
        public ProductsController(IProductRepository productRepo, RedisService redisService)
        {
            _productRepo = productRepo;
            _redisService = redisService;

            var db = _redisService.GetDb(0);
            db.StringSet("name", "yigit");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productRepo.GetProducts());
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _productRepo.GetProduct(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product p)
        {
            return Created(string.Empty, await _productRepo.AddProduct(p));
        }
    }
}
