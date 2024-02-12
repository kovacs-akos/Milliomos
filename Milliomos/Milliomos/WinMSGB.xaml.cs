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
    /// Interaction logic for WinMSGB.xaml
    /// </summary>
    public partial class WinMSGB : Window
    {
        public WinMSGB()
        {
            InitializeComponent();
        }

        private void okayBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

    }
}
