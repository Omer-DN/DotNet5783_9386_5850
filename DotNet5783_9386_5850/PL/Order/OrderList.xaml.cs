using BO;
using BlApi;
using DalList;
using PL.Order;
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
using PL.Product;

namespace PL.Order
{
    /// <summary>
    /// Interaction logic for OrderList.xaml
    /// Window that shows list of orders that exist in the store
    /// </summary>
    public partial class OrderList : Window
    {
        BlApi.IBl? bl = BlApi.Factory.Get();
        public OrderList(string state)
        {
            ordersList = new ObservableCollection<BO.BoOrderForList?>(bl!.BoOrder!.GetListOfOrders()!);
            InitializeComponent();
            if (state == "TrackOnly")
                Add_Button.IsEnabled = false;
            OrderListview.SelectedItem = selectedOrder;
        }



        public BoOrderForList selectedOrder
        {
            get { return (BoOrderForList)GetValue(selectedOrderProperty); }
            set { SetValue(selectedOrderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for selectedOrder.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty selectedOrderProperty =
            DependencyProperty.Register("selectedOrder", typeof(BoOrderForList), typeof(OrderList), new PropertyMetadata(new BoOrderForList()));



        public ObservableCollection<BO.BoOrderForList?> ordersList
        {
            get { return (ObservableCollection<BO.BoOrderForList?>)GetValue(ordersListProperty); }
            set { SetValue(ordersListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for selectedProduct.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ordersListProperty =
            DependencyProperty.Register("ordersList", typeof(ObservableCollection<BO.BoOrderForList?>), typeof(OrderList));

        //Event that called when Manager Press at Add Order Button to Add Order to the store
        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            var Addwindow = new AddOrderWin();
            Addwindow.Owner = this;
            Addwindow.Show();
        }

        //Event that called when manager Double click at specific order to view or Update order of the store
        private void OrderListview_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (Add_Button.IsEnabled)
            {
                var UpdateWin = new OrderUpdateWin(selectedOrder.ID);
                UpdateWin.Owner = this;
                UpdateWin.Show();
            }
        }

        //Event that called when manager select click at Track order to track order in the store
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var TrackWin = new TrackOrderWin(selectedOrder.ID);
            TrackWin.Owner = this;
            TrackWin.Show();
        }
    }
}
