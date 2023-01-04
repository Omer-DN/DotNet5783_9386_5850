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
    /// Interaction logic for ProductForList.xaml
    /// Creates a product display window with the option to switch to the add or update window
    /// </summary>
    public partial class ProductForList : Window
    {
        IBl bl = new Bl();
        //public static ObservableCollection<BO.BoProductForList?>? productForLists;

        private void New_Order_Click(object sender, RoutedEventArgs e) => new DalProduct().Get();

        private void ProductListview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductListview.ItemsSource = bl.BoProduct.GetListOfProducts();

        }
    }
}
