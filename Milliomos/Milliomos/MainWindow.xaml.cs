﻿using System;
using System.Collections.Generic;
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
                round++;
                MessageBox.Show($"You've a brain, fantastic \n{GetCurrentAmount()}", "Nice dude", MessageBoxButton.OK, MessageBoxImage.None);
                m.DeleteQuestion();
                m.GetQuestion();
                resetButtons();
                Refresh_Scoreboard();
                Win();
                lenyomott.Background = Brushes.Black;
            }
            else
            {
                lenyomott.Background = Brushes.Red;
                if (MessageBox.Show($"Wrong, you have failed the game! {GetCurrentAmount()}", "All you need to do is to follow the damn train CJ", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)                           
                {
                    MessageBox.Show("You little fuck, you think you can make a decision here!", "Asshole", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                QuitGame();
            }
        }

        string amount = "";
        int round = 1;
        private string GetCurrentAmount()
        {
            if (round > 1)
            {
                return amount = $"Your current amount: {amount}";
            }
            else
            {
                return amount = "You haven't won anything";
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
        



        private void QuitGame()
        {
          this.Close();
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
            while (buttons[r1].Content.ToString()[0] == m.currentPack.Answer && buttons[r2].Content.ToString()[0] == m.currentPack.Answer && r1 == r2)
            {
                r1 = r.Next(0, 3);
                r2 = r.Next(0, 3);
            }
            buttons[r1].IsEnabled = false;
            buttons[r1].Visibility = Visibility.Hidden;
            buttons[r2].IsEnabled = false;
            buttons[r2].Visibility = Visibility.Hidden;
            
            
            //divideHelp_Btn.IsEnabled = false;
            //divideHelp_Btn.Visibility = Visibility.Hidden;
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
            foreach (var button in buttons)
            {
                string content = button.Content.ToString();
                if (content[0] == m.currentPack.Answer && random <= 100 - chance)
                {
                    button.Background = Brushes.Orange;
                }
                else if (random >= 100 - chance)
                {
                    int rIndex = r.Next(0, 3);
                    string content2 = buttons[rIndex].Content.ToString();
                    if (content2[0] == (m.currentPack.Answer))
                    {
                        buttons[rIndex].Background = Brushes.Orange;
                    }
                }
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

        private void Win() {
            if (m.Actual == 11)
            MessageBox.Show("You've won a million dollars, congratulations!", "Congratulations", MessageBoxButton.OK, MessageBoxImage.None);
            QuitGame();
        }

    }
}
