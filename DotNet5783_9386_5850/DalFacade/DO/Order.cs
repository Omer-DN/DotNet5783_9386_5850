


namespace DO;
/// <summary>
/// Structure for the order entitie
/// </summary>
public struct Order
{
    public int ID { get; set; }
    public string? CostumerName { get; set; }
    public string? CostumerEmail { get; set; }
    public string? CostumerAdress { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShipDate { get; set; } 
    public DateTime? DeliveryDate  { get; set; }

    public override string ToString()
    {
        return
        $@"Order ID = {ID}
        Name = {CostumerName} 
        Email - {CostumerEmail} 
        Delivery Adress: {CostumerAdress}
        Order Creation: {OrderDate}
        Shipping Date: {ShipDate}
        Delivery Date: {DeliveryDate}";
    }

    public static implicit operator Order(Product v)
    {
        throw new NotImplementedException();
    }
}