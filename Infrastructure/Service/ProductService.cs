using System.Data;
using System.Net;
using Dapper;
using Domain.Entities;
using Infrastructure.DataContext;
using Infrastructure.Response;

namespace Infrastructure.Service;

public class ProductService(IContext context) : IProductService
{
    public async Task<ApiResponse<List<Product>>> GetAll()
    {
        using var connection = context.Connection();
        var sql = "select * from Products";
        var res = await connection.QueryAsync<Product>(sql);
        return new ApiResponse<List<Product>>(res.ToList());
    }

    public async Task<ApiResponse<Product>> GetById(int id)
    {
        using var connection = context.Connection();
        var sql = "select * from products where id = @Id";
        var res = await connection.QuerySingleOrDefaultAsync<Product>(sql, new { Id = id });
        if (res == null) return new ApiResponse<Product>(HttpStatusCode.NotFound, "Product Not Found");
        return new ApiResponse<Product>(res);
    }

    public async Task<ApiResponse<bool>> AddProduct(Product product)
    {
        using var connection = context.Connection();
        var sql = @"INSERT INTO Products (Name, Description, Price, StockQuantity, CategoryName, CreatedDate) 
                     VALUES (@Name, @Description, @Price, @StockQuantity, @CategoryName, @CreatedDate)";
        var res = await connection.ExecuteAsync(sql, product);
        if (res == 0) return new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error");
        return new ApiResponse<bool>(res > 0);
    }

    public async Task<ApiResponse<bool>> UpdateProduct(Product product)
    {
        using var connection = context.Connection();
        var sql =
            @"update Products set Name=@Name,Description=@Description,Price=@Price,StockQuantity=@StockQuantity,CategoryName=@CategoryName,CreatedDate=@CreatedDate 
                    where id = @id";
        var res = await connection.ExecuteAsync(sql, product);
        if (res == 0) return new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error");
        return new ApiResponse<bool>(res > 0);
    }

    public async Task<ApiResponse<bool>> Delete(int id)
    {
        using var connection = context.Connection();
        var sql = @"delete products where id = @Id";
        var res = await connection.ExecuteAsync(sql, new { Id = id });
        if (res == 0) return new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Internal server error");
        return new ApiResponse<bool>(res > 0);
    }

    // public async Task<ApiResponse<bool>> SendToFile()
    // {
    //     using var connection = context.Connection();
    //     string path = @"c:\app\content.txt";
    //     await File.AppendAllTextAsync(path, "Hello work");
    //     string fileText = await File.ReadAllTextAsync(path);
    //     Console.WriteLine(fileText);
    //     // return 
    //
    // }
}