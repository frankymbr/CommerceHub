using Microsoft.AspNetCore.Mvc;

namespace CommerceHub.Api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok("Listado de productos");
    }
    
}