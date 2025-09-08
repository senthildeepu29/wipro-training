using ShopForHomeApi.Data;
using ShopForHomeApi.Models;

namespace ShopForHomeApi.Services {
    public class DataSeeder {
        private readonly ApplicationDbContext _db;
        private readonly AuthService _auth;
        public DataSeeder(ApplicationDbContext db, AuthService auth) { _db = db; _auth = auth; }

        public async Task Seed() {
            await _db.Database.EnsureCreatedAsync();
            if (!_db.Users.Any()) {
                var admin = new User { Username="admin", Email="admin@shop.com", PasswordHash = _auth.HashPassword("Admin@123"), Role="Admin" };
                _db.Users.Add(admin);
            }
            if (!_db.Products.Any()) {
                _db.Products.AddRange(new[] {
                    new Product { Name="Wooden Chair", Description="Comfortable chair", Category="Furniture", Price=1999, Stock=25, ImageUrl="", Rating=4.2 },
                    new Product { Name="Table Lamp", Description="LED lamp", Category="Lighting", Price=899, Stock=40, ImageUrl="", Rating=4.5 }
                });
            }
            await _db.SaveChangesAsync();
        }
    }
}
