using BlApi;
using DO;
using System.Net;

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
        public BO.BoCart updateItem(BO.BoCart cart, int amount, int id)
        {
            foreach (var item in cart.Items)
            {
                if(item.ID == id)
                {
                    if (item.Amount < amount)
                    {
                        item.TotalPrice -= item.Price * item.Amount;
                        item.Amount = amount;
                        item.TotalPrice += item.Price * item.Amount;
                    }
                    if (item.Amount > amount)
                    {
                        item.TotalPrice -= item.Price * item.Amount;
                        item.Amount = amount;
                        item.TotalPrice += item.Price * item.Amount;
                    }
                    if (amount == 0)
                    {
                        item.TotalPrice -= item.Price * item.Amount;
                        item.Amount = amount;
                    }
                    if(amount < 0)
                        throw new BO.NegativeAmount("can't be a negative amount");
                }
            }
            return cart;
        }
        public void Order_Confirmation(BO.BoCart cart, DO.Order costumer)
        {
            foreach (var item in cart.Items)
            {
                
                DO.Product check_product = Dal.Product.Get(item.ID);
                if (check_product.InStock < item.Amount)
                {
                    throw new BO.ProductNotEnoughStock("Not enough of this product in stock");
                    BO.BoOrderItem newOrderItem = new BO.BoOrderItem();
                    newOrderItem.ID = BO.BoOrderItem.lastID++;
                    newOrderItem.ProductID = item.ID;
                    newOrderItem.Amount = item.Amount;
                    newOrderItem.Name = item.Name;
                    newOrderItem.Price = item.Price;
                    newOrderItem.TotalPrice = item.Price * newOrderItem.Amount;
                    cart.TotalPrice += item.Price;
                    break;
                }
                //צריך לעשות בדיקה אם המוצר בכלל לא קיים בחנות
            }
            if (string.IsNullOrEmpty(costumer.CostumerName))
                throw new BO.MissingCustomerName("Name does not exist in the system");

            if(string.IsNullOrEmpty(costumer.CostumerAdress))
                throw new BO.MissingCustomerStreet("There is no street in the system");

            if (string.IsNullOrEmpty(costumer.CostumerEmail))
                throw new BO.MissingCustomerStreet("The customer's email address is missing");

            if (!string.Equals(costumer.CostumerEmail[-10], "@gmail.com"))
                throw new BO.EmailAddressProblem("Problem with the customer's email address");

            BO.BoOrderItem OrderItem = new BO.BoOrderItem();
            




        }

    }
    
}
