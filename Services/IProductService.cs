using CommerceHub.Api.Models;

namespace CommerceHub.Api.Services;

public interface IProductService
{
    List<Product> GetAll();
    Product? GetById(int id);
    Product Create(Product product);
    bool Update(int id, Product product);
    bool Delete(int id);
}