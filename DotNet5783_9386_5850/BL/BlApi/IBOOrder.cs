
namespace BlApi
{
    /// <summary>
    /// Class that make methods that Special only for the BoOrder entitie
    /// </summary>
    public interface IBoOrder
    {
        public IEnumerable<BO.BoOrderForList?>? GetListOfOrders();
        public BO.BoOrder GetOrder(int id);
        public BO.BoOrder UpdateShipping(int id);
        public BO.BoOrder UpdateDelivery(int id);
        public BO.BoOrderTracking Track(int id);

        public void UpdateOrder(BO.BoOrder order);

        public BO.BoOrder GetOldestOrder();



    }
}
