using DalApi;
using System.Security.Principal;

namespace DalList
{
    sealed public class DalList : IDal
    {
        public IProduct DoProduct => new DalProduct();
        public IOrder DoOrder => new DalOrder();
        public IOrderItem DoOrderItem => new DalOrderItem();
    }
}