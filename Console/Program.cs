namespace ConsoleApp;
using ProductsLibrary;
using System.Text;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        ProductManager pm = new();

        List<Product> products = pm.GetProducts();
        int n = products.Count;

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(products[i]);
        }
        
    }
}
