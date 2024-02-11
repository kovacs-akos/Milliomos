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
            lenyomott.Foreground = Brushes.Black;


            await Task.Delay(5000);

            lenyomott.Foreground = Brushes.White;
            if (m.CheckAnswer(lenyomott.Content.ToString()[0]))
            {
                
                lenyomott.Background = Brushes.Green;
                MessageBox.Show("You've a brain, fantastic", "Nice dude", MessageBoxButton.OK, MessageBoxImage.None);
                m.DeleteQuestion();
                m.GetQuestion();
                Refresh_Scoreboard();
                lenyomott.Background = Brushes.Black;
            }
            else
            {
                lenyomott.Background = Brushes.Red;
                if (MessageBox.Show("Wrong, you have failed the game!", "All you need to do is to follow the damn train CJ", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)                           
                {
                    MessageBox.Show("You little fuck, you think you can make a decision here!", "Asshole", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                QuitGame();
            }
        }

        private void Refresh_Scoreboard()
        {
            List<DockPanel> dockPanels = scoreBoard.Children.OfType<DockPanel>().ToList();         
            if (m.Actual > 0 && m.Actual <= dockPanels.Count)
            {
                DockPanel currentQuestionPanel = dockPanels[dockPanels.Count - m.Actual];               
              
                foreach (Label label in currentQuestionPanel.Children.OfType<Label>())
                {
                    label.Background = Brushes.Orange;
                    label.Foreground = Brushes.White;
                }
            }
        }


        private void QuitGame()
        {
          this.Close();
        }
    }
}
