

namespace BlApi
{
    public interface IBoProduct
    {
        public IEnumerable<BO.BoProductForList> CondGetListOfProducts(Func<DO.Product, bool>? condition);
        public IEnumerable<BO.BoProductForList?> GetListOfProducts();
        public BO.BoProduct ManagerGetProduct(int id);
        public BO.BoProductItem BuyerGetProduct(BO.BoCart cart, int id);
        public void AddProduct(BO.BoProduct product);
        public void DeleteProduct(int id);
        public void UpdateProduct(BO.BoProduct product);
        public BO.BoProduct Create(int id, string name, double price, BO.Enums.Category category, int instock);


    }
}
