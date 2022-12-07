using BlApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BlImplementation
{
    sealed public class Bl : IBl
    {
        public IBoCart BoCart => new BoCart();
        public IBoOrder BoOrder => new BoOrder();
        public IBoProduct BoProduct => new BoProduct();

    }
}
