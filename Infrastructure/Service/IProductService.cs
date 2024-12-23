using Domain.Entities;
using Infrastructure.Response;

namespace Infrastructure.Service;

public interface IProductService
{
    Task<ApiResponse<List<Product>>> GetAll();
    Task<ApiResponse<Product>> GetById(int id);
    Task<ApiResponse<bool>> AddProduct(Product product);
    Task<ApiResponse<bool>> UpdateProduct(Product product);
    Task<ApiResponse<bool>> Delete(int id);
}