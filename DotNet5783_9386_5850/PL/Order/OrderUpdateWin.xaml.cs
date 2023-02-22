using BlApi;
using BO;
using Microsoft.VisualBasic;
using PL.Product;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace PL.Order
{
    /// <summary>
    /// Interaction logic for ProductList.xaml
    /// </summary>
    public partial class OrderUpdateWin : Window
    {
        BlApi.IBl? bl = BlApi.Factory.Get();
        bool? IsNotChecked { get { return !(Edit_CheckBox.IsChecked); } }
        public OrderUpdateWin(int id = 0)
        {
            ItemsList = new ObservableCollection<BO.BoOrderItem?>(bl!.BoOrder!.GetOrder(id).Items!);
            InitializeComponent();
            currentOrder = bl.BoOrder.GetOrder(id);
            CurrentCart.Items = bl.BoOrder.GetOrder(id).Items;
            orderItemList.ItemsSource = ItemsList;

        }



        public BoCart CurrentCart
        {
            get { return (BoCart)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("CurrentCart", typeof(BoCart), typeof(OrderUpdateWin), new PropertyMetadata(new BoCart()));


        public BoOrder currentOrder
        {
            get { return (BoOrder)GetValue(ordererProperty); }
            set { SetValue(ordererProperty, value); }
        }

        // Using a DependencyProperty as the backing store for orderer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ordererProperty =
            DependencyProperty.Register("currentOrder", typeof(BoOrder), typeof(OrderUpdateWin), new PropertyMetadata(new BoOrder()));

        public ObservableCollection<BO.BoOrderItem?> ItemsList
        {
            get { return (ObservableCollection<BO.BoOrderItem?>)GetValue(orderItemsListProperty); }
            set { SetValue(orderItemsListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for selectedProduct.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty orderItemsListProperty =
            DependencyProperty.Register("ItemsList", typeof(ObservableCollection<BO.BoOrderItem?>), typeof(OrderUpdateWin));


        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            ((ProductList)this.Owner).whichCategorySelected();
            this.Close();
        }


        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                currentOrder.Items = CurrentCart.Items;
                bl!.BoOrder!.UpdateOrder(currentOrder);
                ((OrderList)Owner).ordersList = new ObservableCollection<BO.BoOrderForList?>(bl.BoOrder.GetListOfOrders()!);
                ((OrderList)Owner).OrderListview.GetBindingExpression(ListView.ItemsSourceProperty).UpdateTarget();
                this.Close();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error"); }
        }

        private void Choose_Items_Button_Click(object sender, RoutedEventArgs e)
        {
            //List<BoOrderItem> newItems = new List<BoOrderItem>();
            var window = new CatalogWin();
            window.Owner = this;
            window.Show();
        }

        private void UpdateShip_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl!.BoOrder!.UpdateShipping(currentOrder.ID);
                currentOrder = bl.BoOrder.GetOrder(currentOrder.ID);
                SDLabel.GetBindingExpression(ContentProperty).UpdateTarget();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error"); }
        }

        private void UpdateDelivery_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl!.BoOrder!.UpdateDelivery(currentOrder.ID);
                currentOrder = bl.BoOrder.GetOrder(currentOrder.ID);
                DDLabel.GetBindingExpression(ContentProperty).UpdateTarget();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error"); }
        }
    }
}

