using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dal;
using DalApi;
using DO;
using System.Diagnostics;
using System.Security.Principal;

sealed internal class DalXml : IDal
{
    public IProduct Product { get; } = new DalProduct();
    public IOrder Order { get; } = new DalOrder();
    public IOrderItem OrderItem { get; } = new DalOrderItem();
    public static IDal Instance { get; } = new DalXml();


}


