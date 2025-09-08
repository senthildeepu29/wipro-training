using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopForHomeApi.Data;
using ShopForHomeApi.Models;

namespace ShopForHomeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public CartController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Get user cart
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCart(int userId)
        {
            var cart = await _db.CartItems
                .Include(c => c.Product)
                .Where(c => c.UserId == userId)
                .ToListAsync();
            return Ok(cart);
        }

        // Add item to cart
        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] CartItem item)
        {
            var existing = await _db.CartItems
                .FirstOrDefaultAsync(c => c.UserId == item.UserId && c.ProductId == item.ProductId);

            if (existing != null)
            {
                existing.Quantity += item.Quantity;
            }
            else
            {
                _db.CartItems.Add(item);
            }

            await _db.SaveChangesAsync();
            return Ok(item);
        }

        // Update quantity
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCart(int id, [FromBody] CartItem item)
        {
            var cartItem = await _db.CartItems.FindAsync(id);
            if (cartItem == null) return NotFound();

            cartItem.Quantity = item.Quantity;
            await _db.SaveChangesAsync();

            return Ok(cartItem);
        }

        // Remove item
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var cartItem = await _db.CartItems.FindAsync(id);
            if (cartItem == null) return NotFound();

            _db.CartItems.Remove(cartItem);
            await _db.SaveChangesAsync();

            return Ok();
        }
    }
}
