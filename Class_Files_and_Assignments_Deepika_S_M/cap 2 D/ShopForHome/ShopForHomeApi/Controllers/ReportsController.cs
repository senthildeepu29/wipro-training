using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopForHomeApi.Data;

namespace ShopForHomeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class ReportsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public ReportsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Total sales report
        [HttpGet("sales")]
        public async Task<IActionResult> GetSalesReport()
        {
            var totalSales = await _db.Orders.SumAsync(o => o.Total);
            var orderCount = await _db.Orders.CountAsync();

            return Ok(new
            {
                totalOrders = orderCount,
                totalRevenue = totalSales
            });
        }
    }
}
