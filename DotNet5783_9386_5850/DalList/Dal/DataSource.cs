

using DO;
using static DO.Enums;

namespace Dal;

internal class DataSource
{
    readonly Random rand = new Random();
    internal static Product[] arrayOfProducts = new Product[50];
    internal static Order[] arrayOfOrders = new Order[100];
    internal static OrderItem[] arrayOfOrderItems = new OrderItem[200];
    

    static internal class Config
    {
        static internal int numOfProducts = 0;
        static internal int numOfOrders = 0;
        static internal int numOfOrdersItems = 0;
        static internal int lastProductId = 100000;
        static internal int lastOrderId = 100000;
        internal static int numOfOrderItems;

        static internal int getlastProductId()
        {
            return lastProductId++;
        }
        static internal int getlastOrderId()
        {
            return lastOrderId++;
        }
    }

    static  DataSource()
    {
        s_initialize();
    }

    public static void InitializeProduct(Product parameter)
    {

        Random r = new Random();
        parameter.ID = Config.getlastProductId();
        /*        bool flag = false;
                while (flag == false)
                {
                    flag = true;
                    parameter.ID = r.Next(100000, 999999);
                    for (int i = 0; i < Config.numOfProducts; i++)
                    {
                        if (arrayOfProducts[i].ID == parameter.ID)
                        {
                            flag = false;
                        }
                    }
                }
        */

        parameter.Category = (Category)r.Next(0, 5);
        switch (parameter.Category)
        {
            case Category.vegetables:
                int number = r.Next(0, 10);
                parameter.Name = "" + (Vegetables)number;
                //I created a new variable of type vegetable,
                //and it contains the index of that vegetable from "enum" vegetables.
                Vegetables otherVeg = (Vegetables)number;
                //The price of the item is equal to the value of that vegetable,
                //according to the index given in the new variable
                parameter.Price = (double)otherVeg;
                break;

            case Category.Meat:
                number = r.Next(0, 6);
                parameter.Name=""+(Meat)r.Next(0, 6);
                Meat otherMeat = (Meat)number;
                parameter.Price = (double)otherMeat;
                break;

            case Category.Legumes:
                number = r.Next(0, 4);
                parameter.Name ="" +(Legumes)r.Next(0,4);
                Legumes otherLegu = (Legumes)number;
                parameter.Price = (double)otherLegu;
                break;

            case Category.DairyProducts:
                number = r.Next(0, 5);
                parameter.Name = "" + (DairyProducts)r.Next(0, 5);
                DairyProducts otherDairy = (DairyProducts)number;
                parameter.Price = (double)otherDairy;
                break;
            case Category.CleanProducts:
                number = r.Next(0, 5);
                parameter.Name = "" + (CleanProducts)r.Next(0, 5);
                CleanProducts otherClean = (CleanProducts)number;
                parameter.Price = (double)otherClean;

                break;
        }
        parameter.InStock = r.Next(1, 101);
    }


    public static void InitializeOrder(Order parameter)
    {
        Random r = new Random();
        parameter.ID = Config.getlastOrderId();
        /*
        bool flag = false;
        while (flag == false)
        {
            flag = true;
            parameter.ID = r.Next(100000, 1000000);
            for (int i = 0; i < Config.numOfOrders; i++)
            {
                if (arrayOfOrders[i].ID == parameter.ID)
                {
                    flag = false;
                }
            }
        }
        */
        Config.lastOrderId = parameter.ID;
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
        parameter.OrderID = arrayOfOrders[number].ID;
        number = r.Next(0, Config.numOfProducts);
        parameter.ProductID = arrayOfProducts[number].ID;
        parameter.Price = arrayOfProducts[number].Price;
        parameter.Amount = r.Next(1, 6);
    }
    public static void s_initialize()
    {
        for (int i = 0; i < 50; i++)
        {
            Product newProduct = new Product();
            InitializeProduct(newProduct);
            arrayOfProducts[i] = newProduct;
        }
        for (int i = 0; i < 40; i++)
        {
            Order newOrder = new Order();
            InitializeOrder(newOrder);
            arrayOfOrders[i] = newOrder;
        }
        for (int i = 0; i < 100; i++)
        {
            OrderItem newOrderItem = new OrderItem();
            InitializeOrderItem(newOrderItem);
            arrayOfOrderItems[i] = newOrderItem;
        }
    }

}


