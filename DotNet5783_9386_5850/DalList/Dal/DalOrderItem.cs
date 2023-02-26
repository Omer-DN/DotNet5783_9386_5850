
using DO;
using static DalList.DataSource;
using DalApi;
using System.Linq;
using DalList;

namespace Dal;
/// <summary>
/// Implementation of the ICRUD methods for the OrderItem entitie
/// </summary>
public class DalOrderItem:IOrderItem
{
    //Method to add Order Item to the Store data
    public int Add(OrderItem Orderitem)
    {
        var orderItemIds = listOfOrderItems
            .GroupBy(x => x.ID)
            .Select(g => g.First())
            .Select(i => i.ID)
            .OrderBy(id => id)
            .ToList();

        if (listOfOrderItems.Count == 0)
            DataSource.lastOrderId++;
        else
            DataSource.lastOrderId = orderItemIds.Max() + 1;

        var newOrderItem = new OrderItem
        {
            ID = lastOrderItemId,
            ProductID = Orderitem.ProductID,
            OrderID = Orderitem.OrderID,
            Price = Orderitem.Price,
            Amount = Orderitem.Amount
        };

        listOfOrderItems.Add(newOrderItem);

        return newOrderItem.ID;
    }

    //Method to delete Order Item from the Store data
    public void Delete(int id)
    {
        bool isRemoved = listOfOrderItems.Remove(listOfOrderItems.FirstOrDefault(x => x.ID == id));
        if (!isRemoved)
            throw new Exception("This order item does not exist in the system");

    }

    //Method to update Order Item from the Store data
    public void Update(OrderItem Orderitem)
    {
        bool found = false;
        foreach (OrderItem i in listOfOrderItems.ToList())
            if (i.ID == Orderitem.ID)
            {
                found = true;
                var index = listOfOrderItems.FindIndex(i => i.ID == Orderitem.ID);
                listOfOrderItems[index] = Orderitem;
            }
        if(found == false) throw new Exception("This order item does not exist in the system");
    }

    //Method to get Order Item from the Store data
    public OrderItem Get(int id)
        {
            foreach (OrderItem i in listOfOrderItems)
                if (i.ID == id)
                    return i;
            throw new Exception("This order item does not exist in the system");
        }

    //Method to get Order Item from the Store data that hold specific condition 
    public OrderItem GetCond(int id, Func<OrderItem, bool>? condition)
    {
        foreach (OrderItem i in listOfOrderItems)
            if (i.ID == id && condition!(i))
                return i;
        throw new Exception("This order item does not exist in the system");
    }

    //Method to get Order Item list from the Store data that hold specific condition 
    public IEnumerable<OrderItem> GetList(Func<OrderItem, bool>? condition)
    {
        return (condition == null) ?
    listOfOrderItems.ToList() :
    listOfOrderItems.Where(x => condition(x)).ToList();

    }

}
