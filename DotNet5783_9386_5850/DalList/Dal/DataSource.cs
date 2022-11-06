

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
    public static int AddProduct(Product product)
    {
        arrayOforders[numOfProducts] = product;
        numOfProducts++;
        return product.Id;
    }

    public static void AddOrder(Order order)
    {
        arrayOforders[numOfOrders] = order;
        numOfOrders++;
    }

    public static void AddOrderItem(OrderItem orderItem)
    {
        arrayOrderItems[numOfOrdersItems] = orderItem;
        numOfOrdersItems++;
    }

}
