using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly StoreContext _dbcontext;
        public ProductsController(StoreContext dbcontext)
        {
            _dbcontext = dbcontext;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _dbcontext.Products.FindAsync(id);
            return Ok(product);
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _dbcontext.Products.ToListAsync();
            return Ok(products);
        }


    }
}