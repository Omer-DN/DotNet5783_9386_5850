

namespace DO
{
    public class IdNotFound :  Exception
    {
        public IdNotFound (string error) : base(error) { }
    }

    public class IdAlreadyExist : Exception
    {
        public IdAlreadyExist (string error) : base(error) { }
    }
    [Serializable]
    public class DalConfigException : Exception
    {
        public DalConfigException(string msg) : base(msg) { }
        public DalConfigException(string msg, Exception ex) : base(msg, ex) { }
    }

}
