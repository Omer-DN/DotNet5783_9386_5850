

namespace BlApi
{
    public interface IBoCart
    {
        public BO.BoCart AddItem(BO.BoCart cart, int id);
        public BO.BoCart UpdateItem(BO.BoCart cart, int amount, int id);
        public void OrderConfirmation(BO.BoCart cart, string name, string email, string adress);


    }
}
