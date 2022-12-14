
using BlImplementation;


namespace BlApi
{
    sealed public class Bl : IBl
    {
        public IBoCart BoCart => new Bocart();
        public IBoOrder BoOrder => new BoOrder();
        public IBoProduct BoProduct => new BoProduct();

    }
}
