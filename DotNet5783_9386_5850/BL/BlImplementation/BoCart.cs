using BlApi;

namespace BlImplementation
{
    internal class BoCart : IBoCart
    {
        private DalApi.IDal Dal ;
        public BO.BoCart addItem(BO.BoCart cart, int id)
        {
            bool findID = false;
            foreach (var item in cart.Items)
            {
                if (item.ID == id)
                {
                    DO.Product check_product = Dal.Product.Get(id);
                    if (check_product.InStock != 0)
                    {
                        findID = true;
                        item.Amount++;
                        item.TotalPrice += check_product.Price;
                        cart.TotalPrice += check_product.Price;
                        break;
                    }
                    else
                        throw new BO.productOutOfStock("this product arn't in the stock");
                }
            }
            if (!findID)
            {
                DO.Product check_product = Dal.Product.Get(id);
                if(check_product.InStock != 0)
                {
                    BO.BoOrderItem newItem = new BO.BoOrderItem();
                    newItem.ProductID =id;
                    newItem.Amount = 1;
                    newItem.ID = BO.BoOrderItem.lastID++;
                    newItem.Name = check_product.Name;
                    newItem.Price = check_product.Price;
                    newItem.TotalPrice = newItem.Price * newItem.Amount;
                    cart.TotalPrice += check_product.Price;

                }
            }
            return cart;
        }        
    }
    
}
