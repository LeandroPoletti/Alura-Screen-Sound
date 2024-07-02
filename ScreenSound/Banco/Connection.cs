using Npgsql;
using ScreenSound.Modelos;

namespace ScreenSound.Banco
{
    internal class Connection
    {
        private static string connString = "Host=localhost;Username=postgres;Password=Senha123;Database=screensound";
        private static NpgsqlDataSourceBuilder dataSourceBuilder { get; set; } = new NpgsqlDataSourceBuilder(connString);
        private static NpgsqlDataSource dataSource { get; set; } = dataSourceBuilder.Build();
        public static NpgsqlConnection conn = dataSource.OpenConnection();

        
    }
}






/*

// Insert some data
await using (var cmd = new NpgsqlCommand("INSERT INTO data (some_field) VALUES (@p)", conn))
{
    cmd.Parameters.AddWithValue("p", "Hello world");
    await cmd.ExecuteNonQueryAsync();
}

// Retrieve all rows
await using (var cmd = new NpgsqlCommand("SELECT some_field FROM data", conn))
await using (var reader = await cmd.ExecuteReaderAsync())
{
    while (await reader.ReadAsync())
        Console.WriteLine(reader.GetString(0));
}*/