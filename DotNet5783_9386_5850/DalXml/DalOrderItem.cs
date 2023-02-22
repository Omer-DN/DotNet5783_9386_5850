using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal;
using DalApi;
using DO;
using static Dal.XmlDataSource;


internal class DalOrderItem : IOrderItem
{
    public int Add(OrderItem Orderitem)
    {
        List<OrderItem> listOfOrderItems = loadListOfOrderItems();
        if (listOfOrderItems.Any(i => i.ID == Orderitem.ID))
        {
            throw new Exception("This order item already exists in the order items list");
        }

        Orderitem.ID = getlastOrderItemId();
        var newOrderItem = new OrderItem
        {
            ID = Orderitem.ID,
            ProductID = Orderitem.ProductID,
            OrderID = Orderitem.OrderID,
            Price = Orderitem.Price,
            Amount = Orderitem.Amount
        };

        listOfOrderItems.Add(newOrderItem);
        saveListOfOrderItems(listOfOrderItems);
        return newOrderItem.ID;

    }

    public void Delete(int id)
    {
        List<OrderItem> listOfOrderItems = loadListOfOrderItems();
        bool isRemoved = listOfOrderItems.Remove(listOfOrderItems.FirstOrDefault(x => x.ID == id));
        if (!isRemoved)
            throw new Exception("This order item does not exist in the system");
        saveListOfOrderItems(listOfOrderItems);
    }

    public void Update(OrderItem Orderitem)
    {
        List<OrderItem> listOfOrderItems = loadListOfOrderItems();
        bool found = false;
        foreach (OrderItem i in listOfOrderItems.ToList())
            if (i.ID == Orderitem.ID)
            {
                found = true;
                var index = listOfOrderItems.FindIndex(i => i.ID == Orderitem.ID);
                listOfOrderItems[index] = Orderitem;
            }
        if (found == false) throw new Exception("This order item does not exist in the system");
        saveListOfOrderItems(listOfOrderItems);
    }


    public OrderItem Get(int id)
    {
        List<OrderItem> listOfOrderItems = loadListOfOrderItems();
        foreach (OrderItem i in listOfOrderItems)
            if (i.ID == id)
                return i;
        throw new Exception("This order item does not exist in the system");
    }

    public OrderItem GetCond(int id, Func<OrderItem, bool>? condition)
    {
        List<OrderItem> listOfOrderItems = loadListOfOrderItems();
        foreach (OrderItem i in listOfOrderItems)
            if (i.ID == id && condition!(i))
                return i;
        throw new Exception("This order item does not exist in the system");
    }

    // return a List of current order items in all the orders of the store
    public IEnumerable<OrderItem> GetList(Func<OrderItem, bool>? condition)
    {
        List<OrderItem> listOfOrderItems = loadListOfOrderItems();
        return (condition == null) ?
    listOfOrderItems.ToList() :
    listOfOrderItems.Where(x => condition(x)).ToList();

    }
}

