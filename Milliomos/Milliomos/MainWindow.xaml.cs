using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
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
            Loaded += MainWindow_Loaded;
            this.DataContext = m;
            m.GetQuestion();
            Refresh_Scoreboard();

        }

        private async void BTN_Click(object sender, RoutedEventArgs e)
        {

            Button lenyomott = (Button)sender;
          
            lenyomott.Background = Brushes.Yellow;
            lenyomott.Foreground = Brushes.Black;


            await Task.Delay(4000);

            lenyomott.Foreground = Brushes.White;
            if (m.CheckAnswer(lenyomott.Content.ToString()[0]))
            {

                lenyomott.Background = Brushes.Green;
                round++;
                if (m.Actual < 10)
                {
                    SuccessMSGB smessagebox = new SuccessMSGB(GetCurrentAmount());
                    smessagebox.ShowDialog();
                    m.DeleteQuestion();
                    m.GetQuestion();
                    resetButtons();
                    Refresh_Scoreboard();
                }
                else
                {
                    Win();
                }
                lenyomott.Background = Brushes.Black;
            }
            else
            {
                checkIt = false;
                lenyomott.Background = Brushes.Red;
                FailedMSGB fmessagebox = new FailedMSGB(GetCurrentAmount());
                fmessagebox.ShowDialog();
                QuitGame();
            }
        }

        string amount = "";
        bool checkIt = true;
        int round = 1;
        private string GetCurrentAmount()
        {

            if (round > 1 && checkIt)
            {
                return amount = $"Jelenlegi összeged: {amount}";
            } else if (checkIt != true && round > 1) {
                return amount = $"Összeg amit hazaviszel: {amount}";
            } else if (m.Actual == 10)
            {
                return amount = "Nyertél 1 Millió Dollárt!";
            }
            else
            {
                return amount = "Nem nyertél semmit!";
            }
        }


        private void Refresh_Scoreboard()
        {
            List<DockPanel> dockPanels = scoreBoard.Children.OfType<DockPanel>().ToList();

            if (m.Actual > 0 && m.Actual <= dockPanels.Count)
            {
                DockPanel currentQuestionPanel = dockPanels[dockPanels.Count - m.Actual];

                if(m.Actual == 3 || m.Actual == 6 || m.Actual == 9)
                {
                    SetRandomBackground();
                }

                foreach (Label label in currentQuestionPanel.Children.OfType<Label>())
                {
                    label.Background = Brushes.Orange;
                    label.Foreground = Brushes.White;
                    amount = label.Content.ToString();
                }


            }
            if (m.Actual >= 2 && m.Actual <= dockPanels.Count)
            {
                DockPanel previousQuestionPanel = dockPanels[dockPanels.Count - m.Actual + 1];
                foreach (Label label in previousQuestionPanel.Children.OfType<Label>())
                {
                    label.Background = Brushes.Black;
                    label.Foreground = Brushes.Orange;
                }
            }
        } 

        private void divideHelp_Btn_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            List<StackPanel> stackPanels = answersGrid.Children.OfType<StackPanel>().ToList();
            List<Button> buttons = new List<Button>();
            buttons.AddRange(stackPanels[0].Children.OfType<Button>());
            buttons.AddRange(stackPanels[1].Children.OfType<Button>());
            int r1 = r.Next(0, 3);
            int r2 = r.Next(0, 3);
            while (buttons[r1].Content.ToString()[0] == m.currentPack.Answer || buttons[r2].Content.ToString()[0] == m.currentPack.Answer || r1 == r2)
            {
                r1 = r.Next(0, 3);
                r2 = r.Next(0, 3);
            }
            buttons[r1].IsEnabled = false;
            buttons[r1].Visibility = Visibility.Hidden;
            buttons[r2].IsEnabled = false;
            buttons[r2].Visibility = Visibility.Hidden;

            divideHelp_Btn.IsEnabled = false;
            divideHelp_Btn.Visibility = Visibility.Hidden;
        }

        private void mobHelp_Btn_Click(object sender, RoutedEventArgs e)
        {
            int chance = m.Actual * 5;
            Random r = new Random();
            int random = r.Next(1, 100);
            List<StackPanel> stackPanels = answersGrid.Children.OfType<StackPanel>().ToList();
            List<Button> buttons = new List<Button>();
            buttons.AddRange(stackPanels[0].Children.OfType<Button>());
            buttons.AddRange(stackPanels[1].Children.OfType<Button>());
            if (random <= 100 - chance)
            {
                foreach (var button in buttons)
                {
                    string content = button.Content.ToString();
                    if (content[0] == m.currentPack.Answer)
                    {
                        button.Background = Brushes.Orange;
                    }
                }
            }
            else
            {
                int rIndex = r.Next(0, 3);
                do
                {
                    string content2 = buttons[rIndex].Content.ToString();
                    if (content2[0] != (m.currentPack.Answer))
                    {
                        buttons[rIndex].Background = Brushes.Orange;
                    }
                    rIndex = r.Next(0, 3);
                } while (buttons[rIndex].Content.ToString()[0] == m.currentPack.Answer);
            }





            mobHelp_Btn.IsEnabled = false;
            mobHelp_Btn.Visibility = Visibility.Hidden;
        }

        private void resetButtons()
        {
            List<StackPanel> stackPanels = answersGrid.Children.OfType<StackPanel>().ToList();
            List<Button> buttons = new List<Button>();
            buttons.AddRange(stackPanels[0].Children.OfType<Button>());
            buttons.AddRange(stackPanels[1].Children.OfType<Button>());
            foreach (var button in buttons)
            {
                button.IsEnabled = true;
                button.Visibility = Visibility.Visible;
                button.Background = Brushes.Black;
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            SetRandomBackground();
        }

        private void SetRandomBackground()
        {
            string imagesDirectory = ".\\images\\";
            string[] imageFiles = Directory.GetFiles(imagesDirectory, "*.jpg");

            if (imageFiles.Length > 0)
            {
                Random random = new Random();
                string randomImagePath = imageFiles[random.Next(imageFiles.Length)];

                BitmapImage bitmap = new BitmapImage(new Uri(randomImagePath, UriKind.Relative));
                ImageBrush imageBrush = new ImageBrush(bitmap);
                this.Background = imageBrush;
            }
        }
        private void QuitGame()
        {
            this.Close();
        }

        private void Win()
        {
            WinMSGB wmessage = new WinMSGB();
            wmessage.ShowDialog();
            QuitGame();
        }
    }
}
