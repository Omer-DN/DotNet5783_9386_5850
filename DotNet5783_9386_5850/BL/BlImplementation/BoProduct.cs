using BlApi;



namespace BlImplementation
{
    internal class BoProduct : IBoProduct
    {
        private DalApi.IDal? dal = DalApi.Factory.Get();


        public IEnumerable<BO.BoProductForList> CondGetListOfProducts(Func<DO.Product, bool>? condition)
        {
            IEnumerable<DO.Product> dataList = new List<DO.Product>();
            dataList = dal?.Product.GetList(condition);
            List<BO.BoProductForList> newList = new List<BO.BoProductForList>();
            foreach (var item in dataList)
            {
                BO.BoProductForList newItem = new BO.BoProductForList();
                newItem.ID = item.ID;
                newItem.Name = item.Name;
                newItem.Price = item.Price;
                newItem.Category = (BO.Enums.Category)item.Category;
                newList.Add(newItem);
            }
            return newList;
        }
        public IEnumerable<BO.BoProductForList> GetListOfProducts()
        {
            IEnumerable<DO.Product> dataList = new List<DO.Product>();
            dataList = dal?.Product.GetList();
            List<BO.BoProductForList> newList = new List<BO.BoProductForList>();
            foreach (var item in dataList)
            {
                BO.BoProductForList newItem = new BO.BoProductForList();
                newItem.ID = item.ID;
                newItem.Name = item.Name;
                newItem.Price = item.Price;
                newItem.Category = (BO.Enums.Category)item.Category;
                newList.Add(newItem);
            }
            return newList;
        }

        public BO.BoProduct ManagerGetProduct(int id)
        {
            BO.BoProduct newProduct = new BO.BoProduct();
            if (id > 0)
            {
                newProduct.ID = dal.Product.Get(id).ID;
                newProduct.Name = dal.Product.Get(id).Name;
                newProduct.Price = dal.Product.Get(id).Price;
                newProduct.InStock = dal.Product.Get(id).InStock;
                newProduct.Category = (BO.Enums.Category)dal.Product.Get(id).Category;
            }
            else
                throw new BO.WrongProductDetails("this ID is Wrong");
            return newProduct;
        }

        public BO.BoProductItem BuyerGetProduct(BO.BoCart cart, int id)
        {
            BO.BoProductItem newProductItem = new BO.BoProductItem();
            if (id > 0)
            {
                DO.Product dataProduct = dal.Product!.Get(id);
                newProductItem.Name = dataProduct.Name;
                newProductItem.ID = dataProduct.ID;
                newProductItem.Price = dataProduct.Price;
                if (dataProduct.InStock > 0)
                    newProductItem.InStock = true;
                newProductItem.Category = (BO.Enums.Category)dataProduct.Category;
                bool inCart = false;
                foreach (var item in cart.Items)
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

        public void AddProduct(BO.BoProduct product)
        {
            if (product.ID >0 && product.Name != "" && ((int)product.Category>=0 && (int)product.Category < 5)
                && product.InStock >= 0 && product.Price >= 0)
            {
                DO.Product newProduct = new DO.Product();
                newProduct.ID = product.ID;
                newProduct.Name = product.Name;
                newProduct.Price = product.Price;
                newProduct.Category = (DO.Enums.Category)product.Category;
                newProduct.InStock = product.InStock;
                dal?.Product.Add(newProduct);
            }
            else
            {
                if((int)product.Category < 0 || (int)product.Category > 4)
                    throw new BO.WrongProductDetails("Error. The category of the product must be 1-5 number");
                if (product.ID <= 0) throw new BO.WrongProductDetails("Error. The ID of the product cannot be negative or zero");
                if (product.Name == "") throw new BO.WrongProductDetails("Error. The Name of the product cant be empty");
                if (product.InStock < 0) throw new BO.WrongProductDetails("Error. The number in-Stock of the product cannot be negative");
                if (product.Price < 0) throw new BO.WrongProductDetails("Error. The Price of the product cannot be negative");
            }
        }

        public void DeleteProduct(int id)
        {
            foreach (var orderItem in dal?.OrderItem.GetList())
            {
                if (id == orderItem.ProductID)
                {
                    throw new BO.productCantBeDeleted("Error. This product is already Exist in one of the Orders");
                }
            }
            dal?.Product.Delete(id);
        }

        public void UpdateProduct(BO.BoProduct product)
        {
            if (product.ID > 0 && product.Name != "" && product.InStock >= 0 && product.Price >= 0)
            {
                DO.Product newProduct = new DO.Product();
                newProduct.ID = product.ID;
                newProduct.Name = product.Name!;
                newProduct.Price = product.Price;
                newProduct.Category = (DO.Enums.Category)product.Category;
                newProduct.InStock = product.InStock;
                dal?.Product!.Update(newProduct);
            }
            else
            {
                if (product.ID <= 0) throw new BO.WrongProductDetails("Error. The ID of the product is Wrong");
                if (product.Name == "") throw new BO.WrongProductDetails("Error. The Name of the product is Wrong");
                if (product.InStock < 0) throw new BO.WrongProductDetails("Error. The In-Stock of the product is Wrong");
                if (product.Price < 0) throw new BO.WrongProductDetails("Error. The Price of the product is Wrong");
            }
        }

        public BO.BoProduct Create(int id,string name, double price, BO.Enums.Category category, int instock)
        {
            BO.BoProduct newProduct = new BO.BoProduct();
            newProduct.ID = id;
            newProduct.Name = name;
            newProduct.Price = price;
            newProduct.Category = category;
            newProduct.InStock = instock;
            return newProduct;
        }
    }
}
