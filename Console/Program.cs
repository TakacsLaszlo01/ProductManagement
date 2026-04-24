namespace ConsoleApp;
using ProductsLibrary;
using System.Text;

internal class Program
{
    private static ProductManager pm;
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        pm = new();

        Console.WriteLine("Utasítások:\nL - listázás\nI - beszúrás\nD - törlés\nU - szerkesztés\nX - kilépés");
        string input = "L";
        while(!input.Equals("X"))
        {
            switch(input)
            {
                case "L":
                    ListProducts();
                    break;
                default: break;
            }
            input = Input("Adja meg a parancsot: ").ToUpper();
        }
    }
    private static void ListProducts()
    {
        List<Product> products = pm.GetProducts();
        int n = products.Count;
        for (int i = 0; i < n; i++)
            Console.WriteLine(products[i]);
    }
    private static string Input(string input)
    {
        Console.Write(input);
        return Console.ReadLine();
    }
}
