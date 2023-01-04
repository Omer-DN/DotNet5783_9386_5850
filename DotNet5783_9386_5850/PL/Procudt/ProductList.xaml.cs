using BlApi;
using DalList;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PL.Product
{
    /// <summary>
    /// Interaction logic for ProductList.xaml
    /// Creates a product display window with the option to switch to the add or update window
    /// </summary>
    public partial class ProductList : Window
    {
        IBl bl = new Bl();


        private void ProductListview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductListview.ItemsSource = bl.BoProduct.GetListOfProducts();
        }

        private void CategorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CategorySelector.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));
        }
  
    }
}
