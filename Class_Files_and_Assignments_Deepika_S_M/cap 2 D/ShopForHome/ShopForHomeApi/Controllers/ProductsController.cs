using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopForHomeApi.Data;
using ShopForHomeApi.Models;

namespace ShopForHomeApi.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase {
        private readonly ApplicationDbContext _db;
        public ProductsController(ApplicationDbContext db) { _db = db; }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? category, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice) {
            var q = _db.Products.AsQueryable();
            if (!string.IsNullOrEmpty(category)) q = q.Where(p => p.Category == category);
            if (minPrice.HasValue) q = q.Where(p => p.Price >= minPrice.Value);
            if (maxPrice.HasValue) q = q.Where(p => p.Price <= maxPrice.Value);
            var list = await q.ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) {
            var p = await _db.Products.FindAsync(id);
            if (p == null) return NotFound();
            return Ok(p);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(Product product) {
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product product) {
            var existing = await _db.Products.FindAsync(id);
            if (existing == null) return NotFound();
            existing.Name = product.Name; existing.Description = product.Description;
            existing.Category = product.Category; existing.Price = product.Price; existing.Stock = product.Stock;
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var existing = await _db.Products.FindAsync(id);
            if (existing == null) return NotFound();
            _db.Products.Remove(existing);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
