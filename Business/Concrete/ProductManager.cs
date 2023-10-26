using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IResult Add(Product product)
        {
           _productDal.Add(product);

            return new Result(true, "Ürün Eklendi!");
        }

        public IDataResult<List<Product>> GetAll()
        {
            if(DateTime.Now.Hour == 11)  // Saat 11'de bakım mesajı yazdırılacak
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);  // Gönderilen _productDal nesnesi üzerinden sorgulama yapıyor.
        } 

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>> (_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<List<Product>> GetAllByPriceRange(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>> (_productDal.GetAll(p=> p.UnitPrice>=min && p.UnitPrice<=max));
        }

        public IDataResult<Product> GetById(int ProductId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=> p.ProductId == ProductId));
        }

        public IDataResult<List<ProductDetailDTO>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDTO>>(_productDal.GetProductDetails()) ;
        }
    }
}
