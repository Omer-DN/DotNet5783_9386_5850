using BlApi;
using System;
using System.Collections.Generic;
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

namespace PL.Procudt
{
    /// <summary>
    /// Interaction logic for Category.xaml
    /// </summary>
    public partial class Category : Window
    {
        private IBl bl = new Bl();
        public Category()
        {
            InitializeComponent();
            ProductListview.ItemsSource = bl.BoProduct.GetListOfProducts();
        }


        private void ShowProductButton_Click(object sender, RoutedEventArgs e) => new Category().Show();
       

        private void ProductListview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListOfProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
