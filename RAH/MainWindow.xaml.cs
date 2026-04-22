using System.Windows;
using _2p_games.Views;

namespace _2p_games
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnTicTacToe_Click(object sender, RoutedEventArgs e)
        {
            var modeWindow = new ViewsGameModeWindow();

            bool? result = modeWindow.ShowDialog();

            if (result == true)
            {
                var game = new _2p_games.Views.TicTacToeWindow(modeWindow.PlayAgainstAI);
                game.Show();
            }
        }
    }
}