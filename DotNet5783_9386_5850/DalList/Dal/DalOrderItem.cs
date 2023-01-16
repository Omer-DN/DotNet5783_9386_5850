
using DO;
using static DalList.DataSource;
using DalApi;

namespace Dal;

public class DalOrderItem:IOrderItem
{
    public int Add(OrderItem Orderitem)
    {
        if (listOfOrderItems.Any(x => x.ID == Orderitem.ID))
            throw new Exception("This order item already exists in the order items list");
        Orderitem.ID = getlastOrderItemId();
        listOfOrderItems.Add(Orderitem);
        return Orderitem.ID;

    }
    //{
    //    foreach (OrderItem i in listOfOrderItems)
    //        if (i.ID == Orderitem.ID)
    //            throw new Exception("This order item already exists in the order items list");
    //    Orderitem.ID = getlastOrderItemId();
    //    listOfOrderItems.Add(Orderitem);
    //    return Orderitem.ID;
    //}

    public void Delete(int id)
    {
        bool isRemoved = listOfOrderItems.Remove(listOfOrderItems.FirstOrDefault(x => x.ID == id));
        if (!isRemoved)
            throw new Exception("This order item does not exist in the system");

    }
    //{
    //    foreach (OrderItem i in listOfOrderItems)
    //    {
    //        if (i.ID == id)
    //        {
    //            listOfOrderItems.Remove(i);
    //            return;
    //        }
    //    }
    //    throw new Exception("This order item does not exist in the system");
    //}

    public void Update(OrderItem Orderitem)
    //{
    //    var orderItem = listOfOrderItems.FirstOrDefault(x => x.ID == Orderitem.ID);
    //    if (orderItem == null)
    //        throw new Exception("This order item does not exist in the system");
    //    int index = listOfOrderItems.IndexOf(orderItem);
    //    listOfOrderItems[index] = Orderitem;

    //}
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
    //{
    //    var orderItem = listOfOrderItems.FirstOrDefault(x => x.ID == id);
    //    if (orderItem == null)
    //        throw new Exception("This order item does not exist in the system");
    //    return orderItem;

    //}
    {
        foreach (OrderItem i in listOfOrderItems)
            if (i.ID == id)
                return i;
        throw new Exception("This order item does not exist in the system");
}

public OrderItem GetCond(int id, Func<OrderItem, bool>? condition)
    //{
    //    var orderItem = listOfOrderItems.FirstOrDefault(x => x.ID == id && condition(x));
    //    if (orderItem == null)
    //        throw new Exception("This order item does not exist in the system");
    //    return orderItem;

    //}
    {
        foreach (OrderItem i in listOfOrderItems)
            if (i.ID == id && condition(i))
                return i;
        throw new Exception("This order item does not exist in the system");
    }

    // return a List of current order items in all the orders of the store
    public IEnumerable<OrderItem> GetList(Func<OrderItem, bool>? condition)
    {
        return (condition == null) ?
    listOfOrderItems.ToList() :
    listOfOrderItems.Where(x => condition(x)).ToList();

    }
    //{
    //    List<OrderItem> orderItems = new List<OrderItem>();
    //    if (condition == null)
    //    {
    //        foreach (OrderItem i in listOfOrderItems)
    //        {
    //            orderItems.Add(i);
    //        }
    //    }
    //    else
    //    {
    //        orderItems = listOfOrderItems.FindAll(x => condition(x));
    //    }
    //    return orderItems;
    //}

}
