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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool player = true;
        List<string> game = new List<string>(){"","","","","","","","",""};

        public MainWindow()
        {
            InitializeComponent();

        }

        void Reset()
        {
            game = new List<string>() { "", "", "", "", "", "", "", "", "" };

            foreach (UIElement ele in board.Children)
            {
                if (ele is Button)
                    (ele as Button).Content = null;
            }
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            Button btn = (sender as Button);
            string move = "";

            if (btn.Content == null)
            {
                move = getMove();
                (sender as Button).Content = move;

                game[int.Parse(btn.Tag.ToString())] = move;

            }

            CheckWin();
                
        }

        private string getMove()
        {
            string ret = "";

            if (player)
                ret = "X";
            else
                ret = "O";

            player = !player;

            return ret;
        }

        private void CheckWin()
        {
            if (game[0] != "" && (game[0] == game[1] && game[1] == game[2]))
                DisplayMessage();
            else if (game[3] != "" && (game[3] == game[4] && game[4] == game[5]))
                DisplayMessage();
            else if (game[6] != "" && (game[6] == game[7] && game[7] == game[8]))
                DisplayMessage();
            else if (game[0] != "" && (game[0] == game[3] && game[3] == game[6]))
                DisplayMessage();
            else if (game[1] != "" && (game[1] == game[4] && game[4] == game[7]))
                DisplayMessage();
            else if (game[2] != "" && (game[2] == game[5] && game[5] == game[8]))
                DisplayMessage();
            else if (game[0] != "" && (game[0] == game[4] && game[4] == game[8]))
                DisplayMessage();
            else if (game[2] != "" && (game[2] == game[4] && game[4] == game[6]))
                DisplayMessage();
            else
            {           

                if (!game.Contains(""))
                {
                    DisplayTieMessage();
                    return;
                }
            }
        }

        private void DisplayMessage()
        {
            if (MessageBox.Show((player ? "O" : "X") + " wins!\n\nPlay again?", "You win!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Reset();
            else
                Close();
        }

        private void DisplayTieMessage()
        {
            if (MessageBox.Show("Tie game!\n\nPlay again?", "Aww..", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Reset();
            else
                Close();
        }
    }
}
