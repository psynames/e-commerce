using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly StoreContext _dbcontext;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbcontext"></param>
        public ProductsController(StoreContext dbcontext)
        {
            _dbcontext = dbcontext;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _dbcontext.Products.FindAsync(id);
            return Ok(product);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _dbcontext.Products.ToListAsync();
            return Ok(products);
        }


    }
}