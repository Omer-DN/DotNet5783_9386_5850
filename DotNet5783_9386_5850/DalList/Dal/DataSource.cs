

using DO;
using System.ComponentModel;
using static DO.Enums;

namespace Dal;

internal class DataSource
{
    readonly Random rand = new Random();
    static Product[] arrayOfproducts = new Product[50];
    Order[] arrayOforders = new Order[100];
    OrderItem[] arrayOrderItems = new OrderItem[200];       

    public static void AddProduct(int id, string name, double price, Category category, int instock)
    {
        Product newProduct = new Product();
        newProduct.Id = id;
        newProduct.Name = name;
        newProduct.Price = price;
        newProduct.Category = category;
        newProduct.InStock = instock;
        for (int i=0; i<50; i++)
        {
            if (arrayOfproducts[i] is null)
            {

            }
        }
    }

}
