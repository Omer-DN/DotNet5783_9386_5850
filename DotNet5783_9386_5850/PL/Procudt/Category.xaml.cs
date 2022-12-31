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
using DO;
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
        }


        private void ShowProductButton_Click(object sender, RoutedEventArgs e) => new Category().Show();


        private void ProductListview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductListview.ItemsSource = bl.BoProduct.GetListOfProducts();
            Console.WriteLine(ProductListview.ItemsSource);
        }

    }
}
