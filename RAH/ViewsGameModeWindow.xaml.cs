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

namespace _2p_games
{
    /// <summary>
    /// Interaction logic for ViewsGameModeWindow.xaml
    /// </summary>
    public partial class ViewsGameModeWindow : Window
    {
        public bool PlayAgainstAI { get; private set; }
        public ViewsGameModeWindow()
        {
            InitializeComponent();
        }
        private void BtnVsAI_Click(object sender, RoutedEventArgs e)
        {
            PlayAgainstAI = true;
            DialogResult = true; // zatvorí okno
        }

        private void BtnVsPlayer_Click(object sender, RoutedEventArgs e)
        {
            PlayAgainstAI = false;
            DialogResult = true;
        }

    }
}