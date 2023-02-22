using BlApi;
using BO;
using PL.Product;
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

namespace PL.Order
{
    /// <summary>
    /// Interaction logic for ChooseItems.xaml
    /// </summary>
    public partial class ChooseItems : Window
    {
        BlApi.IBl? bl = BlApi.Factory.Get();
        public ChooseItems()
        {
            ProductsList = new ObservableCollection<BO.BoProductForList?>(bl!.BoProduct!.GetListOfProducts());
            InitializeComponent();
            CategorySelector.SelectedIndex = 0;
            CategorySelector.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));
        }

        public ObservableCollection<BO.BoProductForList?> ProductsList
        {
            get { return (ObservableCollection<BO.BoProductForList?>)GetValue(selectedProductProperty); }
            set { SetValue(selectedProductProperty, value); }
        }

        // Using a DependencyProperty as the backing store for selectedProduct.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty selectedProductProperty =
            DependencyProperty.Register("ProductsList", typeof(ObservableCollection<BO.BoProductForList?>), typeof(ProductList));


        private void CategorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            whichCategorySelected();
        }
        public void whichCategorySelected()
        {
            if ((int)CategorySelector.SelectedItem == (int)BO.Enums.Category.None)
                ProductListview.ItemsSource = bl!.BoProduct!.GetListOfProducts();
            else
            {
                IEnumerable<BO.BoProductForList> list = new List<BO.BoProductForList>();
                list = bl!.BoProduct!.CondGetListOfProducts(x => (int)x.Category == (int)CategorySelector.SelectedItem);
                ProductListview.ItemsSource = list;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           ((OrderUpdateWin)this.Owner).ItemsList = new ObservableCollection<BO.BoOrderItem?>((IEnumerable<BoOrderItem>)ProductListview.SelectedItems);
            this.Close();
        }
    }
}
