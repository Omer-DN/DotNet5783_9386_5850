using BO;
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

namespace PL.Order
{
    /// <summary>
    /// Interaction logic for ProdectDetailsWin.xaml
    /// Window that shows the details of specific product
    /// </summary>
    public partial class ProdectDetailsWin : Window
    {
        public ProdectDetailsWin(BoProductItem product)
        {
            InitializeComponent();
            currentProduct = product;
        }


        public BoProductItem currentProduct
        {
            get { return (BoProductItem)GetValue(currentProductProperty); }
            set { SetValue(currentProductProperty, value); }
        }

        // Using a DependencyProperty as the backing store for currentProduct.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty currentProductProperty =
            DependencyProperty.Register("currentProduct", typeof(BoProductItem), typeof(ProdectDetailsWin), new PropertyMetadata(new BoProductItem()));


        //Event that called when user want to close the window
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
