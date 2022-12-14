
namespace BO
{
    /// <summary>
    /// Main logical entity of the shopping cart Cart - 
    /// for the shopping cart management screen and order confirmation
    /// </summary>
    public class BoCart
    {
        public string? CustumerName { get; set; }
        public string? CustumerEmail { get; set; }
        public string? CustumerAdress { get; set; }
        public List<BoOrderItem?>?  Items { get; set; }
        public double TotalPrice { get; set; }
        public override string ToString()
        {
            return
            $@"
            Costumer Name - {CustumerName} 
            Costumer Email - {CustumerEmail}
            Costumer Adress - {CustumerAdress}
            List Of Items: {Items} 
            Total Price: {TotalPrice}";
        }

    }
}
