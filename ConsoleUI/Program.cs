using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System.Net.Http.Headers;


ProductManager productManager = new ProductManager(new EfProductDal());


foreach (var item in productManager.GetAllByPriceRange(50,100))
{

    Console.WriteLine("Ürün:" + item.ProductName);
    Console.WriteLine("Fiyatı:" + item.UnitPrice);
    Console.WriteLine("Kategori:" + item.CategoryId);
    Console.WriteLine("-------------");

}