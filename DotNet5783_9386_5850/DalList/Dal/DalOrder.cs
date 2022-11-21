

using DO;
using static Dal.DataSource;
using DalApi;
namespace Dal;

internal class DalOrder : IOrder
{
    public int Add(Order order)
    {
        /*for (int i = 0; i < Config.numOfOrders; i++)
            if (arrayOfProducts[i].ID == order.ID)
                throw new Exception("This product already exists in the system");
        order.ID = DataSource.Config.getlastOrderId();
        DataSource.arrayOfOrders[DataSource.Config.numOfOrders++] = order;*/
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

                /*for (int j = i; j < Config.numOfOrders - 1; j++)
                {
                    arrayOfOrders[j] = arrayOfOrders[j + 1];
                }
                Config.numOfOrders--;*/
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
        /*foreach (Order i in listOfOrders)
            if (i.ID == order.ID)
            {
                //arrayOfOrders[i] = order;
                var temp = listOfOrders.Find(i => i.ID == order.ID);
            }
        throw new Exception("This order does not exist in the system");
               */
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
        /*Order[] orders = new Order[Config.numOfOrders];
        for(int i = 0; i < Config.numOfOrders; i++)
        {
            orders[i] = arrayOfOrders[i];
        }
        return orders;*/
    }


}
