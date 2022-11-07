

using DO;
using static DO.Enums;

namespace Dal;

internal class DataSource
{
    readonly Random rand = new Random();
    internal static Product[] arrayOfproducts = new Product[50];
    internal static Order[] arrayOforders = new Order[100];
    internal static OrderItem[] arrayOrderItems = new OrderItem[200];
    internal static int[] vegetablesPrices = {5,3,20,15,6, 12, 9, 7, 8,5};

    static internal class Config
    {
        static internal int numOfProducts = 0;
        static internal int numOfOrders = 0;
        static internal int numOfOrdersItems = 0;
    }

    public static void InitializeProduct(Product parameter)
    {

        Random r = new Random();
        bool flag = false;
        while (flag == false)
        {
            flag = true;
            parameter.ID = r.Next(100000, 1000000);
            for (int i = 0; i < Config.numOfProducts; i++)
            {
                if (arrayOfproducts[i].ID == parameter.ID)
                {
                    flag = false;
                }
            }
        }
        parameter.Category = (Category)r.Next(0, 5);
        switch (parameter.Category)
        {
            case Category.vegetables:
                int number = r.Next(0, 10);
                parameter.Name = "" + (vegetables)number;
                #// parameter.Price = (double)Pricesvegetables.(parameter.Name); 
                break;
            case Category.Meat:
                parameter.Name=""+(Meat)r.Next(0, 6);
                //parameter.Price = (double)Pricesvegetables.(parameter.Name);
                break;
            case Category.Legumes:
                parameter.Name ="" +(Legumes)r.Next(0,4);
                //parameter.Price = (double)PricesLegumes.(parameter.Name);
                break;
            case Category.DairyProducts:
                parameter.Name = "" + (DairyProducts)r.Next(0, 5);
                //parameter.Price = (double)Pricesvegetables.(parameter.Name);
                break;
            case Category.CleanProducts:
                parameter.Name = "" + (CleanProducts)r.Next(0, 5);
                //parameter.Price = (double)PricesCleanProducts.(parameter.Name);

                break;


        }
        parameter.InStock = r.Next(1, 101);
    }


    public static void InitializeOrder(Order parameter)
    {
        Random r = new Random();
        bool flag = false;
        while (flag == false)
        {
            flag = true;
            parameter.ID = r.Next(100000, 1000000);
            for (int i = 0; i < Config.numOfOrders; i++)
            {
                if (arrayOforders[i].ID == parameter.ID)
                {
                    flag = false;
                }
            }
        }
        parameter.CostumerName = "" + (CostumerNames)r.Next(0,10);
        parameter.CostumerEmail = parameter.CostumerName + "@gmail.com";
        parameter.CostumerAdress =""+ (CostumerAdress)r.Next(0,10);
        parameter.OrderDate = DateTime.MinValue;
        parameter.ShipDate = parameter.OrderDate.AddDays(r.Next(0, 7));
        parameter.DeliveryDate = parameter.ShipDate.AddDays(r.Next(0, 10));
    }


    public static void InitializeOrderItem(OrderItem parameter)
    {
        Random r = new Random();
        int number = r.Next(0, Config.numOfOrders);
        parameter.OrderID = arrayOforders[number].ID;
        number = r.Next(0, Config.numOfProducts);
        parameter.ProductID = arrayOfproducts[number].ID;
        parameter.Price = arrayOfproducts[number].Price;
        parameter.Amount = r.Next(1, 6);
    }

    public static void s_Initialize()
    {

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
    