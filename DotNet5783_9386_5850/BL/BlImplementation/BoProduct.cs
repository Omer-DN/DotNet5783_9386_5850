using BlApi;
using DalList.Dal;
using DalApi;


namespace BlImplementation
{
    internal class BoProduct : IBoProduct
    {
        private DalApi.IDal Dal;

        public IEnumerable<BO.BoProductForList> GetListOfProducts()
        {
            IEnumerable <DO.Product> dataList = new List<DO.Product>();
            dataList = Dal.Product.GetList();
            List <BO.BoProductForList> newList= new List<BO.BoProductForList>();
            foreach (var item in dataList)
            {
                BO.BoProductForList newItem = new BO.BoProductForList();
                newItem.ID = item.ID;
                newItem.Name = item.Name;
                newItem.Price = item.Price;
                newItem.category = (BO.Enums.Category)item.Category;
                newList.Add(newItem);
            }
            return newList;
        }

        public BO.BoProduct ManagerGetProduct(int id)
        {
            BO.BoProduct newProduct = new BO.BoProduct();
            if (id>0)
            {
                newProduct.ID = Dal.Product.Get(id).ID;
                newProduct.Name = Dal.Product.Get(id).Name;
                newProduct.Price = Dal.Product.Get(id).Price;
                newProduct.InStock = Dal.Product.Get(id).InStock;
                newProduct.Category = (BO.Enums.Category)Dal.Product.Get(id).Category;
            }
            else
                throw new BO.WrongProductDetails("this ID is Wrong");
            return newProduct;
        }

        public BO.BoProductItem BuyerGetProduct(BO.BoCart cart,int id)
        {
            BO.BoProductItem newProductItem = new BO.BoProductItem();
            if(id>0)
            {
                newProductItem.Name = Dal.Product.Get(id).Name;
                newProductItem.ID = Dal.Product.Get(id).ID;
                newProductItem.Price = Dal.Product.Get(id).Price;
                if (Dal.Product.Get(id).InStock > 0)
                    newProductItem.InStock = true;
                newProductItem.category = (BO.Enums.Category)Dal.Product.Get(id).Category;
                bool inCart = false;
                foreach(var item in cart.Items)
                {
                    if (item.ProductID == id)
                    {
                        newProductItem.Amount = item.Amount;
                        inCart = true;
                        break;
                    }
                }
                if (!inCart)
                    newProductItem.Amount = 0;
            }
            else
                throw new BO.WrongProductDetails("this ID is Wrong");
            return newProductItem;
        }

        public void AddProduct(DO.Product product)
        {
            if(product.ID>0 && product.Name!="" && product.InStock>=0 && product.Price>=0)
            {
                Dal.Product.Add(product);
            }
            else
            {
                if(product.ID <= 0)  throw new BO.WrongProductDetails("Error. The ID of the product is Wrong");
                if (product.Name == "") throw new BO.WrongProductDetails("Error. The Name of the product is Wrong");
                if (product.InStock < 0) throw new BO.WrongProductDetails("Error. The In-Stock of the product is Wrong");
                if (product.Price < 0) throw new BO.WrongProductDetails("Error. The Price of the product is Wrong");
            }
        }

        public void DeleteProduct(int id)
        {
            foreach (var orderItem in Dal.OrderItem.GetList())
            {
                if(id == orderItem.ProductID)
                {
                    throw new BO.productCantBeDeleted("Error. This product is already Exist in one of the Orders");
                }
            }
            Dal.Product.Delete(id);
        }

        public void UpdateProduct(DO.Product product)
        {
            if (product.ID > 0 && product.Name != "" && product.InStock >= 0 && product.Price >= 0)
            {
                Dal.Product.Update(product);
            }
            else
            {
                if (product.ID <= 0) throw new BO.WrongProductDetails("Error. The ID of the product is Wrong");
                if (product.Name == "") throw new BO.WrongProductDetails("Error. The Name of the product is Wrong");
                if (product.InStock < 0) throw new BO.WrongProductDetails("Error. The In-Stock of the product is Wrong");
                if (product.Price < 0) throw new BO.WrongProductDetails("Error. The Price of the product is Wrong");
            }
        }

    }
}
