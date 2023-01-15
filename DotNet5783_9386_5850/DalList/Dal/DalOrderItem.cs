
using DO;
using static DalList.DataSource;
using DalApi;

namespace Dal;

public class DalOrderItem:IOrderItem
{
    public int Add(OrderItem Orderitem)
    {
        foreach (OrderItem i in listOfOrderItems)
            if (i.ID == Orderitem.ID)
                throw new Exception("This order item already exists in the order items list");
        Orderitem.ID = getlastOrderItemId();
        listOfOrderItems.Add(Orderitem);
        return Orderitem.ID;
    }

    public void Delete(int id)
    {
        foreach (OrderItem i in listOfOrderItems)
        {
            if (i.ID == id)
            {
                listOfOrderItems.Remove(i);
                return;
            }
        }
        throw new Exception("This order item does not exist in the system");
    }

    public void Update(OrderItem Orderitem)
    {
        foreach (OrderItem i in listOfOrderItems)
            if (i.ID == Orderitem.ID)
            {
                var index = listOfOrderItems.FindIndex(i => i.ID == Orderitem.ID);
                listOfOrderItems[index] = Orderitem;
            }
        throw new Exception("This order item does not exist in the system");
    }

    public OrderItem Get(int id)
    {
        foreach (OrderItem i in listOfOrderItems)
            if (i.ID == id)
                return i;
        throw new Exception("This order item does not exist in the system");
    }

    public OrderItem GetCond(int id, Func<OrderItem, bool>? condition)
    {
        foreach (OrderItem i in listOfOrderItems)
            if (i.ID == id && condition(i))
                return i;
        throw new Exception("This order item does not exist in the system");
    }

    // return a List of current order items in all the orders of the store
    public IEnumerable<OrderItem> GetList(Func<OrderItem, bool>? condition)
    {
        List<OrderItem> orderItems = new List<OrderItem>();
        if (condition == null)
        {
            foreach (OrderItem i in listOfOrderItems)
            {
                orderItems.Add(i);
            }
        }
        else
        {
            orderItems = listOfOrderItems.FindAll(x => condition(x));
        }
        return orderItems;
    }

}
