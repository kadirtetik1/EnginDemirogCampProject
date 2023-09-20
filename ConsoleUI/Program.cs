using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System.Net.Http.Headers;


ProductManager productManager = new ProductManager(new InMemoryProductDal());


foreach (var item in productManager.GetAll())
{

    Console.WriteLine("Ürün:" + item.ProductName);
    Console.WriteLine("Fiyatı:" + item.UnitPrice);
    Console.WriteLine("-------------");



}