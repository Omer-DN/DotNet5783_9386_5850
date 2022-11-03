
using static DO.Enums;
using System.Diagnostics;

namespace DO;
/// <summary>
/// Structure for order data
/// </summary>
public struct Order
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string DeliveryAdress { get; set; }
    public DateTime OrderCreationDate { get; set; }
    public DateTime ShippingDate { get; set; } 
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
}