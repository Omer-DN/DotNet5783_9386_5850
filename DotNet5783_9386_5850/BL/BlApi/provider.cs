﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlApi
{
    public static class provider
    {
        public static IBl? Get () => new Bl();
    }
}
