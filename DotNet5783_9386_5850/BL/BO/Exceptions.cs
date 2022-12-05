using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class productOutOfStock : Exception
    {
        public productOutOfStock (string error) : base(error) { }


    }
}
