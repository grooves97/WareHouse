using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace WareHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product("Iphone","Крутой телефон",250000);
            Stock<Product> stock = new Stock<Product>();
            stock.AddReport += (text => Console.WriteLine(text));

            stock.AddProduct(product);

            Console.ReadLine();
        }
    }
}
