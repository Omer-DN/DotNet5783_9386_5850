using BO;
using BlApi;
using DalList;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Reflection;
using System.Diagnostics.Tracing;

namespace PL.Product
{
    /// <summary>
    /// Interaction logic for ProductList.xaml
    /// Creates a product display window with the option to switch to the add or update window
    /// </summary>
    public partial class ProductList : Window
    {
        BlApi.IBl? bl = BlApi.Factory.Get();
        public ProductList()
        {
            productsList = new ObservableCollection<BO.BoProductForList?>(bl!.BoProduct!.GetListOfProducts());
            listByCategory = bl.BoProduct.GetListOfProducts()!;
            InitializeComponent();
            ProductListview.SelectedItem = selectedProduct;
            comboxOptions = Enum.GetValues(typeof(BO.Enums.Category)).Cast<BO.Enums.Category>().ToList();

        }



        public List<BO.Enums.Category> comboxOptions
        {
            get { return (List<BO.Enums.Category>)GetValue(comboxOptionsProperty); }
            set { SetValue(comboxOptionsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for comboxOptions.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty comboxOptionsProperty =
            DependencyProperty.Register("comboxOptions", typeof(List<BO.Enums.Category>), typeof(ProductList));



        public IEnumerable<BO.BoProductForList> listByCategory
        {
            get { return (IEnumerable<BO.BoProductForList>)GetValue(listByCategoryProperty); }
            set { SetValue(listByCategoryProperty, value); }
        }

        // Using a DependencyProperty as the backing store for listByCategory.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty listByCategoryProperty =
            DependencyProperty.Register("listByCategory", typeof(IEnumerable<BO.BoProductForList>), typeof(ProductList));

        //Event that called when user choose category to show
        private void CategorySelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           whichCategorySelected();
        }
        //Method that change the view of the products list by specific category that choosen by the user
        public void whichCategorySelected()
        {
            try
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
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error"); }
        }

        //Event that called when user want to Add a Product to the store
        private void Action_Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new ActionsWin(0);
            window.Owner = this;
            window.Show();
        }



        public ObservableCollection<BO.BoProductForList?> productsList
        {
            get { return (ObservableCollection<BO.BoProductForList?>)GetValue(productsListProperty); }
            set { SetValue(productsListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for selectedProduct.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty productsListProperty =
            DependencyProperty.Register("productsList", typeof(ObservableCollection<BO.BoProductForList?>), typeof(ProductList));




        public BO.BoProductForList selectedProduct
        {
            get { return (BO.BoProductForList)GetValue(selectedProductProperty); }
            set { SetValue(selectedProductProperty, value); }
        }

        // Using a DependencyProperty as the backing store for selectedProduct.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty selectedProductProperty =
            DependencyProperty.Register("selectedProduct", typeof(BO.BoProductForList), typeof(ProductList));



        //Event that called when user want to Update a Product to the store
        private void ProductListview_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var asd = new ActionsWin(1,selectedProduct);
            asd.Owner = this;
            asd.Show();

        }

        //Event that called when user want to Delete a Product from the store
        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl!.BoProduct!.DeleteProduct(selectedProduct.ID);
                productsList = new ObservableCollection<BO.BoProductForList?>(bl.BoProduct.GetListOfProducts());
                ProductListview.ItemsSource = productsList;
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }
    }
}
