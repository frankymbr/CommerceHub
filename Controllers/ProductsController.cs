using CommerceHub.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommerceHub.Api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private static readonly List<Product> Products =
    [
        new Product
        {
            Id = 1,
            Sku = "POLO-001",
            Name = "Polo Negro",
            Price = 59.90m,
            Stock = 10
        },
        new Product
        {
            Id = 1,
            Sku = "PULSERA-001",
            Name = "Pulsera Dorada",
            Price = 59.90m,
            Stock = 10
        }
    ];
    
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(Products);
    }
    
}