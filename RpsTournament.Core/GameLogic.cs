namespace RpsTournament.Core
{
    public class GameLogic
    {
        public static Move GetComputerMove()
        {
            Move[] moves = Enum.GetValues<Move>();
            return moves[Random.Shared.Next(moves.Length)];
        }

        public static RoundResult GetRoundResult(Move player, Move computer)
        {
            if (player == computer) return RoundResult.Draw;
            return (player, computer) switch
            {
                (Move.Rock, Move.Scissors) => RoundResult.Win,
                (Move.Paper, Move.Rock) => RoundResult.Win,
                (Move.Scissors, Move.Paper) => RoundResult.Win,
                _ => RoundResult.Loss
            };
        }
    }
}
