

using DO;
using static Dal.DataSource;

namespace Dal;

public class DalOrder
{
    public static Order Create(int id, string costumerName, string costumerEmail, string costumerAdress, DateTime OrderDate, DateTime ShipDate, DateTime DeliveryDate)
    {
        Order newOrder = new Order();
        newOrder.ID = id;
        newOrder.CostumerName = costumerName;
        newOrder.CostumerEmail = costumerEmail;
        newOrder.CostumerAdress = costumerAdress;
        newOrder.OrderDate = OrderDate;
        newOrder.ShipDate = ShipDate;
        newOrder.DeliveryDate = DeliveryDate;
        return newOrder;
    }

    public static int AddOrder(Order order)
    {
        foreach (Order i in DataSource.arrayOfOrders)
        {
            if (order.ID == i.ID)
                throw new Exception("This product already exists in the system");
        }
        DataSource.arrayOfOrders[DataSource.Config.numOfProducts++] = order;
        return order.ID;
    }

    public static void DeleteOrder(Order order)
    {
        foreach (Order i in arrayOfOrders)
        {
            if (i.ID == order.ID)
            {
                order.ID = 0;
                order.CostumerName = "";
                order.CostumerEmail = "";
                order.CostumerAdress = "";
                Config.numOfOrders--;

            }
        }
    }
}
