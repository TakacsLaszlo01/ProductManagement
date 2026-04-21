namespace ProductsLibrary;
// right click the library project -> Open in File Explorer
// write 'cmd' in the path box
// dotnet add package MySql.Data -v 8.0
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
        List<Product> result = new List<Product>();
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
            }
        } finally { connection.Close(); }

        return result;
    }
    public void InsertProducts(params Product[] products)
    {
        //itt lesz az INSERT
    }
}
