using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToeKata.Lib
{
    public class Game
    {
        private string previousMarker;
        private readonly List<string[]> board = new List<string[]>(3);


        public Game()
        {
            board = new List<string[]>
            {
                new [] {"", "", ""},
                new [] {"", "", ""},
                new [] {"", "", ""}
            };
        }

        public Game(List<string[]> board)
        {
            this.board = board;
        }

        public void Play(string marker, int x, int y)
        {
            if (marker == previousMarker)
            {
                throw new InvalidOperationException("Same_Player_Play_Twice");
            }

            if (board[x][y] != string.Empty)
            {
                throw new InvalidOperationException("Marker_Already_Placed");
            }

            previousMarker = marker;
            board[x][y] = marker;
        }

        public string GetWinner()
        {
            string winnerMarker = string.Empty;
            // test row victory
            var winningRow = board.FirstOrDefault(b => b.All(m => m == "X") || b.All(m => m == "0"));
            if (winningRow != null)
            {
                winnerMarker = winningRow[0];
            }
          
            if (winnerMarker == string.Empty)
            {
                // test column victory
                bool isZero = board.All(b => b
                                   .Select((s, i) => new {Pos = i, Str = s})
                                   .Any(i => i.Str == "0"));
                if (isZero)
                {
                    winnerMarker = "0";
                }
            }

            return winnerMarker;
        }
    }
}