

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

    public static void DeleteOrder(Order order)
    {
        foreach (Order i in arrayOforders)
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
