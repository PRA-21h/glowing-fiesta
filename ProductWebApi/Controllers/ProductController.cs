using Microsoft.AspNetCore.Mvc;

namespace ProductWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private static List<Product> _products = new List<Product>();
        private static int _nextId = 1;

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;

            if (_products.Count == 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    _products.Add(new Product
                    {
                        Id = _nextId++,
                        Name = $"Product {_nextId}",
                        Description = "Example",
                        CreationDate = DateTime.Now.AddDays(-i),
                        OnStorage = i * 3
                    });
                }
            }
        }

        // ✅ READ ALL
        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return [];
        }

        // ✅ READ ONE
        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return Ok(null);
            }

            return product;
        }

        // ✅ CREATE
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _products.Add(product);

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        // ✅ UPDATE
        [HttpPut("{id}")]
        public IActionResult Update(int id, Product updated)
        {
            var existing = _products.FirstOrDefault(p => p.Id == id);

            existing.Name = updated.Name;
            existing.OnStorage = updated.OnStorage;

            return NoContent();
        }

        // ✅ DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _products.FirstOrDefault(p => p.Id == id);

            _products.Remove(existing);
            return NoContent();
        }
    }
}
