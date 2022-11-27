using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static BO.Enums;

namespace BO
{
    public class BoOrderForList
    {
        public int ID { get; set; }
        public string CostumerName { get; set; }
        public OrderStatus Status { get; set; }
        public int AmountOfItems { get; set; }
        public double TotalPrice { get; set; }

        public override string ToString()
        {
            return
            $@"
            ID = {ID}
            Costumer Name: {CostumerName}
            Status: {Status} 
            Amount Of Items: {AmountOfItems}
            Total Price: {TotalPrice}";
        }

    }
}
