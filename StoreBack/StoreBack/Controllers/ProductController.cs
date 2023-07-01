using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreBack.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ApplicationContext productDb;
        public ProductController(ApplicationContext db)
        {
            productDb = db;
        }
        [HttpGet]
        public async Task<List<Product>> Get()
        {
            return await productDb.Products.Where(x => x.OrderID == null).ToListAsync();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public string Post([FromBody] Order order)
        {
            if (order == null) { return "Invalid"; }
            var tmpOrder = new Order() {Adress=order.Adress };
            productDb.Orders.Add(tmpOrder);
            productDb.SaveChanges();
            //Some pay things
            foreach (var product in order.Products)
            {
                if (product.OrderID != null)
                    return "Invalid";
                product.OrderID = tmpOrder.Id;
                productDb.Products.Update(product);
            }
            productDb.SaveChanges();

            return "Created";
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
