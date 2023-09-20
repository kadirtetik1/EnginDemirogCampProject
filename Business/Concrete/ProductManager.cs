using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
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
    }
}
