using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.BO;
using BO;
using Dal;
using DalApi;
using DO;

namespace BlApi
{
    public interface IBoProduct
    {
        /// Request a list of products from the data layer
        /// Build a list of products of the ProductForList type (logical entity) based on the data
        /// Product list request
        /// Return the constructed list
        public IEnumerable<BoProduct?> GetProducts()
        {
            return new List<BoProduct?>();

        }

        /// You will receive a product ID
        /// If the ID is a positive number - you will make an attempt to request a product from the data layer
        /// Build a Product object (logical entity) based on the received data and calculate missing information
        /// <param name="id"></param>
        /// will return a constructed Product object
        /// throw its own appropriate exception Product request failed -
        /// (product does not exist in data layer - catch exception)
        public Dal.DalProduct product (int id)
        {
            if (id > 0)
            {
                try
                {
                    product = new (product.Get(id));
                    return product;

                }
                catch (Exception)
                {
                    Console.WriteLine("not valid id");
                }
            }
        }


    }
}
