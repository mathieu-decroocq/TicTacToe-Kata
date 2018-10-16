using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToeKata.Lib
{
    public class Game
    {
        private string previousMarker;
      //  private string[,] board = new string[3,3];
        private List<string[]> board = new List<string[]>(3);


        public Game()
        {
        }

        public Game(List<string[]> board)
        {
            this.board= board;
        }

        public void Play(string marker, int x, int y)
        {
            if (marker == previousMarker)
            {
                throw new InvalidOperationException("Same_Player_Play_Twice");
            }

            //if (board[x, y] != null)
            //{
            //    throw new InvalidOperationException("Marker_Already_Placed");
            //}

            if (board[x][y] != null)
            {
                throw new InvalidOperationException("Marker_Already_Placed");
            }

            previousMarker = marker;
            //board[x, y] = marker;
            board[x][y] = marker;
        }

        public string GetWinner()
        {
            return board.First(b => b.All(m => m == "X") || b.All(m => m == "0"))[0];
        }
    }
}