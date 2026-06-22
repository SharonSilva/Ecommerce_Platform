using Ecommerce.Api.Data;
using Ecommerce.Api.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _db;
    public ProductsController(AppDbContext db)
    {
        _db = db;
    }

    //GET /api/products
     [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
    {
        var products = await _db.Products
            .Where(p => p.IsActive)
            .OrderBy(p => p.Name)
            .Select(p => new ProductDto(
                p.Id,
                p.Name,
                p.Slug,
                p.Description,
                p.Price,
                p.StockQuantity,
                p.ImageUrl,
                p.Category.Name))
            .ToListAsync();
        return Ok(products);
    }
}