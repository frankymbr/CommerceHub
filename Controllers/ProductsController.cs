using CommerceHub.Api.Dtos;
using CommerceHub.Api.Models;
using CommerceHub.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CommerceHub.Api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController(IProductService productService) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var result = productService.GetAll();
        return Ok(result);
    }
    
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        var product = productService.GetById(id);

        if (product is null)
        {
            return NotFound();
        }

        return Ok(product);
    }
    
    [HttpPost]
    public IActionResult Create([FromBody] CreateProductDto dto)
    {
        var product = new Product
        {
            Sku = dto.Sku,
            Name = dto.Name,
            Price = dto.Price,
            Stock = dto.Stock
        };

        var createdProduct = productService.Create(product);

        return CreatedAtAction(
            nameof(GetById),
            new { id = createdProduct.Id },
            createdProduct
        );
    }
    
    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] UpdateProductDto dto)
    {
        var product = new Product
        {
            Sku = dto.Sku,
            Name = dto.Name,
            Price = dto.Price,
            Stock = dto.Stock
        };

        var updated = productService.Update(id, product);

        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var deleted = productService.Delete(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}