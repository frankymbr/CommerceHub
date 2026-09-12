using CommerceHub.Api.Dtos;
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
            Id = 2,
            Sku = "PULSE-001",
            Name = "Pulse Dorado",
            Price = 59.90m,
            Stock = 10
        }
    ];
    
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(Products);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateProductDto productDto)
    {
        var product = new Product
        {
            Id = Products.Max(p => p.Id) + 1,
            Sku = productDto.Sku,
            Name = productDto.Name,
            Price = productDto.Price,
            Stock = productDto.Stock
        };
        
        Products.Add(product);
        
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] UpdateProductDto productDto)
    {
        var product = Products.FirstOrDefault(p=>p.Id == id);

        if (product is null)
        {
            return NotFound();
        }

        product.Sku = productDto.Sku;
        product.Name = productDto.Name;
        product.Price = productDto.Price;
        product.Stock = productDto.Stock;

        return Ok(product);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        
        if(product is null){
            return NotFound();
        }
        Products.Remove(product);
        return NoContent();
    }
}