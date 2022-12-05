using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.BO;
using BO;

namespace BlApi
{
    public interface IBoCart
    {
        public IEnumerable<BoCart> GetCart()
        {
            return new List<BoCart>();
        } 
    }
}
