using ApiTest1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Products> products = new List<Products>
        {
            new Products
            {
                Id = 1, Name = "Mleko 3.2", Description = "Świeże mleko", Price = 4.49M
            },
            new Products
            {
                Id = 2, Name = "Coca cola 2l", Description = "Coca-cola 2L", Price = 6.49M
            }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Products>> Get()
        {
            return products;
        }

        [HttpGet("{id}")]
        public ActionResult<Products> Get(int id)
        {
            var product = products.Find(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public ActionResult<Products> Post(Products newProduct)
        {
            products.Add(newProduct);
            return CreatedAtAction(nameof(Get), new { id = newProduct.Id }, newProduct);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var product = products.Find(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            products.Remove(product);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Products updatedProduct)
        {
            var product = products.Find(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.Price = updatedProduct.Price;

            return NoContent();
        }
    }
}
