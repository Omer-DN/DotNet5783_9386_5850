

using DO;
using static Dal.DataSource;

namespace Dal;

public class DalOrder
{
    public Order Create(string costumerName, string costumerEmail, string costumerAdress, DateTime OrderDate, DateTime ShipDate, DateTime DeliveryDate)
    {
        Order newOrder = new Order();
        newOrder.CostumerName = costumerName;
        newOrder.CostumerEmail = costumerEmail;
        newOrder.CostumerAdress = costumerAdress;
        newOrder.OrderDate = OrderDate;
        newOrder.ShipDate = ShipDate;
        newOrder.DeliveryDate = DeliveryDate;
        return newOrder;
    }

    public int AddOrder(Order order)
    {
        for (int i = 0; i < Config.numOfOrders; i++)
            if (arrayOfProducts[i].ID == order.ID)
                throw new Exception("This product already exists in the system");
        order.ID = DataSource.Config.getlastOrderId();
        DataSource.arrayOfOrders[DataSource.Config.numOfOrders++] = order;
        return order.ID;
    }

    public void DeleteOrder(int id)
    {
        for (int i = 0; i < Config.numOfOrders; i++)
        {
            if (arrayOfProducts[i].ID == id)
            {

                for (int j = i; j < Config.numOfOrders - 1; j++)
                {
                    arrayOfOrders[j] = arrayOfOrders[j + 1];
                }
                Config.numOfOrders--;
                return;
            }
        }
        throw new Exception("This order does not exist in the system");
    }

    public void UpdateOrder(Order order)
    {
        for (int i = 0; i < Config.numOfOrders; i++)
            if (arrayOfOrders[i].ID == order.ID)
                arrayOfOrders[i] = order;
        throw new Exception("This order does not exist in the system");

    }

    public Order GetOrder(int id)
    {
        for (int i = 0; i < Config.numOfOrders; i++)
            if (arrayOfOrders[i].ID == id)
                return arrayOfOrders[i];
        throw new Exception("This order does not exist in the system");

    }

    // return a List of current orders in the store
    public Order[] GetOrderList()
    {
        Order[] orders = new Order[Config.numOfOrders];
        for(int i = 0; i < Config.numOfOrders; i++)
        {
            orders[i] = arrayOfOrders[i];
        }
        return orders;
    }


}
