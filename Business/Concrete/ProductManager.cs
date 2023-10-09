using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)   // Bu sayede ProductManager classından obje oluşturulduğunda productDal alacaktır ve işlemleri bu nesne üzerinden yapabilecektir.
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();  // Gönderilen _productDal nesnesi üzerinden sorgulama yapıyor.
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetAllByPriceRange(decimal min, decimal max)
        {
            return _productDal.GetAll(p=> p.UnitPrice>=min && p.UnitPrice<=max);
        }

        public List<ProductDetailDTO> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
