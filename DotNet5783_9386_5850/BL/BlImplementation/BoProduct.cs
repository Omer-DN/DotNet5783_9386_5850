using BlApi;
using DalList.Dal;
using DalApi;

namespace BlImplementation
{
    internal class BoProduct : IBoProduct
    { 
        private IDal Dal = new DalList.Dal.DalList;
    }
}
