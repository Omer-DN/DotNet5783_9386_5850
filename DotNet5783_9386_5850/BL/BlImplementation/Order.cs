using BL.BO;



namespace BlImplementation
{
    internal class Order : BlApi.IOrder
    {
        public IEnumerable<BoOrder?> GetOrders();
    }
}
