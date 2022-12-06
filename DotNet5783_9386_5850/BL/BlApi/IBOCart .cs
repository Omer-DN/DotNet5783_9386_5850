
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
