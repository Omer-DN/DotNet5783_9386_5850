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
            ItemsList = new ObservableCollection<BO.BoOrderItem?>(bl.BoOrder.GetOrder(id).Items);
            InitializeComponent();
            currentOrder = bl.BoOrder.GetOrder(id);
            CurrentCart.Items = bl.BoOrder.GetOrder(id).Items;
            orderItemList.ItemsSource = ItemsList;
            //Status_ComboBox.ItemsSource = Enum.GetValues(typeof(BO.Enums.OrderStatus));
            //initilizeUpdate(id);

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


        /*public class Order : DependencyObject
        {
            public int ID
            {
                get { return (int)GetValue(IDProperty); }
                set { SetValue(IDProperty, value); }
            }
            public static readonly DependencyProperty IDProperty =
                DependencyProperty.Register("ID", typeof(int), typeof(Order), new UIPropertyMetadata(""));
            public string CostumerName
            {
                get { return (string)GetValue(CostumerNameProperty); }
                set { SetValue(CostumerNameProperty, value); }
            }
            public static readonly DependencyProperty CostumerNameProperty =
            DependencyProperty.Register("CostumerName", typeof(string), typeof(Order), new UIPropertyMetadata(""));
            public string CostumerEmail
            {
                get { return (string)GetValue(CostumerEmailProperty); }
                set { SetValue(CostumerEmailProperty, value); }
            }
            public static readonly DependencyProperty CostumerEmailProperty =
            DependencyProperty.Register("CostumerEmail", typeof(string), typeof(Order), new UIPropertyMetadata(""));
            public string CostumerAdress
            {
                get { return (string)GetValue(CostumerAdressProperty); }
                set { SetValue(CostumerAdressProperty, value); }
            }
            public static readonly DependencyProperty CostumerAdressProperty =
            DependencyProperty.Register("CostumerAdress", typeof(string), typeof(Order), new UIPropertyMetadata(""));
            public BO.Enums.OrderStatus Status
            {
                get { return (BO.Enums.OrderStatus)GetValue(StatusProperty); }
                set { SetValue(StatusProperty, value); }
            }
            public static readonly DependencyProperty StatusProperty =
                DependencyProperty.Register("Status", typeof(BO.Enums.OrderStatus), typeof(Order), new PropertyMetadata(0));
            public DateTime OrderDate
            {
                get { return (DateTime)GetValue(OrderDateProperty); }
                set { SetValue(OrderDateProperty, value); }
            }
            public static readonly DependencyProperty OrderDateProperty =
                DependencyProperty.Register("OrderDate", typeof(DateTime), typeof(Order), new PropertyMetadata(0));
            public DateTime ShipDate
            {
                get { return (DateTime)GetValue(ShipDateProperty); }
                set { SetValue(ShipDateProperty, value); }
            }
            public static readonly DependencyProperty ShipDateProperty =
                DependencyProperty.Register("ShipDate", typeof(DateTime), typeof(Order), new PropertyMetadata(0));
            public DateTime DeliveryDate
            {
                get { return (DateTime)GetValue(DeliveryDateProperty); }
                set { SetValue(DeliveryDateProperty, value); }
            }
            public static readonly DependencyProperty DeliveryDateProperty =
                DependencyProperty.Register("DeliveryDate", typeof(DateTime), typeof(Order), new PropertyMetadata(0));
            public List<BoOrderItem?> Items
            {
                get { return (List<BoOrderItem?>)GetValue(ItemsProperty); }
                set { SetValue(ItemsProperty, value); }
            }
            public static readonly DependencyProperty ItemsProperty =
                DependencyProperty.Register("Items", typeof(List<BoOrderItem?>), typeof(Order), new PropertyMetadata(0));
            public double TotalPrice
            {
                get { return (double)GetValue(TotalPriceProperty); }
                set { SetValue(TotalPriceProperty, value); }
            }
            public static readonly DependencyProperty TotalPriceProperty =
                DependencyProperty.Register("TotalPrice", typeof(double), typeof(Order), new PropertyMetadata(0));
        }*/


        

        



        /*private void initilizeUpdate(int id)
        {
            BO.BoOrder currentOrder = bl.BoOrder.GetOrder(id);
            ID_textBox.Text = currentOrder.ID.ToString();
            CostumerName_textBox.Text = currentOrder.CostumerName;
            CostumerEmail_textBox.Text = currentOrder.CostumerEmail;
            CostumerAdress_textBox.Text = currentOrder.CostumerAdress;
            Status_ComboBox.SelectedItem = currentOrder.Status;
            OrderDate_textBox.Text = currentOrder.OrderDate.ToString();
            ShipDate_textBox.Text = currentOrder.ShipDate.ToString();
            DeliveryDate_textBox.Text = currentOrder.DeliveryDate.ToString();
            TotalPrice_textBox.Text = currentOrder.TotalPrice.ToString();
        }*/

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
                bl.BoOrder.UpdateOrder(currentOrder);
                ((OrderList)Owner).ordersList = new ObservableCollection<BO.BoOrderForList?>(bl.BoOrder.GetListOfOrders());
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
                bl.BoOrder.UpdateShipping(currentOrder.ID);
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
                bl.BoOrder.UpdateDelivery(currentOrder.ID);
                currentOrder = bl.BoOrder.GetOrder(currentOrder.ID);
                DDLabel.GetBindingExpression(ContentProperty).UpdateTarget();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error"); }
        }
    }
}

