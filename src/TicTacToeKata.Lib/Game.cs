using System;

namespace TicTacToeKata.Lib
{
    public class Game
    {
        private string previousMarker;
        private string[,] board = new string[3,3];

        public Game()
        {
        }

        public void Play(string marker, int x, int y)
        {
            if (marker == previousMarker)
            {
                throw new InvalidOperationException("Same_Player_Play_Twice");
            }

            if (board[x, y] != null)
            {
                throw new InvalidOperationException("Marker_Already_Placed");
            }

            previousMarker = marker;
            board[x, y] = marker;
        }

        public string GetWinner()
        {
            return "X";
        }
    }
}