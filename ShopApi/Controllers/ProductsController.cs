using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopApi.Models;

namespace ShopApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductsController : ControllerBase
    {
        private readonly ShopDBContext _dbContext;
        
        public ProductsController(ShopDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetProdcuts()
        {
            var getProductQuery = _dbContext.Product.AsQueryable();


            return Ok(getProductQuery.ToList());
        }


        [HttpGet("{identifier}")]
        public IActionResult GetProdcutById(int identifier)
        {
            var getProductQuery = _dbContext.Product.AsQueryable();

            var product = getProductQuery.FirstOrDefault(p => p.Id == identifier);

            if (product != null)
            {
                return Ok(product);
            }

            return NotFound();
        }

        [HttpPost()]
        public IActionResult Create([FromBody] Product input)
        {
            var errors = new List<string>();
            if (input != null)
            {
                if (string.IsNullOrEmpty(input.Name))
                {
                    errors.Add("Name cannot be null");
                }

                if (input.Price <= 0)
                {
                    errors.Add("Price cannot be less or equal than 0");
                }

                if (errors.Count == 0)
                {

                    input.CreationDate = DateTime.Now; 
                    input.Stock = 0;
                    
                    _dbContext.Product.Add(input);

                    _dbContext.SaveChanges();

                    return Created($"https://localhost:44358/Products/GetProdcutById/{input.Id}", input);
                }

                return BadRequest(errors); 
            }

            return BadRequest("input cannot be null or empty");
        }


        [HttpPatch("{identifier}")]
        public IActionResult Update([FromBody] Product input , int identifier)
        {
            var errors = new List<string>();

            if (input != null)
            {
                if (string.IsNullOrEmpty(input.Name))
                {
                    errors.Add("Name cannot be null");
                }

                if (input.Price <= 0)
                {
                    errors.Add("Price cannot be less or equal than 0");
                }

                if (errors.Count == 0)
                {

                    var product = _dbContext.Product.FirstOrDefault(p => p.Id == identifier);
                    if (product == null)
                    {
                        return NotFound(errors);
                    }

                    product.Name = input.Name;
                    product.Price = input.Price;
                    product.Stock = input.Stock;
                    product.UpdateDate = DateTime.Now; 

                    _dbContext.Product.Update(product);

                    _dbContext.SaveChanges();

                    return Ok(product);
                }

                return BadRequest(errors);
            }

            return BadRequest("input cannot be null or empty");
        }


        [HttpGet()]
        public IActionResult GetCustomersTotal()
        {

            var orders = _dbContext.Order
                .Include(o => o.Customer)
                .Include(o=> o.OrderItem).ThenInclude(o=>o.Product)
                                    .ToList();

            var odrerTotal = from o in orders
                select new {Customer = o.Customer.Email, Total = o.OrderItem.Sum(oi => oi.Quantity * oi.Product.Price)};

            return Ok(odrerTotal);
        }


    }
}
