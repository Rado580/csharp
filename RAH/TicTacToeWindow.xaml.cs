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


namespace _2p_games.Views
{
    public partial class TicTacToeWindow : Window
    {
        private string[,] board = new string[3, 3];
        private string currentPlayer = "X";
        private bool gameOver = false;
        private bool vsAI = true; // true = hráč vs AI, false = hráč vs hráč

        private Button[,] buttons;

        public TicTacToeWindow(bool playAgainstAI)
        {
            InitializeComponent();

            vsAI = playAgainstAI;

            Loaded += TicTacToeWindow_Loaded;
        }

        private void TicTacToeWindow_Loaded(object sender, RoutedEventArgs e)
        {
            InitButtons();
            ResetGame();
        }

        private void InitButtons()
        {
            buttons = new Button[3, 3]
            {
                { Btn00, Btn01, Btn02 },
                { Btn10, Btn11, Btn12 },
                { Btn20, Btn21, Btn22 }
            };
        }

        private void Cell_Click(object sender, RoutedEventArgs e)
        {
            if (gameOver) return;

            var btn = (Button)sender;
            var tag = btn.Tag.ToString().Split(',');
            int row = int.Parse(tag[0]);
            int col = int.Parse(tag[1]);

            if (!string.IsNullOrEmpty(board[row, col])) return;

            // Ťah hráča
            MakeMove(row, col, currentPlayer);

            if (gameOver) return;

            // Ťah AI
            if (vsAI && currentPlayer == "O")
            {
                var (aiRow, aiCol) = GetBestMove();
                MakeMove(aiRow, aiCol, "O");
            }
        }

        private void MakeMove(int row, int col, string player)
        {
            board[row, col] = player;
            buttons[row, col].Content = player == "X" ? "❌" : "⭕";
            buttons[row, col].Foreground = player == "X"
                ? new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e94560"))
                : new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4ecca3"));

            if (CheckWin(player))
            {
                StatusText.Text = vsAI && player == "O" ? " AI vyhrala!" : $" Hráč {player} vyhral!";
                StatusText.Foreground = player == "X"
                    ? new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e94560"))
                    : new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4ecca3"));
                gameOver = true;
                return;
            }

            if (CheckDraw())
            {
                StatusText.Text = " Remíza!";
                StatusText.Foreground = new SolidColorBrush(Colors.Orange);
                gameOver = true;
                return;
            }

            currentPlayer = player == "X" ? "O" : "X";
            UpdateStatus();
        }

        // ───────────────────────────────────────────
        //  MINIMAX AI
        // ───────────────────────────────────────────

        private (int row, int col) GetBestMove()
        {
            int bestScore = int.MinValue;
            int bestRow = -1, bestCol = -1;

            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    if (string.IsNullOrEmpty(board[r, c]))
                    {
                        board[r, c] = "O";
                        int score = Minimax(board, 0, false);
                        board[r, c] = "";

                        if (score > bestScore)
                        {
                            bestScore = score;
                            bestRow = r;
                            bestCol = c;
                        }
                    }
                }
            }

            return (bestRow, bestCol);
        }

        private int Minimax(string[,] b, int depth, bool isMaximizing)
        {
            if (CheckWin("O")) return 10 - depth;  // AI vyhráva
            if (CheckWin("X")) return depth - 10;  // Hráč vyhráva
            if (CheckDraw()) return 0;            // Remíza

            if (isMaximizing) // ťah AI (O)
            {
                int best = int.MinValue;
                for (int r = 0; r < 3; r++)
                    for (int c = 0; c < 3; c++)
                        if (string.IsNullOrEmpty(b[r, c]))
                        {
                            b[r, c] = "O";
                            best = Math.Max(best, Minimax(b, depth + 1, false));
                            b[r, c] = "";
                        }
                return best;
            }
            else // ťah hráča (X)
            {
                int best = int.MaxValue;
                for (int r = 0; r < 3; r++)
                    for (int c = 0; c < 3; c++)
                        if (string.IsNullOrEmpty(b[r, c]))
                        {
                            b[r, c] = "X";
                            best = Math.Min(best, Minimax(b, depth + 1, true));
                            b[r, c] = "";
                        }
                return best;
            }
        }

        // ───────────────────────────────────────────

        private void UpdateStatus()
        {
            string label = vsAI && currentPlayer == "O" ? "Na rade:  AI" : $"Na rade: Hráč {currentPlayer}";
            StatusText.Text = label;
            StatusText.Foreground = currentPlayer == "X"
                ? new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e94560"))
                : new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4ecca3"));
        }

        private bool CheckWin(string p)
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == p && board[i, 1] == p && board[i, 2] == p) return true;
                if (board[0, i] == p && board[1, i] == p && board[2, i] == p) return true;
            }
            if (board[0, 0] == p && board[1, 1] == p && board[2, 2] == p) return true;
            if (board[0, 2] == p && board[1, 1] == p && board[2, 0] == p) return true;
            return false;
        }

        private bool CheckDraw()
        {
            foreach (var cell in board)
                if (string.IsNullOrEmpty(cell)) return false;
            return true;
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e) => ResetGame();

        private void ResetGame()
        {
            board = new string[3, 3];
            currentPlayer = "X";
            gameOver = false;
            foreach (var btn in buttons)
                btn.Content = "";
            UpdateStatus();
        }
    }
}