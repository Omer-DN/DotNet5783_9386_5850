
using DO;
using static DalList.DataSource;
using DalApi;

namespace Dal;

public class DalOrderItem:IOrderItem
{
    public int Add(OrderItem Orderitem)
    {
        var orderItemIds = listOfOrderItems
            .GroupBy(x => x.ID)
            .Select(g => g.First())
            .Select(i => i.ID)
            .OrderBy(id => id)
            .ToList();

        var lastOrderItemId = orderItemIds.Max() + 1;

        var newOrderItem = new OrderItem
        {
            ID = lastOrderItemId,
            // set other properties here
        };

        listOfOrderItems.Add(newOrderItem);

        return newOrderItem.ID;

    }
    //{
    //    foreach (OrderItem i in listOfOrderItems)
    //        if (i.ID == Orderitem.ID)
    //            throw new Exception("This order item already exists in the order items list");
    //Orderitem.ID = getlastOrderItemId();
    //listOfOrderItems.Add(Orderitem);
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
    {
        var orderItemIndex = listOfOrderItems.FindIndex(i => i.ID == Orderitem.ID);
        if (orderItemIndex != -1)
        {
            listOfOrderItems[orderItemIndex] = Orderitem;
            return;
        }
        throw new Exception("This order item does not exist in the system");

    }
    //{
    //    foreach (OrderItem i in listOfOrderItems)
    //        if (i.ID == Orderitem.ID)
    //        {
    //            var index = listOfOrderItems.FindIndex(i => i.ID == Orderitem.ID);
    //listOfOrderItems[index] = Orderitem;
    //        }
    //    throw new Exception("This order item does not exist in the system");
    //}

    public OrderItem Get(int id)
    {
        var orderItem = listOfOrderItems.FirstOrDefault(i => i.ID == id);
        if (orderItem != null)
            return orderItem;
        else
            throw new Exception("This order item does not exist in the system");
    }
    //{
    //    foreach (OrderItem i in listOfOrderItems)
    //        if (i.ID == id)
    //            return i;
    //    throw new Exception("This order item does not exist in the system");
    //}

    public OrderItem GetCond(int id, Func<OrderItem, bool>? condition)
    {
        var orderItem = listOfOrderItems.Where(i => i.ID == id).FirstOrDefault(condition);
        if (orderItem != null)
            return orderItem;
        else
            throw new Exception("This order item does not exist in the system");

    }
    //{
    //    foreach (OrderItem i in listOfOrderItems)
    //        if (i.ID == id && condition(i))
    //            return i;
    //    throw new Exception("This order item does not exist in the system");
    //}

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
