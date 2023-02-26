using System;
using BlApi;
using Simulator;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace PL
{
    /// <summary>
    /// Interaction logic for SimulatorWin.xaml
    /// Window that Start the Simulator of the Program and the Timer
    /// </summary>
    public partial class SimulatorWin : Window
    {
        private readonly Stopwatch stopWatch = new();

        private volatile bool TimerRun;

        private volatile bool Wait = false;

        readonly BackgroundWorker backroundWorker = new();

        private int startTime;
        private int totalTime;

        internal delegate void OrderChange();
        internal static event OrderChange? updateOrderList;

        public SimulatorWin()
        {
            InitializeComponent();

            TimerText = "00:00:00";

            backroundWorker.DoWork += Work;
            backroundWorker.ProgressChanged += UpdateTheScreen;
            backroundWorker.RunWorkerCompleted += Cancel;

            Simulator.Simulator.ScreenUpdate += SimulatorScreenUpdate;
            Simulator.Simulator.Wating += WaitForOrders;

            backroundWorker.WorkerReportsProgress = true;
            backroundWorker.WorkerSupportsCancellation = true;

            stopWatch.Start();
            TimerRun = true;
            backroundWorker.RunWorkerAsync();
        }

        public string ExpectedOrder
        {
            get { return (string)GetValue(ExpectedOrderProperty); }
            set { SetValue(ExpectedOrderProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ExpectedOrderDetails.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExpectedOrderProperty =
            DependencyProperty.Register("ExpectedOrder", typeof(string), typeof(SimulatorWin), new PropertyMetadata(null));

        public string CurrentOrder
        {
            get { return (string)GetValue(CurrentOrderProperty); }
            set { SetValue(CurrentOrderProperty, value); }
        }
        // Using a DependencyProperty as the backing store for CurrentOrderHandle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentOrderProperty =
            DependencyProperty.Register("CurrentOrder", typeof(string), typeof(SimulatorWin), new PropertyMetadata(null));


        public string TimerText
        {
            get { return (string)GetValue(TimerTextProperty); }
            set { SetValue(TimerTextProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ClockText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TimerTextProperty =
            DependencyProperty.Register("TimerText", typeof(string), typeof(SimulatorWin), new PropertyMetadata(null));



        public double UpdateProgress
        {
            get { return (double)GetValue(UpdateProgressProperty); }
            set { SetValue(UpdateProgressProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PrecentegeUpdate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UpdateProgressProperty =
            DependencyProperty.Register("UpdateProgress", typeof(double), typeof(SimulatorWin), new PropertyMetadata(null));


        //Method called when there is no orders to handle - the simulator wait for more orders
        private void WaitForOrders()
        {
            Wait = true;
            backroundWorker.ReportProgress(2);
        }

        //Method that update the screen on the timer
        private void SimulatorScreenUpdate(int x, int time, BO.BoOrder order)
        {
            Wait = false;
            Tuple<BO.BoOrder, int> tuple = new(order, time);
            backroundWorker.ReportProgress(x, tuple);
        }

        //Event that called when user Start the Simulator and start working on orders
        private void Work(object? sender, DoWorkEventArgs? e)
        {
            Simulator.Simulator.Activate();
            while (!backroundWorker.CancellationPending)//handle clock
            {
                backroundWorker.ReportProgress(1);
                Thread.Sleep(50);
            }
        }
        //Event that called from report progress
        private void UpdateTheScreen(Object? sender, ProgressChangedEventArgs? e)
        {
            if (e?.ProgressPercentage > 1000)
            {
                var TupleOrder = (Tuple<BO.BoOrder, int>)e.UserState!;

                CurrentOrder = "Order ID : " + TupleOrder.Item1.ID + "\nCurrent status : " + TupleOrder.Item1.Status;

                string timerText = stopWatch.Elapsed.ToString();
                timerText = timerText[..8];

                string End = (stopWatch.Elapsed + TimeSpan.FromSeconds(TupleOrder.Item2 / 1000)).ToString()[..8];

                startTime = (int)stopWatch.Elapsed.TotalSeconds;
                totalTime = (TupleOrder.Item2 / 1000);

                ExpectedOrder = "Start Time : " + timerText.ToString() + "\nExpected End Time : " + End +
                    "\nOrder Will be " + (TupleOrder.Item1.Status == BO.Enums.OrderStatus.Sent ? "Delivered" : "Sent");

                updateOrderList?.Invoke();
            }
            else if (e?.ProgressPercentage == 1)
            {
                string timerText = stopWatch.Elapsed.ToString();
                TimerText = timerText[..8];
                if (!Wait)
                {
                    if (totalTime != 0)
                        UpdateProgress = ((stopWatch.Elapsed.TotalSeconds - startTime) / totalTime) * 100;
                    else
                        UpdateProgress = 0;
                }
                else
                {
                    UpdateProgress = 0;
                }
            }
            else if (e?.ProgressPercentage == 2)
            {
                CurrentOrder = "No more orders";
                ExpectedOrder = "Wating for the next order";
                UpdateProgress = 0;
            }
        }

        //Event that called when user Press at Stop Button to Stop the simulator
        private void StopSimulation_Click(object sender, RoutedEventArgs e)
        {
            backroundWorker.CancelAsync();
            Simulator.Simulator.ShutDown();
        }

        //Event that called when the simulator is canceled
        private void Cancel(object? sender, RunWorkerCompletedEventArgs? e)
        {
            Simulator.Simulator.ShutDown();
            TimerRun = false;
            backroundWorker.DoWork -= Work;
            backroundWorker.ProgressChanged -= UpdateTheScreen;
            backroundWorker.RunWorkerCompleted -= Cancel;
            Simulator.Simulator.ScreenUpdate -= SimulatorScreenUpdate;
            Simulator.Simulator.Wating -= WaitForOrders;
        }

        //Event that called when user try to close simulation window - if simulation still working - wont let it close.
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (backroundWorker.CancellationPending == false && TimerRun)
            {
                e.Cancel = true;
                MessageBox.Show(@"Cant Close Simulator While Working", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
