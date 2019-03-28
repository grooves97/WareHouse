using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse
{

    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public Product(string name,string description,double price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public string State
        {
            get
            {
                return string.Format($"Название товара: {Name}, Описание: {Description}, Цена: {Price}");
            }
        }

    }
}
