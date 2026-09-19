using CommerceHub.Api.Models;

namespace CommerceHub.Api.Services;

public class ProductService : IProductService
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
    
    public List<Product> GetAll()
    {
        return Products;
    }

    public Product? GetById(int id)
    {
        return Products.FirstOrDefault(p => p.Id == id);
    }

    public Product Create(Product product)
    {
        product.Id  = Products.Count == 0 ? 1 : Products.Max(p => p.Id) + 1;
        Products.Add(product);
        return product;
    }

    public bool Update(int id, Product product)
    {
        var existingProduct = Products.FirstOrDefault(p => p.Id == id);

        if (existingProduct is null)
        {
            return false;
        }
        
        existingProduct.Sku = product.Sku;
        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;
        existingProduct.Stock = product.Stock;

        return true;
    }

    public bool Delete(int id)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        if (product is null)
        {
            return false;
        }
        
        Products.Remove(product);
        return true;
    }
}