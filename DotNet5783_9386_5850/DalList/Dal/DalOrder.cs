

using DO;
using static DalList.DataSource;
using DalApi;
namespace DalList;

public class DalOrder : IOrder
{
    public int Add(Order order)
    {

        foreach (Order i in listOfOrders)
        {
            if (i.ID == order.ID)
                throw new idNotFound("This product already exists in the system");
        }
        order.ID = getlastOrderId();
        listOfOrders.Add(order);
        return order.ID;
    }

    public void Delete(int id)
    {
        foreach (Order i in listOfOrders)
        {
            if (i.ID == id)
            {
               listOfOrders.Remove(i);
               return;
            }
        }
        throw new idNotFound("This order does not exist in the system");
    }

    public void Update(Order order)
    {
        if(listOfOrders.Exists(x=> x.ID == order.ID))
        {
            var index = listOfOrders.FindIndex(i => i.ID == order.ID);
            listOfOrders[index] = order;
            return;
        }
        throw new Exception("This order does not exist in the system");
    }

    public Order Get(int id)
    {
        foreach (Order i in listOfOrders)
            if (i.ID == id)
                return i;
        throw new Exception("This order does not exist in the system");

    }

    // return a List of current orders in the store
    public IEnumerable<Order> GetList()
    {
        List<Order> orders = new List<Order>();
        foreach(Order i in listOfOrders)
        {
            orders.Add(i);
        }
        return orders;

    }


}
