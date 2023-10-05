using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System.Net.Http.Headers;

//ProductTest();

static void ProductTest()
{
    ProductManager productManager = new ProductManager(new EfProductDal());


    foreach (var item in productManager.GetAllByPriceRange(50, 100))
    {

        Console.WriteLine("Ürün:" + item.ProductName);
        Console.WriteLine("Fiyatı:" + item.UnitPrice);
        Console.WriteLine("Kategori:" + item.CategoryId);
        Console.WriteLine("-------------");

    }
}

//CategoryTest();

static void CategoryTest()
{
    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

    foreach (var category in categoryManager.GetAll())
    {
        Console.WriteLine(category.CategoryName);
    }
}

//OrderTest();

static void OrderTest()
{
    OrderManager orderManager = new OrderManager(new EfOrderDal());

    int i = 1;
    foreach (var order in orderManager.GetAll())
    {
        Console.WriteLine(i + ")" + order.ShipCity);
        Console.WriteLine(order.OrderDate);
        Console.WriteLine("--------");

        i++;
    }
}

//CustomerTest();

static void CustomerTest()
{
    CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

    foreach (var customer in customerManager.GetAll())
    {
        Console.WriteLine(customer.ContactName);

    }
}
