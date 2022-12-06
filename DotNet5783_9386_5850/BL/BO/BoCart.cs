
namespace BO
{
    /// <summary>
    /// Main logical entity of the shopping cart Cart - 
    /// for the shopping cart management screen and order confirmation
    /// </summary>
    public class BoCart
    {
        public string? CostumerName { get; set; }
        public string? CostumerEmail { get; set; }
        public string? CostumerAdress { get; set; }
        public List<BoOrderItem>?  Items { get; set; }
        public double TotalPrice { get; set; }
        public override string ToString()
        {
            return
            $@"
            Costumer Name - {CostumerName} 
            Costumer Email - {CostumerEmail}
            Costumer Adress - {CostumerAdress}
            List Of Items: {Items} 
            Total Price: {TotalPrice}";
        }

    }
}
