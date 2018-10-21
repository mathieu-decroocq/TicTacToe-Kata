using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToeKata.Lib
{
    public class Game
    {
        private Player previousPlayer;
        private string[,] board = new string[3, 3];
        private Player playerOne;
        private Player playerTwo;

        public Game()
        {
            InitEmptyBoard();
            InitPlayers();
        }

        private void InitEmptyBoard()
        {
            board = new[,] { { "", "", "" }, { "", "", "" }, { "", "", "" } };
        }

        private void InitPlayers()
        {
            playerOne = new Player() { Id = 1, Name = "P1", Marker = "X" };
            playerTwo = new Player() { Id = 2, Name = "P2", Marker = "O" };
        }

        public Game(string[,] board, Player p1, Player p2)
        {
            this.board = board;
            this.playerOne = p1;
            this.playerTwo = p2;
        }

        public void Play(Player player, int x, int y)
        {
            if (previousPlayer != null && player.Id == previousPlayer.Id)
            {
                throw new InvalidOperationException("Same_Player_Play_Twice");
            }

            if (board[x, y] != string.Empty)
            {
                throw new InvalidOperationException("Marker_Already_Placed");
            }

            previousPlayer = player;
            board[x, y] = player.Marker;
        }

        public Player GetWinner()
        {
            string winningMarker = string.Empty;

            for (int i = 0; i < board.GetLength(0); i++)
            {
                var row = Enumerable.Range(0, board.GetLength(1)).Select(x => board[i, x]).ToArray();
                if(row.All(m => m == playerOne.Marker))
                {
                    winningMarker = playerOne.Marker;
                }
                else if (row.All(m => m == playerTwo.Marker))
                {
                    winningMarker = playerTwo.Marker;
                }
            }

            return GetPlayerByMarker(winningMarker);

            //string winningMarker = MarkerSameInRow();
            //if (winningMarker != null)
            //{
            //    return GetPlayerByMarker(winningMarker);
            //}

            //// test column victory
            //bool isZero = board.All(row => row
            //                   .Select((s, i) => new { Pos = i, Str = s })
            //                   .Any(i => i.Str == playerTwo.Marker));
            //if (isZero)
            //{
            //    return GetPlayerByMarker(playerTwo.Marker);
            //}

            return null;
        }

        //private string MarkerSameInRow()
        //{
        //    return board.FirstOrDefault(row => row.All(m => m == playerOne.Marker) || row.All(m => m == playerTwo.Marker))?.FirstOrDefault();
        //}

        private Player GetPlayerByMarker(string winnerMarker)
        {
            Player winner = null;
            if (winnerMarker == playerOne.Marker)
            {
                winner = playerOne;
            }
            else if (winnerMarker == playerTwo.Marker)
            {
                winner = playerTwo;
            }

            return winner;
        }
    }
}