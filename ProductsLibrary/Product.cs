using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsLibrary;
public class Product
{
    public Product(string id, string name, double price)
    {
        Id = id; Name = name; Price = price;
    }
    public string Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; } 
}
