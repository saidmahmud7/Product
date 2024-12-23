using Domain.Entities;
using Infrastructure.Response;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controller;

public class ProductController(IProductService service) : ControllerBase
{
    [HttpGet("GetAll")]
    public async Task<ApiResponse<List<Product>>> GetAll() => await service.GetAll();

    [HttpGet("GetBy{id}")]
    public async Task<ApiResponse<Product>> GetById(int id) => await service.GetById(id);

    [HttpPost("Add")]
    public async Task<ApiResponse<bool>> Add(Product product) => await service.AddProduct(product);

    [HttpPut("Update")]
    public async Task<ApiResponse<bool>> Update(Product product) => await service.UpdateProduct(product);

    [HttpDelete("Delete")]
    public async Task<ApiResponse<bool>> Delete(int id) => await service.Delete(id);
}