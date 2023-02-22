using BlApi;
using System.Globalization;
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

namespace PL.Product
{
    /// <summary>
    /// Interaction logic for ProductList.xaml
    /// </summary>
    public partial class ActionsWin : Window
    {
        BlApi.IBl? bl = BlApi.Factory.Get();

        public ActionsWin(int state, BoProductForList? selected = null)
        {
            InitializeComponent();
            Category_ComboBox.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));
            if(state == 0)
            {
                Action_Button.Content = "Add";
                Action_Button.Click += Add_Button_Click;
                currentProduct = new BoProduct();
            }
            if (state == 1)
            {
                Action_Button.Content = "Update";
                Action_Button.Click += Update_Button_Click;
                currentProduct = bl!.BoProduct!.ManagerGetProduct(selected!.ID);
                ID_textBox.IsReadOnly = true;
                Name_textBox.IsReadOnly = true;
            }
        }





        public BoProduct currentProduct
        {
            get { return (BoProduct)GetValue(currentProductProperty); }
            set { SetValue(currentProductProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty currentProductProperty =
            DependencyProperty.Register("currentProduct", typeof(BoProduct), typeof(ActionsWin), new PropertyMetadata(new BoProduct()));




        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl!.BoProduct!.AddProduct(currentProduct);
                ((ProductList)this.Owner).whichCategorySelected();
                this.Close();
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message, "Error"); }
        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bl!.BoProduct!.UpdateProduct(currentProduct);
                ((ProductList)this.Owner).whichCategorySelected();
                this.Close();
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message, "Error"); }
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            ((ProductList)this.Owner).whichCategorySelected();
            this.Close();
        }

        private void Action_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
