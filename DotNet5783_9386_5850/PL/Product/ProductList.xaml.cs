using BO;
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
        public ProductList()
        {
            selectedProduct = new ObservableCollection<BO.BoProductForList?>(bl.BoProduct.GetListOfProducts());
            InitializeComponent();
            CategorySelector.SelectedIndex = 0;
            CategorySelector.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));

        }


        private void CategorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            whichCategorySelected();
        }
        public void whichCategorySelected()
        {
            if ((int)CategorySelector.SelectedItem == (int)BO.Enums.Category.None)
                ProductListview.ItemsSource = bl.BoProduct.GetListOfProducts();
            else
            {
                IEnumerable<BO.BoProductForList> list = new List<BO.BoProductForList>();
                list = bl.BoProduct.CondGetListOfProducts(x => (int)x.Category == (int)CategorySelector.SelectedItem);
                ProductListview.ItemsSource = list;
            }
        }

        private void Action_Button_Click(object sender, RoutedEventArgs e)
        {
            var asd = new ActionsWin(0);
            asd.Owner = this;
            asd.Show();

        }



        public ObservableCollection<BO.BoProductForList?> selectedProduct
        {
            get { return (ObservableCollection<BO.BoProductForList?>)GetValue(selectedProductProperty); }
            set { SetValue(selectedProductProperty, value); }
        }

        // Using a DependencyProperty as the backing store for selectedProduct.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty selectedProductProperty =
            DependencyProperty.Register("selectedProduct", typeof(ObservableCollection<BO.BoProductForList?>), typeof(ProductList));





        private void ProductListview_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int index = -1;
            int i = 0;
           foreach(BO.BoProductForList a in (((ListView)sender).ItemsSource))
            {
                if (i == ((ListView)sender).SelectedIndex)
                    index = a.ID;
                i++;
            }
            if (index != -1)
            {
                var asd = new ActionsWin(1, index);
                asd.Owner = this;
                asd.Show();
            }
            else
                return;
        }

    }
}
