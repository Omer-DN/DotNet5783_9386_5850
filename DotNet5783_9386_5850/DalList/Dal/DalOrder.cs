

using DO;

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
}
