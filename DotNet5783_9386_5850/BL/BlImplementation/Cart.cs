using BL.BO;
using BO;

namespace BlImplementation
{
    internal class Cart : BlApi.ICart
    {
        public IEnumerable<BoCart?> GetCarts();
    }
}
