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
    /// Interaction logic for TrackOrderWin.xaml
    /// </summary>
    public partial class TrackOrderWin : Window
    {
        BlApi.IBl? bl = BlApi.Factory.Get();

        public TrackOrderWin(int id)
        {
            MyOrderTrack = bl.BoOrder.Track(id);
            InitializeComponent();
        }




        public BoOrderTracking MyOrderTrack
        {
            get { return (BoOrderTracking)GetValue(MyOrderTrackProperty); }
            set { SetValue(MyOrderTrackProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyOrderTrack.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyOrderTrackProperty =
            DependencyProperty.Register("MyOrderTrack", typeof(BoOrderTracking), typeof(TrackOrderWin), new PropertyMetadata(new BoOrderTracking()));

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
