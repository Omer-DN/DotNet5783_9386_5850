using BL.BO;
using BO;

namespace BlImplementation
{
    internal class BoCart : BlApi.ICart
    {
        public IEnumerable<BO.BoCart?> GetCarts();
    }
}
