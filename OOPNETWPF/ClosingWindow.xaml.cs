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

namespace OOPNETWPF
{
    /// <summary>
    /// Interaction logic for ClosingWindow.xaml
    /// </summary>
    public partial class ClosingWindow : Window
    {
        public bool closeApp;
        public ClosingWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            this.KeyDown += ClosingWindow_KeyDown;
        }

        private void ClosingWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnYes_Click(btnYes, new RoutedEventArgs());
            }
            else if(e.Key == Key.Escape)
            {
                btnNo_Click(btnNo, new RoutedEventArgs());
            }
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            closeApp = true;
            Close();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            closeApp = false;
            Close();
        }
    }
}
