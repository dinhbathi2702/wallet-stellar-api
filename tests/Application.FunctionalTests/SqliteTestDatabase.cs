﻿using System.Data;
using System.Data.Common;
using wallet_stellar_api.Infrastructure.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace wallet_stellar_api.Application.FunctionalTests;

public class SqliteTestDatabase : ITestDatabase
{
    private readonly string _connectionString;
    private readonly SqliteConnection _connection;

    public SqliteTestDatabase()
    {
        _connectionString = "DataSource=:memory:";
        _connection = new SqliteConnection(_connectionString);
    }

    public async Task InitialiseAsync()
    {
        if (_connection.State == ConnectionState.Open)
        {
            await _connection.CloseAsync();
        }

        await _connection.OpenAsync();

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlite(_connection)
            .Options;

        var context = new ApplicationDbContext(options);

        context.Database.Migrate();
    }

    public DbConnection GetConnection()
    {
        return _connection;
    }

    public async Task ResetAsync()
    {
        await InitialiseAsync();
    }

    public async Task DisposeAsync()
    {
        await _connection.DisposeAsync();
    }
}