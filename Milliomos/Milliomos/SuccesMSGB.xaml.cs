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
    /// Interaction logic for SuccesMSGB.xaml
    /// </summary>
    public partial class SuccessMSGB : Window
    {
        public SuccessMSGB(string getCurrentAmount)
        {
            InitializeComponent();
            mainTextBLC.Text = $"{randomString()}\n{getCurrentAmount}";
        }

        private void yesBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private string randomString()
        {
            Random random = new Random();
            List<string> answerToUserList = new List<string>() { "You're my son amigo!", "Te nagyon pacekban nyomod ember!", "Én magát hazavinném, beleegyezne?", "Uram, fékezze magát!\nMódos Gabi bácsi mindjárt felveszi magát tanárnak!", "Maga a kedvencem eddig, remélem ezt tudja.", "Maga szárnnyal!", "Én magához mennék családot alapítani.", "Csak így tovább!", "Ne adja fel,\nhamarosan vége a játéknak!", "A tudása elbűvölő számomra.", "Nekem maga nagyon tetszik." };
            int randomAnwser = random.Next(answerToUserList.Count);
            return answerToUserList[randomAnwser];
        }
    }

}
