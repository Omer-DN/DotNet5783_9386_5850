
using DalApi;
namespace Dal
{
    /// <summary>
    /// Class that implement the IDal Interface and create an Object of an entitie
    /// </summary>
    internal sealed class DalList : IDal

    {
        public IProduct Product => new DalProduct();
        public IOrder Order => new DalOrder();
        public IOrderItem OrderItem => new DalOrderItem();
        public static IDal Instance { get; } = new DalList();

    }
}
