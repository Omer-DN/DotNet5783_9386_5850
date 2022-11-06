

using DO;

namespace Dal;

internal class DataSource
{
    readonly Random rand = new Random();
    internal static Product[] arrayOfproducts = new Product[50];
    internal static Order[] arrayOforders = new Order[100];
    internal static OrderItem[] arrayOrderItems = new OrderItem[200];


    static internal class Config
    {
        static internal int numOfProducts = 0;
        static internal int numOfOrders = 0;
        static internal int numOfOrdersItems = 0;
    }

    /*
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
                numOfOrdersItems--;
            }
        }
    }

    public static void UpdateProduct(Product product)
    {
        foreach(Product i in arrayOfproducts)
        {
            if(i.ID == product.ID)
            {

            }
            throw new Exception("This product does not exist in the system");


        }
    }
    */
}
    