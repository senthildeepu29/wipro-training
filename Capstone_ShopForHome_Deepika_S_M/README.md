# ShopForHome (Starter)

Minimal working **.NET 7 Web API** + **Angular starter** for the ShopForHome capstone.

## Backend (.NET 7 + EF Core Sqlite)
- Run:
  ```bash
  cd ShopForHome.Api
  dotnet restore
  dotnet run
  ```
- Swagger: `http://localhost:5000/swagger` (or shown in console)
- DB: SQLite file `shopforhome.db` auto-created with seed data.
- Admin seed: `admin@shopforhome.com` / `Admin@123`

### Key Endpoints
- `POST /api/auth/register`
- `POST /api/auth/login`
- `GET /api/products?category=Furniture&minPrice=1000&maxPrice=5000&minRating=4`
- `POST /api/upload/products-csv` (CSV: Name,Category,Price,Rating,ImageUrl,Stock)
- `GET /api/reports/stock-low?threshold=10`
- `GET /api/reports/sales?from=2025-01-01&to=2025-12-31`

## Frontend (Angular starter)
This is a lightweight Angular starter (not full CLI scaffold). Use it as a reference or migrate into an Angular CLI project.

- `src/app/services/product.service.ts` contains API calls (adjust baseUrl).
- run `npm install`
- Components for basic list, login.

## Database Schema (SQL)
See `database/schema.sql` for table design.

> This starter is intentionally compact to fit in one deliverable. You can extend with JWT auth, proper authorization guards, and a full Angular CLI app.
