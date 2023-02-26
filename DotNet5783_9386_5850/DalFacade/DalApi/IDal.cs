

namespace DalApi
{
    /// <summary>
    /// The Interface to create access to the data
    /// </summary>
    public interface IDal
    {
        public IProduct? Product { get; }
        public IOrder? Order { get; }
        public IOrderItem? OrderItem { get; }

    }
}
