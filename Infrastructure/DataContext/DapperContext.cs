﻿using System.Data;
using Npgsql;

namespace Infrastructure.DataContext;

public interface IContext
{
    IDbConnection Connection();
}

public class DapperContext : IContext
{
    private readonly string connectionString =
        "Server=localhost; Port = 5432; Database = ProductDb; User Id = postgres; Password = 280806;";

    public IDbConnection Connection()
    {
        return new NpgsqlConnection(connectionString);
    }
}