namespace ProductsLibrary;
// right click the library project -> Open in File Explorer
// write 'cmd' in the path box
// dotnet add package MySql.Data -v 8.0
// do not update its version
using MySql.Data.MySqlClient;
/// <summary>
/// Connects to the 'products' database via MySql.
/// </summary>
public class ProductManager
{
    private MySqlConnection connection;
    public ProductManager() : this("localhost", "shopping", "root") {}
    private ProductManager(string address,
        string database, string user, string password = "")
    {
        string connString = $"Data Source={address};Initial Catalog={database};User ID={user};Password={password};SslMode=none";
        connection = new MySqlConnection(connString);
    }
    public List<Product> GetProducts()
    {
        List<Product> result = new();
        try
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT id, name, price FROM products";
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Product product = new Product(
                    reader.GetString(0),
                    reader.GetString(1),
                    reader.GetDouble(2)
                );
                result.Add(product);
            }
        } finally { connection.Close(); }

        return result;
    }
    public void InsertProducts(params Product[] products)
    {
        //itt lesz az INSERT
        try
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO products (id, name, price) VALUES (@id, @name, @price)";

            int n = products.Length;
            for (int i = 0; i < n; i++)
            {
                command.Parameters.AddWithValue("@id", products[i].Id);
                command.Parameters.AddWithValue("@name", products[i].Name);
                command.Parameters.AddWithValue("@price", products[i].Price);

                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }

        } finally { connection.Close(); }
    }
    public void InsertProduct(string id, string name, double price)
    {
        try
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO products (id, name, price) VALUES (@id, @name, @price)";

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@price", price);

            command.ExecuteNonQuery();
        }
        finally { connection.Close(); }
    }
    public Product SelectProduct(string id)
    {
        try
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT id, name, price FROM products WHERE id = @id";
            command.Parameters.AddWithValue("@id", id);
            
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                string name = reader.GetString(1);
                double price = reader.GetDouble(2);
                return new Product(id, name, price);
            }
        }
        finally { connection.Close(); }
        return null;
    }
    public void UpdateProduct(string id, string name, double price)
    {
        try
        {
            connection.Open();
        }
        finally { connection.Close(); }
    }
    public void DeleteProduct(string id)
    {
        try
        {
            connection.Open();
        }
        finally { connection.Close(); }
    }
}
