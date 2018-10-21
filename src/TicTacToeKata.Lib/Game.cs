using System;
using System.Collections.Generic;
using System.Linq;
using TicTacToeKata.Lib.Extension;

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
            playerOne = new Player { Id = 1, Name = "P1", Marker = "X" };
            playerTwo = new Player { Id = 2, Name = "P2", Marker = "O" };
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
            var winningMarker = GetIdenticalMarkerForAllLine();

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

            //return null;
        }

        private string GetIdenticalMarkerForAllLine()
        {
            string winningMarker = null;
            for (int lineIndex = 0; lineIndex < board.GetLength(0); lineIndex++)
            {
                var row = board.GetRow(lineIndex);
                winningMarker = CheckIfSameMarkerAndReturnIts(row);

                if (winningMarker != null)
                {
                    break;
                }
            }

            return winningMarker;

            string CheckIfSameMarkerAndReturnIts(string[] row)
            {
                string first = row.First();
                return row.All(m => m == first) ? first : null;
            }
        }

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