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

namespace BlApi
{
    public class IProduct
    {
        public IEnumerable<BoProduct> GetProducts()
        {
            List<BoProduct> products = DataSource.listOfProducts
        }
    }
}
