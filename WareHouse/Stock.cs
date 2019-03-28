using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace WareHouse
{
    public delegate void Add(string message);

    public class Stock<T> : IRepository<T>
    {
        public List<Product> products;
        public event Add AddReport;

        public string GetProductInfo(string name)
        {
            foreach (var t in products)
            {
                if (t.Name.Equals(name))
                    return t.State;
            }
            return "Product has not found";
        }

        public void SerializeProduct(List<T> newList)
        {
            File.Delete("products.json");
            using (StreamWriter streamWriter= File.CreateText("products.json"))
            {
                JsonSerializer jsonSerializer = new JsonSerializer();
                jsonSerializer.Serialize(streamWriter, newList);
              
            }
        }

        public void AddProduct(T newProduct)
        {
            List<T> list = GetProducts();
            list.Add(newProduct);
            SerializeProduct(list);
            AddReport($"Product has added");
        }

        public List<T> GetProducts()
        {
            try
            {
                using (StreamReader streamReader = File.OpenText("products.json"))
                {
                    JsonSerializer jsonSerializer = new JsonSerializer();
                    return (List<T>)jsonSerializer.Deserialize(streamReader, typeof(List<T>));
                }
            }
            catch (FileNotFoundException)
            {
                File.CreateText("products.json").Close();
                return new List<T>();
            }
        }
    }
}
