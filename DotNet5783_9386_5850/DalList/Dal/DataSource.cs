

using DO;
using System.ComponentModel;
using static DO.Enums;

namespace Dal;

internal class DataSource
{
    readonly Random rand = new Random();
    static Product[] arrayOfproducts = new Product[50];
    static Order[] arrayOforders = new Order[100];
    static OrderItem[] arrayOrderItems = new OrderItem[200];
    private static int numOfProducts;
    private static int numOfOrders;
    private static int numOfOrdersItems;

    internal class Config
    {
        static int numOfProducts = 0;
        static int numOfOrders = 0;
        static int numOfOrdersItems = 0;
    }
    public static void AddProduct(int id, string name, double price, Category category, int instock)
    {
        Product newProduct = new Product();
        newProduct.Id = id;
        newProduct.Name = name;
        newProduct.Price = price;
        newProduct.Category = category;
        newProduct.InStock = instock;
        arrayOforders[numOfProducts] = newProduct;
        numOfProducts++;
    }

    public static void AddOrder(int id, string costumerName, string costumerEmail, string costumerAdress, DateTime OrderDate, DateTime ShipDate, DateTime DeliveryDate)
    {
        Order newOrder = new Order();
        newOrder.Id = id;
        newOrder.costumerName = costumerName;
        newOrder.costumerEmail = costumerEmail;
        newOrder.costumerAdress = costumerAdress;
        newOrder.OrderDate = OrderDate;
        newOrder.ShipDate = ShipDate;
        newOrder.DeliveryDate = DeliveryDate;
        arrayOforders[numOfOrders] = newOrder;
        numOfOrders++;
    }

    public static void AddOrderItem(int ProductID, int OrderID, double Price, int Amount)
    {
        OrderItem newOrderItem = new OrderItem();
        newOrderItem.ProductID = ProductID;
        newOrderItem.OrderID = OrderID;
        newOrderItem.Price = Price;
        newOrderItem.Amount = Amount;
        arrayOrderItems[numOfOrdersItems] = newOrderItem;
        numOfOrdersItems++;
    }
}
