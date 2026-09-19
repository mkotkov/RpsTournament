using RpsTournament.Core;
using System.Windows;
using System.Windows.Controls;

namespace RpsTournament.WpfApp
{
    public partial class MainWindow : Window
    {
        private List<GameRound> rounds = new();
        private int currentRound = 1;
        private Move? selectedMove;

        public MainWindow()
        {
            InitializeComponent();

            ScoreTextBlock.Text = string.Format(
                global::RpsTournament.WpfApp.Resources.ScoreFormat,
                0,
                0
            );

            StatusTextBlock.Text =
                global::RpsTournament.WpfApp.Resources.SelectMove;
        }


        private void Button_Variant_Click(object sender, RoutedEventArgs e)
        {
            if (sender == RockButton)
                selectedMove = Move.Rock;

            else if (sender == PaperButton)
                selectedMove = Move.Paper;

            else if (sender == ScissorsButton)
                selectedMove = Move.Scissors;

            HighlightSelectedMoveButton();

            StatusTextBlock.Text =
                global::RpsTournament.WpfApp.Resources.SelectMove;
        }

        private void HighlightSelectedMoveButton()
        {
            var defaultStyle = (Style)FindResource("MoveButtonStyle");
            var activeStyle = (Style)FindResource("MoveButtonActiveStyle");

            RockButton.Style = selectedMove == Move.Rock ? activeStyle : defaultStyle;
            PaperButton.Style = selectedMove == Move.Paper ? activeStyle : defaultStyle;
            ScissorsButton.Style = selectedMove == Move.Scissors ? activeStyle : defaultStyle;
        }

        private void PlayRoundButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerNameTextBox.Text.Length < 2 ||
                PlayerNameTextBox.Text.Length > 30)
            {
                StatusTextBlock.Text =
                    global::RpsTournament.WpfApp.Resources.InvalidName;

                return;
            }



            if (selectedMove == null)
            {
                StatusTextBlock.Text =
                    global::RpsTournament.WpfApp.Resources.SelectMove;

                return;
            }


            Move playerMove = selectedMove.Value;

            Move computerMove = GameLogic.GetComputerMove();

            RoundResult result =
                GameLogic.GetRoundResult(playerMove, computerMove);


            // Create round
            GameRound round = new GameRound
            {
                Number = currentRound,
                PlayerMove = playerMove,
                ComputerMove = computerMove,
                Result = result
            };


            rounds.Add(round);

            RoundsDataGrid.ItemsSource = null;
            RoundsDataGrid.ItemsSource = rounds;


            UpdateScore();
            UpdateRoundStatus(result);


            currentRound++;


            // Tournament finished
            if (currentRound > 5)
            {
                PlayRoundButton.IsEnabled = false;

                ShowWinner();
            }


            selectedMove = null;
        }


        private void UpdateRoundStatus(RoundResult result)
        {
            switch (result)
            {
                case RoundResult.Win:
                    StatusTextBlock.Text =
                        global::RpsTournament.WpfApp.Resources.PlayerWon;
                    break;

                case RoundResult.Loss:
                    StatusTextBlock.Text =
                        global::RpsTournament.WpfApp.Resources.ComputerWon;
                    break;

                case RoundResult.Draw:
                    StatusTextBlock.Text =
                        global::RpsTournament.WpfApp.Resources.Draw;
                    break;
            }
        }


        private void ShowWinner()
        {
            int wins = rounds.Count(
                r => r.Result == RoundResult.Win
            );

            int losses = rounds.Count(
                r => r.Result == RoundResult.Loss
            );


            string result;

            if (wins > losses)
            {
                result =
                    global::RpsTournament.WpfApp.Resources.PlayerWon;
            }
            else if (losses > wins)
            {
                result =
                    global::RpsTournament.WpfApp.Resources.ComputerWon;
            }
            else
            {
                result =
                    global::RpsTournament.WpfApp.Resources.DrawTournament;
            }


            StatusTextBlock.Text =
                global::RpsTournament.WpfApp.Resources.TournamentFinished;

            MessageBox.Show(result);
        }


        private void UpdateScore()
        {
            int wins = rounds.Count(
                r => r.Result == RoundResult.Win
            );

            int losses = rounds.Count(
                r => r.Result == RoundResult.Loss
            );


            ScoreTextBlock.Text = string.Format(
                global::RpsTournament.WpfApp.Resources.ScoreFormat,
                wins,
                losses
            );
        }


        private void NewTournamentButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            rounds.Clear();

            currentRound = 1;
            selectedMove = null;
            HighlightSelectedMoveButton();

            PlayerName.Text = PlayerNameTextBox.Text;

            RoundsDataGrid.ItemsSource = null;


            ScoreTextBlock.Text = string.Format(
                global::RpsTournament.WpfApp.Resources.ScoreFormat,
                0,
                0
            );


            StatusTextBlock.Text =
                global::RpsTournament.WpfApp.Resources.SelectMove;


            PlayRoundButton.IsEnabled = true;
        }


        private void PlayerNameTextBox_TextChanged(
            object sender,
            TextChangedEventArgs e)
        {
        }


        private void DataGrid_SelectionChanged(
            object sender,
            SelectionChangedEventArgs e)
        {
        }
    }
}