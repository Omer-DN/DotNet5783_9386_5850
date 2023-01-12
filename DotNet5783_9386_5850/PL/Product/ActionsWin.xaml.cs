using BlApi;
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
        IBl bl = new Bl();

        public ActionsWin(int state, int id = 0)
        {
            InitializeComponent();
            Category_ComboBox.ItemsSource = Enum.GetValues(typeof(BO.Enums.Category));
            if(state == 0)
            {
                Action_Button.Content = "Add";
                Action_Button.Click += Add_Button_Click;
            }
            if (state == 1)
            {
                Action_Button.Content = "Update";
                Action_Button.Click += Update_Button_Click;
                BO.BoProduct currentProduct = bl.BoProduct.ManagerGetProduct(id);
                Category_ComboBox.SelectedItem = currentProduct.Category;
                ID_textBox.Text = currentProduct.ID.ToString();
                Name_textBox.Text = currentProduct.Name;
                Price_textBox.Text = currentProduct.Price.ToString();
                InStock_textBox.Text = currentProduct.InStock.ToString();
                ID_textBox.IsReadOnly = true;
                Name_textBox.IsReadOnly = true;
            }
        }
        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            BO.BoProduct newProduct = new BO.BoProduct();
            newProduct.ID = int.Parse(ID_textBox.Text);
            newProduct.Name = Name_textBox.Text;
            newProduct.Price = double.Parse(Price_textBox.Text);
            newProduct.Category = Enum.Parse<BO.Enums.Category>(Category_ComboBox.Text);
            newProduct.InStock = int.Parse(InStock_textBox.Text);
            bl.BoProduct.AddProduct(newProduct);
            ((ProductList)this.Owner).whichCategorySelected();
            this.Close();
        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            BO.BoProduct newProduct = new BO.BoProduct();
            newProduct.ID = int.Parse(ID_textBox.Text);
            newProduct.Name = Name_textBox.Text;
            newProduct.Price = double.Parse(Price_textBox.Text);
            newProduct.Category = Enum.Parse<BO.Enums.Category>(Category_ComboBox.Text);
            newProduct.InStock = int.Parse(InStock_textBox.Text);
            bl.BoProduct.UpdateProduct(newProduct);
            ((ProductList)this.Owner).whichCategorySelected();
            this.Close();
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            ((ProductList)this.Owner).whichCategorySelected();
            this.Close();
        }
    }
}
