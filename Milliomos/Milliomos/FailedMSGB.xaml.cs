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

namespace Milliomos
{
    /// <summary>
    /// Interaction logic for FailedMSGB.xaml
    /// </summary>
    public partial class FailedMSGB : Window
    {


        public FailedMSGB(string GetCurrentAmount)
        {
            InitializeComponent();
            mainTextBLC.Text = $"{randomString()}\n{GetCurrentAmount}";
        }

        private void okayBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private string randomString()
        {
            Random random = new Random();
            List<string> answerToUserList = new List<string>() { "Tényleg azt hitted, hogy megnyerheted ezt a játékot?", "Első ránézésre láttam, hogy csúnyán veszíteni fogsz!", "Az agyadban nem sok IQ hányadossal rendelkezel szerintem.", "Jobban tennéd, ha Módos Gabi bácsinál takarítanál!", "Ezt nem tudni, én felkötöm magamat!", "Tudtad, hogy nem sikerült megnyerned a játékot? \nMert ha nem akkor most tudod.", "Azért remélem édesanyád büszke rád!" };
            int randomAnwser = random.Next(answerToUserList.Count);
            return answerToUserList[randomAnwser];
        }
    }
}
