using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core.Models;
using System.Net.Http.Headers;

namespace MyShop.DataAccess.InMemory
{
    //Not required further
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Products> products;

        public ProductRepository()
        {
            products = cache["products"] as List<Products>;
            if (products == null)
            {
                products = new List<Products>();
            }
        }

        public void commit()
        {
            cache["products"] = products;
        }

        public void Insert(Products p)
        {
            products.Add(p);
        }

        public void Update(Products p)
        {
            Products prod = products.Find(i => i.Id == p.Id);
            if (prod != null)
            {
                prod = p;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        public Products Find(string Id)
        {
            Products prod = products.Find(i => i.Id == Id);
            if (prod != null)
            {
                return prod;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
        public IQueryable<Products> Collection()
        {
            return products.AsQueryable();
        }

        public void Delete(string id)
        {
            Products prod = products.Find(i => i.Id == id);
            if (prod != null)
            {
                products.Remove(prod);
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
    }

    
}
