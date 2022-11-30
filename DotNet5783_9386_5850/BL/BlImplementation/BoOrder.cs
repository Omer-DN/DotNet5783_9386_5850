using BlApi;
using Dal.Dal;
using DalApi;
using DO;

namespace BlImplementation
{
    internal class BoOrder : IBoOrder
    {
        private IDal Dal = new DalList;
    }
}
