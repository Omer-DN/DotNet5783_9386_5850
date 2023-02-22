using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class Config
    {
        public int lastProductId { get; set; } = 100000;
        public int lastOrderId { get; set; } = 100000;
        public int lastOrderItemId { get; set; } = 100000;
    }
}
