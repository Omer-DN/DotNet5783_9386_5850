using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    class TestClass
    {
        private static DalProduct dalProduct = new DalProduct();
        private static DalOrder dalOrder = new DalOrder();
        private static DalOrderItem dalOrderItem = new DalOrderItem();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome, Please Choose one choice from the Menu:");
            Console.WriteLine("1 - Check the DalProduct Class");
            Console.WriteLine("2 - Check the DalOrder Class");
            Console.WriteLine("3 - Check the DalOrderItem Class");
            Console.WriteLine("0 - Exit");
            int Choice;
            Choice = int.Parse(Console.ReadLine());
            while (Choice != 0)
            {
                switch(Choice)
                {
                    case 1:
                        Console.WriteLine("DalProduct: Please Choose one choice:");
                        Console.WriteLine("1 - Add a Product to the product list of the store");
                        Console.WriteLine("2 - Get a Product from the product list of the store");
                        Console.WriteLine("3 - Get the Product list of the store");
                        Console.WriteLine("4 - Update a Product from the product list of the store");
                        Console.WriteLine("5 - Delete a Product from the product list of the store");


                }
            }
        }


    }
}
