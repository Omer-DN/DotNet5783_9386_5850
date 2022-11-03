
using static DO.Enums;
using System.Diagnostics;

namespace DO;
/// <summary>
/// Structure for order data
/// </summary>
public struct Order
{
    public int Id { get; set; }
    public string costumerName { get; set; }
    public string costumerEmail { get; set; }
    public string costumerAdress { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime ShipDate { get; set; } 
    public DateTime DeliveryDate  { get; set; }

    public override string ToString()
    {
        return
        $@"Order ID = {Id}
        Name = {Name} 
        Email - {Email} 
        Delivery Adress: {DeliveryAdress}
        Order Creation: {OrderCreationDate}
        Shipping Date: {ShippingDate}
        Delivery Date: {DeliveryDate}";
    }

    public static implicit operator Order(Product v)
    {
        throw new NotImplementedException();
    }
}