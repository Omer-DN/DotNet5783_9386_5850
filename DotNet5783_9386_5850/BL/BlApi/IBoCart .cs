

namespace BlApi
{
    public interface IBoCart
    {
        public IEnumerable<BO.BoCart> GetBoCarts();
        public BO.BoOrder AddItem(BO.BoCart item, int id);
        public BO.BoOrder UpdateItem(BO.BoCart item, int amount, int id);
        public BO.BoOrder OrderConfirmation(BO.BoCart item, string? name, string? email, string? adress);


    }
}
