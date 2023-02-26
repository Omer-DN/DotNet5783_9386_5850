

using DO;
using static DalList.DataSource;
using DalApi;
namespace Dal;
/// <summary>
/// Implementation of the ICRUD methods for the Order entitie
/// </summary>
public class DalOrder : IOrder
{
    //Method to add order to the Store data
    public int Add(Order order)
    {
        if (listOfOrders.Any(x => x.ID == order.ID))
            throw new IdNotFound("This product already exists in the system");
        order.ID = getlastOrderId();
        listOfOrders.Add(order);
        return order.ID;
    }

    //Method to delete order from the Store data
    public void Delete(int id)
    {
        bool isRemoved = listOfOrders.Remove(listOfOrders.FirstOrDefault(x => x.ID == id));
        if (!isRemoved)
            throw new IdNotFound("This order does not exist in the system");

    }

    //Method to update order from the Store data
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

    //Method to get order from the Store data 
    public Order Get(int id)
    {
        foreach (Order i in listOfOrders)
            if (i.ID == id)
                return i;
        throw new Exception("This order does not exist in the system");
    }

    //Method to get order from the Store data that hold specific condition 
    public Order GetCond(int id, Func<Order, bool>? condition)
    {
        foreach (Order i in listOfOrders)
            if (i.ID == id && condition!(i))
                return i;
        throw new Exception("This order does not exist in the system");
    }

    // return a List of current orders in the store
    public IEnumerable<Order> GetList(Func<Order, bool>? condition)
    {
        return (condition == null) ?
        listOfOrders.ToList() :
        listOfOrders.Where(x => condition(x)).ToList();
    }

}
