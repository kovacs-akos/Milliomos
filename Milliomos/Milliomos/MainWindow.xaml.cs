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
            m.GetQuestion();          
            Refresh_Scoreboard();

        }



        private async void BTN_Click(object sender, RoutedEventArgs e)
        {
            Button lenyomott = (Button)sender;
            //set the background of the button to yellow and disable all buttons then wait 3 seconds
            lenyomott.Background = Brushes.Yellow;
            await Application.Current.Dispatcher.InvokeAsync(() =>
            {
                // Set the background of the button to yellow
                lenyomott.Background = Brushes.Yellow;
                

                // Disable all buttons
                //DisableButtons();
            });

            //DisableButtons();
            //lenyomott.InvalidateVisual();
            await Task.Delay(3000);
            EnableButtons();



            if (m.CheckAnswer(lenyomott.Content.ToString()[0]))
            {
                lenyomott.Background = Brushes.Green;
                MessageBox.Show("Nice");
                m.DeleteQuestion();
                EnableButtons();
                m.GetQuestion();
                Refresh_Scoreboard();
                lenyomott.Background = Brushes.White;
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


        private void Refresh_Scoreboard()
        {
            List<DockPanel> dockPanels = new List<DockPanel>();
            dockPanels = scoreBoard.Children.OfType<DockPanel>().ToList();
            //set all dockpanels background to white
            foreach (DockPanel element in dockPanels)
            {
                element.Background = Brushes.White;
                //set all labels foreground to black
                foreach (Label label in element.Children.OfType<Label>())
                {
                    label.Foreground = Brushes.Black;
                }
            }
            DockPanel dockPanel = dockPanels[dockPanels.Count() - m.Actual];
            dockPanel.Background = Brushes.Orange;
            // set the foreground color of the dockpanel's labels to white
            foreach (Label label in dockPanel.Children.OfType<Label>())
            {
                label.Foreground = Brushes.White;
            }
        }      
    }
}
