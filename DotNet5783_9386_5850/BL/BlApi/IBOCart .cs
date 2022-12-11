

namespace BlApi
{
    public interface IBoCart
    {
        public IEnumerable<BO.BoCart> GetBoCarts();
        public BO.BoCart AddItem(BO.BoCart cart, int id);
        public BO.BoOrder UpdateItem(BO.BoCart cart, int amount, int id);
        public BO.BoCart OrderConfir(BO.BoCart cart, string name, string email, string adress);


    }
}
