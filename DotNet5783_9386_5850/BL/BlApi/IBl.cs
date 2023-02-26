
namespace BlApi
{
    /// <summary>
    /// The Interface to create access to the Logic Layer
    /// </summary>
    public interface IBl
    {
        public IBoProduct? BoProduct { get; }

        public IBoOrder? BoOrder { get; }

        public IBoCart? BoCart { get;}  
    }
}
