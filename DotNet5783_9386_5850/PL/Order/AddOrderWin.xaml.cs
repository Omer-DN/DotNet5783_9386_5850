using System;
using BO;
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
using PL.Product;
using System.Data.Common;

namespace PL.Order
{
    /// <summary>
    /// Interaction logic for AddOrderWin.xaml
    /// window that Add an Order to the Store
    /// </summary>
    public partial class AddOrderWin : Window
    {
        BlApi.IBl? bl = BlApi.Factory.Get();

        public AddOrderWin()
        {
            nowTime = DateTime.Now;
            MyCart.Items = new List<BoOrderItem?>();
            orderItemsList = new ObservableCollection<BoOrderItem?>(MyCart.Items);
            InitializeComponent();
            BuildCart();
            
        }




        public DateTime? nowTime
        {
            get { return (DateTime?)GetValue(nowTimeProperty); }
            set { SetValue(nowTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for nowTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty nowTimeProperty =
            DependencyProperty.Register("nowTime", typeof(DateTime?), typeof(AddOrderWin));

        


        public BoCart MyCart
        {
            get { return (BoCart)GetValue(MyCartProperty); }
            set { SetValue(MyCartProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyCart.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyCartProperty =
            DependencyProperty.Register("MyCart", typeof(BoCart), typeof(AddOrderWin), new PropertyMetadata(new BoCart()));

        private void BuildCart()
        {
            MyCart.CustumerName = newOrder.CostumerName;
            MyCart.CustumerEmail = newOrder.CostumerEmail;
            MyCart.CustumerAdress = newOrder.CostumerAdress;
            MyCart.TotalPrice = 0;
        }

        public BoOrder newOrder
        {
            get { return (BoOrder)GetValue(newOrderProperty); }
            set { SetValue(newOrderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty newOrderProperty =
            DependencyProperty.Register("newOrder", typeof(BoOrder), typeof(AddOrderWin), new PropertyMetadata(new BoOrder()));



       public ObservableCollection<BoOrderItem?> orderItemsList
        {
            get { return (ObservableCollection<BoOrderItem?>)GetValue(orderItemsListProperty); }
            set { SetValue(orderItemsListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for selectedProduct.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty orderItemsListProperty =
            DependencyProperty.Register("orderItemsList", typeof(ObservableCollection<BoOrderItem?>), typeof(OrderUpdateWin));


        //Event that called when user click at Catalog button to view the catalog of the store and choose items
        private void Catalog_Button_Click(object sender, RoutedEventArgs e)
        {
            var CatalogWin = new CatalogWin();
            CatalogWin.Owner = this;
            CatalogWin.Show();
        }

        //Event that called when user click at Add Order button to confirm and add the order to the store
        private void Action_Button_Click(object sender, RoutedEventArgs e)
        {
            var ConfrimWin = new ConfirmOrderWin(MyCart);
            ConfrimWin.Owner = this;
            ConfrimWin.Show();
        }
    }
}
