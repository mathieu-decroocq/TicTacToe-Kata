using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToeKata.Lib
{
    public class Game
    {
        private Player previousPlayer;
        private List<string[]> board;
        private Player playerOne;
        private Player playerTwo;

        public Game()
        {
            InitEmptyBoard();
            InitPlayers();
        }

        private void InitEmptyBoard()
        {
            board = new List<string[]>
            {
                new[] {"", "", ""},
                new[] {"", "", ""},
                new[] {"", "", ""}
            };
        }

        private void InitPlayers()
        {
            playerOne = new Player() { Id = 1, Name = "P1", Marker = "X" };
            playerTwo = new Player() { Id = 2, Name = "P2", Marker = "O" };
        }

        public Game(List<string[]> board, Player p1, Player p2)
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

            if (board[x][y] != string.Empty)
            {
                throw new InvalidOperationException("Marker_Already_Placed");
            }

            previousPlayer = player;
            board[x][y] = player.Marker;
        }

        public Player GetWinner()
        {
            string winnerMarker = string.Empty;
            // test row victory
            var winningRow = board.FirstOrDefault(b => b.All(m => m == playerOne.Marker) || b.All(m => m == playerTwo.Marker));
            if (winningRow != null)
            {
                winnerMarker = winningRow[0];
            }

            if (winnerMarker == string.Empty)
            {
                // test column victory
                bool isZero = board.All(b => b
                                   .Select((s, i) => new { Pos = i, Str = s })
                                   .Any(i => i.Str == playerTwo.Marker));
                if (isZero)
                {
                    winnerMarker = playerTwo.Marker;
                }
            }


            return GetPlayerByMarker(winnerMarker);
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