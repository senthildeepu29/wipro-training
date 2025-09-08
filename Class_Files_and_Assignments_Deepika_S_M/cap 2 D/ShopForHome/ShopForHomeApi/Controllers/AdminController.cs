using CsvHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopForHomeApi.Data;
using ShopForHomeApi.Dtos;
using ShopForHomeApi.Models;
using System.Globalization;

namespace ShopForHomeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Bulk CSV Upload
        [HttpPost("upload-csv")]
        public async Task<IActionResult> UploadCsv(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            using var reader = new StreamReader(file.OpenReadStream());
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<ProductCsvModel>().ToList();

            foreach (var r in records)
            {
                var product = new Product
                {
                    Name = r.Name,
                    Description = r.Description,
                    Category = r.Category,
                    Price = r.Price,
                    Stock = r.Stock,
                    ImageUrl = r.ImageUrl
                };
                _db.Products.Add(product);
            }

            await _db.SaveChangesAsync();
            return Ok(new { message = $"{records.Count()} products uploaded successfully" });
        }
    }
}
