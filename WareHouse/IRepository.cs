using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse
{
    public interface IRepository<T>
    {
        void AddProduct(T newProduct);
        List<T> GetProducts();
    }
}
