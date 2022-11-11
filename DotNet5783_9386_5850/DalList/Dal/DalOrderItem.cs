
using DO;
using System.Diagnostics;
using static Dal.DataSource;

namespace Dal;

public class DalOrderItem
{
    public static OrderItem Create(int ProductID, int OrderID, double Price, int Amount)
    {
        OrderItem newOrderItem = new OrderItem();
        newOrderItem.ProductID = ProductID;
        newOrderItem.OrderID = OrderID;
        newOrderItem.Price = Price;
        newOrderItem.Amount = Amount;
        return newOrderItem;
    }

    public static int AddOrderItem(OrderItem Orderitem)
    {
        for (int i = 0; i < Config.numOfOrdersItems; i++)
            if ((arrayOfOrderItems[i].ProductID == Orderitem.ProductID)&&(arrayOfOrderItems[i].OrderID == Orderitem.OrderID))
                throw new Exception("This product already exists in the order items list");
        DataSource.arrayOfOrderItems[DataSource.Config.numOfOrdersItems++] = Orderitem;
        return Orderitem.ProductID;
    }

    public static void DeleteOrderItem(OrderItem Orderitem)
    {
        for (int i = 0; i < Config.numOfOrderItems; i++)
        {
            if ((arrayOfOrderItems[i].ProductID == Orderitem.ProductID) && (arrayOfOrderItems[i].OrderID == Orderitem.OrderID))
            {

                for (int j = i; j < Config.numOfOrderItems - 1; j++)
                {
                    arrayOfOrderItems[j] = arrayOfOrderItems[j + 1];
                }
                Config.numOfOrderItems--;
                return;
            }
        }
        throw new Exception("This order item does not exist in the system");
    }

    public static void UpdateOrderItem(OrderItem Orderitem)
    {
        for (int i = 0; i < Config.numOfOrderItems; i++)
            if ((arrayOfOrderItems[i].ProductID == Orderitem.ProductID) && (arrayOfOrderItems[i].OrderID == Orderitem.OrderID))
                arrayOfOrderItems[i] = Orderitem;
        throw new Exception("This order item does not exist in the system");

    }

    public static OrderItem GetOrderItem(int ProductID, int OrderID)
    {
        for (int i = 0; i < Config.numOfOrderItems; i++)
            if ((arrayOfOrderItems[i].ProductID == ProductID) && (arrayOfOrderItems[i].OrderID == OrderID))
                return arrayOfOrderItems[i];
        throw new Exception("This order item does not exist in the system");

    }

    // return a List of current order items in all the orders of the store
    public static OrderItem[] GetOrderItemList()
    {
        OrderItem[] OrderItems = new OrderItem[Config.numOfOrderItems];
        for (int i = 0; i < Config.numOfOrderItems; i++)
        {
            OrderItems[i] = arrayOfOrderItems[i];
        }
        return OrderItems;
    }
}
