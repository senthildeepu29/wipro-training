using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopForHomeApi.Data;
using ShopForHomeApi.Models;

namespace ShopForHomeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CouponsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public CouponsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Admin creates coupon
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateCoupon([FromBody] Coupon coupon)
        {
            _db.Coupons.Add(coupon);
            await _db.SaveChangesAsync();
            return Ok(coupon);
        }

        // User applies coupon
        [HttpGet("apply/{code}")]
        [Authorize]
        public async Task<IActionResult> ApplyCoupon(string code)
        {
            var coupon = await _db.Coupons
                .FirstOrDefaultAsync(c => c.Code == code && c.ValidFrom <= DateTime.Now && c.ValidTo >= DateTime.Now);

            if (coupon == null) return NotFound("Invalid or expired coupon.");

            return Ok(new { discount = coupon.DiscountAmount });
        }
    }
}
