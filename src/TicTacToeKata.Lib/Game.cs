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
            var winningMarker = GetIdenticalMarkerForAllLines();

            if (winningMarker == null)
            {
                winningMarker = GetIdenticalMarkerForAllColumns();
            }

            if (winningMarker == null)
            {

                winningMarker = GetIdenticalMarkerForDiagonal();
            }

            return GetPlayerByMarker(winningMarker);
        }

        private string GetIdenticalMarkerForDiagonal()
        {
            string[] markersLeftToRight = ExtractMarkerArrayByIterateBoardFromLeftToRight();

            var marker = CheckIfSameMarkerAndReturnIts(markersLeftToRight);

            if (marker == null)
            {
                var markerRightToLeft = ExtractMarkerArrayByIterateBoardFromRightToLeft();

                marker = CheckIfSameMarkerAndReturnIts(markerRightToLeft);
            }

            return marker;

            #region LocalMethods

            string[] ExtractMarkerArrayByIterateBoardFromLeftToRight()
            {
                List<string> markers = new List<string>();
                for (int i = 0; i < board.GetLength(1); i++)
                {
                    markers.Add(board[i, i]);
                }

                return markers.ToArray();
            }

            string[] ExtractMarkerArrayByIterateBoardFromRightToLeft()
            {
                List<string> markers = new List<string>();
                for (int i = 0; i < board.GetLength(1); i++)
                {
                    int reverseColumnIndex = board.GetLength(0) - i - 1;
                    markers.Add(board[i, reverseColumnIndex]);
                }

                return markers.ToArray();
            }

            #endregion
        }

        private string GetIdenticalMarkerForAllLines()
        {
            string marker = null;
            for (int lineIndex = 0; lineIndex < board.GetLength(0); lineIndex++)
            {
                var row = board.GetRow(lineIndex);
                marker = CheckIfSameMarkerAndReturnIts(row);

                if (marker != null)
                {
                    break;
                }
            }

            return marker;
        }

        private string GetIdenticalMarkerForAllColumns()
        {
            string marker = null;
            for (int colIndex = 0; colIndex < board.GetLength(1); colIndex++)
            {
                var col = board.GetColumn(colIndex);

                marker = CheckIfSameMarkerAndReturnIts(col);
                if (marker != null)
                {
                    break;
                }
            }

            return marker;
        }

        private string CheckIfSameMarkerAndReturnIts(string[] array)
        {
            string first = array.First();
            return array.All(m => m == first) ? first : null;
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