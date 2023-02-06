using BO;
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
using System.Windows.Shapes;

namespace PL.Order
{
    /// <summary>
    /// Interaction logic for ConfirmOrderWin.xaml
    /// </summary>
    public partial class ConfirmOrderWin : Window
    {
        BlApi.IBl? bl = BlApi.Factory.Get();

        public ConfirmOrderWin(BO.BoCart cart)
        {
            currentCart = cart;
            CartList = new ObservableCollection<BoOrderItem?>(cart.Items!);
            InitializeComponent();
        }


        public BoCart currentCart
        {
            get { return (BoCart)GetValue(currentCartProperty); }
            set { SetValue(currentCartProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty currentCartProperty =
            DependencyProperty.Register("MyProperty", typeof(BoCart), typeof(ConfirmOrderWin), new PropertyMetadata(new BoCart()));

        public ObservableCollection<BoOrderItem?> CartList
        {
            get { return (ObservableCollection<BoOrderItem?>)GetValue(CartListProperty); }
            set { SetValue(CartListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for selectedProduct.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CartListProperty =
            DependencyProperty.Register("CartList", typeof(ObservableCollection<BoOrderItem?>), typeof(OrderUpdateWin));


        private void PluseButton(object sender, RoutedEventArgs e)
        {
            try
            {
                Button b = sender as Button;
                bl.BoCart.UpdateItem(currentCart, ((BoOrderItem)b.CommandParameter).Amount + 1, ((BoOrderItem)b.CommandParameter).ProductID);
                CartList = new ObservableCollection<BoOrderItem?>(currentCart.Items);
                OrderList.GetBindingExpression(ListView.ItemsSourceProperty).UpdateTarget();
                TPLabel.GetBindingExpression(ContentProperty).UpdateTarget();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error"); }
        }

        private void MinusButton(object sender, RoutedEventArgs e)
        {
            try
            {
                Button b = sender as Button;
                bl.BoCart.UpdateItem(currentCart, ((BoOrderItem)b.CommandParameter).Amount - 1, ((BoOrderItem)b.CommandParameter).ProductID);
                CartList = new ObservableCollection<BoOrderItem?>(currentCart.Items);
                OrderList.GetBindingExpression(ListView.ItemsSourceProperty).UpdateTarget();
                TPLabel.GetBindingExpression(ContentProperty).UpdateTarget();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error"); }
        }

        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            try
            {
                Button b = sender as Button;
                bl.BoCart.UpdateItem(currentCart, 0, ((BoOrderItem)b.CommandParameter).ProductID);
                CartList = new ObservableCollection<BoOrderItem?>(currentCart.Items);
                OrderList.GetBindingExpression(ListView.ItemsSourceProperty).UpdateTarget();
                TPLabel.GetBindingExpression(ContentProperty).UpdateTarget();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error"); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl.BoCart.OrderConfirmation(currentCart, currentCart.CustumerName, currentCart.CustumerEmail, currentCart.CustumerAdress);
                if (this.Owner.Owner != null)
                {
                    ((OrderList)this.Owner.Owner).ordersList = new ObservableCollection<BO.BoOrderForList?>(bl.BoOrder.GetListOfOrders());
                    ((OrderList)this.Owner.Owner).OrderListview.GetBindingExpression(ListView.ItemsSourceProperty).UpdateTarget();
                }
                this.Close();
                this.Owner.Close();

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error"); }
        }
    }
}
