
using static DO.Enums;
using System.Xml.Linq;

namespace DO;

public struct OrderItem
{
    public int ProductID { get; set; }
    public int OrderID { get; set; }
    public double Price { get; set; }
    public int Amount { get; set; }

    public override string ToString()
    {
        return
        $@"Product ID = {ProductID}
        OrderID - {OrderID} 
        Price: {Price}
        Amount: {Amount}";
    }

}