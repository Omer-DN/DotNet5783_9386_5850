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
    /// Interaction logic for CatalogWin.xaml
    /// window that show the user the catalog of the store to choose items to add to the cart
    /// </summary>
    public partial class CatalogWin : Window
    {
        BlApi.IBl? bl = BlApi.Factory.Get()!;

        public CatalogWin()
        {
            productList = new ObservableCollection<BO.BoProductItem>(bl.BoProduct!.GetProductsForCatalog()!);
            InitializeComponent();
            ComboxCategory = Enum.GetValues(typeof(BO.Enums.Category));

        }

        public Array ComboxCategory
        {
            get { return (Array)GetValue(ComboxCategoryProperty); }
            set { SetValue(ComboxCategoryProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ComboxCategory.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ComboxCategoryProperty =
            DependencyProperty.Register("ComboxCategory", typeof(Array), typeof(CatalogWin));





        public int whichCategorySelected
        {
            get { return (int)GetValue(whichCategorySelectedProperty); }
            set { SetValue(whichCategorySelectedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for whichCategorySelected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty whichCategorySelectedProperty =
            DependencyProperty.Register("whichCategorySelected", typeof(int), typeof(CatalogWin), new PropertyMetadata(0));



        public IEnumerable<BO.BoProductItem> productList
        {
            get { return (IEnumerable<BO.BoProductItem>)GetValue(productListProperty); }
            set { SetValue(productListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty productListProperty =
            DependencyProperty.Register("productList", typeof(IEnumerable<BO.BoProductItem>), typeof(CatalogWin));




        public BoProductItem selectedProduct
        {
            get { return (BoProductItem)GetValue(selectedProductProperty); }
            set { SetValue(selectedProductProperty, value); }
        }

        // Using a DependencyProperty as the backing store for selectedProduct.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty selectedProductProperty =
            DependencyProperty.Register("selectedProduct", typeof(BoProductItem), typeof(CatalogWin));



        //Event that called when user change the category to show
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            whichCategorySelected = (int)((ComboBox)sender).SelectedItem;
        }

        //Event that called when user want to see all the categories of the store by grouping view
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            comboBox.SelectedIndex = whichCategorySelected = 0;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(productsListView.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Category");
            view.GroupDescriptions.Add(groupDescription);
        }

        //Event that called when user want to return to see specific category
        private void CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(productsListView.ItemsSource);
            view.GroupDescriptions.Clear();
        }

        //Event that called when user want to see to details of specific product on the catalog
        private void productsListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(((AddOrderWin)this.Owner).MyCart.Items!.Find(x => x!.ProductID == selectedProduct.ID)!=null)
                selectedProduct.Amount = ((AddOrderWin)this.Owner).MyCart.Items!.Find(x => x!.ProductID == selectedProduct.ID)!.Amount;
            else selectedProduct.Amount = 0;
            new ProdectDetailsWin(selectedProduct).Show();
        }


        //Event that called when user want to add or update specific item from the catalog to the cart and check if we are on add state or update state
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (((BoProductItem)productsListView.SelectedItem) != null)
                {
                    if ((this.Owner).GetType() == typeof(AddOrderWin))
                    {
                        bl!.BoCart!.AddItem(((AddOrderWin)this.Owner).MyCart, ((BoProductItem)productsListView.SelectedItem).ID);
                        ((AddOrderWin)this.Owner).orderItemsList = new ObservableCollection<BoOrderItem?>(((AddOrderWin)this.Owner).MyCart.Items!);
                        ((AddOrderWin)this.Owner).CartListView.ItemsSource = ((AddOrderWin)this.Owner).orderItemsList;
                        ((AddOrderWin)this.Owner).Totalprice.Content = ((AddOrderWin)this.Owner).MyCart.TotalPrice;
                    }
                    else
                    {
                        bl!.BoCart!.AddItem(((OrderUpdateWin)this.Owner).CurrentCart, ((BoProductItem)productsListView.SelectedItem).ID);
                        ((OrderUpdateWin)this.Owner).ItemsList = new ObservableCollection<BoOrderItem?>(((OrderUpdateWin)this.Owner).CurrentCart.Items!);
                        ((OrderUpdateWin)this.Owner).orderItemList.ItemsSource = ((OrderUpdateWin)this.Owner).ItemsList;
                        ((OrderUpdateWin)this.Owner).TPLabel.Content = ((OrderUpdateWin)this.Owner).CurrentCart.TotalPrice;
                    }
                    this.Close();
                }
                else
                    throw new Exception("Please Choose Item");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error"); }
        }
    }
}
