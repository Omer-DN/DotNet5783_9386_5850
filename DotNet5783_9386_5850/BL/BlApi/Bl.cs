
using BlImplementation;


namespace BlApi
{
    /// <summary>
    /// Class that implement the IBl Interface and create an Object of an entitie
    /// </summary>
    public class Bl : IBl
    {
        public IBoCart BoCart => new BoCart();
        public IBoOrder BoOrder => new BoOrder();
        public IBoProduct BoProduct => new BoProduct();

    }
}
