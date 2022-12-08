

namespace BlApi
{
    public interface IBoCart
    {
        public IEnumerable<BO.BoOrderForList> GetListOfOrders();
        public BO.BoOrder AddItem(BO.BoCart item, int id);
        public BO.BoOrder UpdateItem(BO.BoCart item, int amount, int id);
        public BO.BoOrder OrderConfirmation(BO.BoCart item, int id);


    }
}
