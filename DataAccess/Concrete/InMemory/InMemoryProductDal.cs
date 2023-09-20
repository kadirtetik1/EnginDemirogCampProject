using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {

        List<Product> _products;  // Bellekte bir tane ürün listesi oluşturduk. Bu sayede dışarıdan çektiğimiz veri olmadığı için kendi verimizi oluşturucaz.

        public InMemoryProductDal()
        {
            _products = new List<Product> {
            new Product {ProductId=1,CategoryId=1,ProductName="Kalem",UnitPrice=15,UnitsInStock=75},
            new Product {ProductId=2,CategoryId=2,ProductName="Silgi",UnitPrice=25,UnitsInStock=85},
            new Product {ProductId=3,CategoryId=3,ProductName="Cetvel",UnitPrice=35,UnitsInStock=95},
            }; 
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {

            // ----- LİNQ KULLANMADAN -----

            // Product productDelete = null;  // Referans tutmak için Producttan oluşturduğumuz boş bir obje

            //foreach(var p in _products)
            //{
            //    if(product.ProductId == p.ProductId)
            //    {
            //        productDelete = p;  // productDelete içine Id'si eşit olan productın referansını attı.
            //    }

            //}

            //_products.Remove(productDelete);




            // ----- LİNQ KULLANARAK -----

            Product productDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);  //SingleOrDefault uyguladığımız listeyi tek tek kendisi döner ve parantez içindeki koşula uyan tek bir elemanı bulmaya yarar.
            _products.Remove(productDelete);

        }

        public List<Product> GetAll()   //buradaki List<Product> return tipidir.
        {
            return _products;          // _products Listesini döndürüyor.
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();

        }

        public void Update(Product product)
        {
            Product productUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            productUpdate.ProductName= product.ProductName;
            productUpdate.UnitPrice= product.UnitPrice;
            productUpdate.UnitsInStock= product.UnitsInStock;
            productUpdate.CategoryId= product.CategoryId;
        }
    }
}
