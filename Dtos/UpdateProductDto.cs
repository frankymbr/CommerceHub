using System.ComponentModel.DataAnnotations;

namespace CommerceHub.Api.Dtos;

public class UpdateProductDto
{
    [Required]
    public string Sku { get; set; } = string.Empty;
    
    [Required]
    public string Name { get; set; } = string.Empty;
    
    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }
    
    [Range(0, int.MaxValue)]
    public int Stock { get; set; }
}