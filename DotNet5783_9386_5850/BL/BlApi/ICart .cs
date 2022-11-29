using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.BO;
using BO;
///
namespace BlApi
{
    public interface ICart
    {
        public IEnumerable<BoCart> GetCarts()
        {
            return new List<BoCart>();
        }
    }
}
