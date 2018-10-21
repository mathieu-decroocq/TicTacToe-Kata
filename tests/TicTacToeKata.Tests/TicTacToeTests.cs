using System;
using System.Collections.Generic;
using Xunit;
using TicTacToeKata.Lib;

namespace TicTacToeKata.Tests
{
    public class TicTacToeTests
    {
        public class GameTests
        {

            [Fact(DisplayName = "P1 wins with all markers in three line")]
            public void P1Wins_AllMarkersLine()
            {
                var board = new List<string[]>
                {
                    new [] {"", "", "0"},
                    new [] {"0", "0", ""},
                    new [] {"X", "X", "X"}
                };

                Game game = new Game(board);

                // P1 Wins!
                Assert.True(game.GetWinner() == "X");
            }

            [Fact(DisplayName = "P1 wins with all markers in diagonale")]
            public void P1Wins_AllMarkersDiagonale()
            {
                var board = new List<string[]>
                {
                    new [] {"X", "", "" },
                    new [] {"0", "X", "0"},
                    new [] {"", "", "X"}
                };

                Game game = new Game(board);
  
                // P1 Wins!
                Assert.True(game.GetWinner() == "X");
            }

            [Fact(DisplayName = "P2 wins with all markers in first column")]
            public void P2Wins_AllMarkersInFirstColumn()
            {
                var board = new List<string[]>
                {
                    new [] {"0", "X", "X"},
                    new [] {"0", "0", ""},
                    new [] {"0", "", "X"}
                };

                Game game = new Game(board);

                // P2 Wins!
                Assert.True(game.GetWinner() == "0");
            }

            [Fact(DisplayName = "P2 win with all markers in second column")]
            public void P2Wins_AllMarkersInSecondColumn()
            {
                var board = new List<string[]>
                {
                    new [] {"X", "0", "X"},
                    new [] {"0", "0", ""},
                    new [] {"", "0", "X"}
                };

                Game game = new Game(board);

                // P2 Wins!
                Assert.True(game.GetWinner() == "0");
            }

            [Fact(DisplayName = "P1 wins with all markers in third column", Skip = "Trop tot")]
            public void P1Wins_AllMarkersInThirdColumn()
            {
                var board = new List<string[]>
                {
                    new [] {"X", "0", "X"},
                    new [] {"0", "", "X"},
                    new [] {"", "0", "X"}
                };

                Game game = new Game(board);

                // P1 Wins!
                Assert.True(game.GetWinner() == "X");
            }
        }

        [Fact(DisplayName = "Thrown exception if same player play twice")]
        public void ThrowException_If_Same_Player_Play_Twice()
        {
            Game game = new Game();
            game.Play("X", 0, 0);

            Assert.Throws<InvalidOperationException>(() => game.Play("X", 1, 0));
        }

        [Fact(DisplayName = "Throw exception if marker already placed")]
        public void ThrowException_If_Marker_Already_Placed()
        {
            Game game = new Game();
            game.Play("X", 0, 0);
            game.Play("0", 0, 1);

            Assert.Throws<InvalidOperationException>(() => game.Play("X", 0, 0));
        }
    }
}
