
namespace BlApi
{
    public interface IBoOrder
    {
        public IEnumerable<BO.BoOrderForList?>? GetListOfOrders();
        public BO.BoOrder GetOrder(int id);
        public BO.BoOrder UpdateShipping(int id);
        public BO.BoOrder UpdateDelivery(int id);
        public BO.BoOrderTracking Track(int id);



    }
}
