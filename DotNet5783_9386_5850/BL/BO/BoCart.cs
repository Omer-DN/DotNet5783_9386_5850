using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BO
{
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
