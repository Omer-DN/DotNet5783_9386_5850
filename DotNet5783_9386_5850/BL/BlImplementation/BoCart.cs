using BlApi;
using Dal.Dal;
using DalApi;

namespace BlImplementation
{
    internal class BoCart : IBoCart
    {
        private IDal Dal = new DalList;
    }
}
