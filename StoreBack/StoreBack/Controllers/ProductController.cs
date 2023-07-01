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

        [HttpGet("order/{id}")]
        public async Task<Order> Get(Guid id)
        {
            var tmpOrder = await productDb.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (tmpOrder == null)
            {
                return new Order();
            }
            return tmpOrder;
        }

        [HttpPost]
        public string Post([FromBody] Order order)
        {
            if (order == null) { return "Invalid"; }
            var tmpOrder = new Order() { Adress = order.Adress };
            productDb.Orders.Add(tmpOrder);
            productDb.SaveChanges();
            //Some pay things
            foreach (var product in order.Products)
            {
                if (product.OrderID != null)
                    return "Invalid";
                product.OrderID = tmpOrder.Id;
                try
                {
                    productDb.Products.Update(product);
                    productDb.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    return ex.Message;
                }
                catch (DbUpdateException ex)
                {
                    return ex.Message;
                }
            }

            return "Created";
        }

        [HttpPut("product/{id}")]
        public string PutProduct(int id, [FromBody] Product value)
        {
            try
            {
                productDb.Products.Update(value);
                productDb.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return ex.Message;
            }
            catch (DbUpdateException ex)
            {
                return ex.Message;
            }
            return "Success";
        }
        [HttpPut("order/{id}")]
        public string PutOrder(int id, [FromBody] Order value)
        {
            try
            {
                productDb.Orders.Update(value);
                productDb.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return ex.Message;
            }
            catch (DbUpdateException ex)
            {
                return ex.Message;
            }
            return "Success";
        }

        [HttpDelete("order/{id}")]
        public async Task<string> DeleteOrder(Guid id)
        {
            var tmpOrder = await productDb.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (tmpOrder == null)
                return "Incorrect";
            try
            {
                productDb.Orders.Remove(tmpOrder);
                productDb.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return ex.Message;
            }
            catch (DbUpdateException ex)
            {
                return ex.Message;
            }
            return "Success";
        }
        [HttpDelete("product/{id}")]
        public async Task<string> DeleteProduct(Guid id)
        {
            var tmpProduct = await productDb.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (tmpProduct == null)
                return "Incorrect";
            try
            {
                productDb.Products.Remove(tmpProduct);
                productDb.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return ex.Message;
            }
            catch (DbUpdateException ex)
            {
                return ex.Message;
            }
            return "Success";
        }
    }
}
