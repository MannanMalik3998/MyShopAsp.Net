using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    //Not required further
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategs ;

        public ProductCategoryRepository()
        {
            productCategs = cache["productCategs"] as List<ProductCategory>;
            if (productCategs == null)
            {
                productCategs = new List<ProductCategory>();
            }
        }

        public void commit()
        {
            cache["productCategs"] = productCategs;
        }

        public void Insert(ProductCategory p)
        {
            productCategs.Add(p);
        }

        public void Update(ProductCategory prodyctCategory)
        {
            ProductCategory prodyctCategoryToUpdate = productCategs.Find(i => i.Id == prodyctCategory.Id);
            if (prodyctCategoryToUpdate != null)
            {
                prodyctCategoryToUpdate = prodyctCategory;
            }
            else
            {
                throw new Exception("Prodyct Category not found");
            }
        }

        public ProductCategory Find(string Id)
        {
            ProductCategory prod = productCategs.Find(i => i.Id == Id);
            if (prod != null)
            {
                return prod;
            }
            else
            {
                throw new Exception("Product Category not found");
            }
        }
        public IQueryable<ProductCategory> Collection()
        {
            return productCategs.AsQueryable();
        }

        public void Delete(string id)
        {
            ProductCategory prod = productCategs.Find(i => i.Id == id);
            if (prod != null)
            {
                productCategs.Remove(prod);
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
    }
}
