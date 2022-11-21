using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class idNotFound :  Exception
    {
        public idNotFound (string error) : base(error) { }
    }

    class idAlreadyExist : Exception
    {
        public idAlreadyExist (string error) : base(error) { }
    }
}
