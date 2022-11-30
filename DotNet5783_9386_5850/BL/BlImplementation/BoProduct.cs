using BlApi;
using Dal.Dal;
using DalApi;

namespace BlImplementation
{
    internal class BoProduct : IBoProduct
    { 
        private IDal Dal = new DalList;
    }
}
