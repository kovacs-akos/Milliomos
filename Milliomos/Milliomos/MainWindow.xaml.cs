using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Milliomos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Megoldas m = new Megoldas();
        
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = m;
        }



        private void BTN_Click(object sender, RoutedEventArgs e)
        {
            Button lenyomott = (Button)sender;
            lenyomott.Background = Brushes.Yellow;
            DisableButtons();
            Thread.Sleep(1000);
            if (m.CheckAnswer(lenyomott.Content.ToString()[0]))
            {
                MessageBox.Show("Nice");
                m.DeleteQuestion();
                EnableButtons();
                m.GetQuestion();
            }
            else
            {
                MessageBox.Show("Wrong");
                
            }
        }

        private void DisableButtons()
        {
            a_BTN.IsEnabled = b_BTN.IsEnabled = c_BTN.IsEnabled = d_BTN.IsEnabled = false;

        }

        private void EnableButtons()
        {
               a_BTN.IsEnabled = b_BTN.IsEnabled = c_BTN.IsEnabled = d_BTN.IsEnabled = true;
        }


        //public void refresh()
        //{
        //    c_BTN.Content 
        //}
    }
}
