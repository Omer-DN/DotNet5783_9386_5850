

using DO;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Linq;
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

    public static void Deleteproduct(Product product)
    {
        foreach (Product i in arrayOfproducts)
        {
            if (i.Id == product.Id)
            {
                product.Id = 0;
                product.Name = "";
                product.Price = 0;
                product.Category = 0;
                product.InStock = 0;
            }
        }
    }
    public static void DeleteOrder(Order order)
    {
        foreach (Order i in arrayOforders)
        {
            if(i.Id == order.Id)
            {
                order.Id = 0;
                order.CostumerName = "";
                order.CostumerEmail = "";
                order.CostumerAdress = "";
            }
        }
    }
    public static void DeleteOrderItem(OrderItem orderItem)
    {
        foreach (OrderItem i in arrayOrderItems)
        {
            if (i.ProductID == orderItem.ProductID)
            {
                orderItem.ProductID = 0;
                orderItem.OrderID = 0;
                orderItem.Price = 0;
                orderItem.Amount = 0;
            }
        }
    }
}
