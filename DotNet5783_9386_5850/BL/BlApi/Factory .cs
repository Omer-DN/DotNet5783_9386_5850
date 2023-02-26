

namespace BlApi
{
    /// <summary>
    /// Factory Class that provide easy and simple access to the BL layer (Design Pattern)
    /// </summary>
    public static class Factory
    {
        public static IBl? Get() => new Bl();
    }
}
