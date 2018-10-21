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

            [Fact]
            public void P1Wins_AllMarkersLine()
            {
                // ..0
                // 00.
                // XXX
               // var board = new[,] { { "", "", "0" }, { "0", "0", "" }, { "X", "X", "X" } };
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

            [Fact]
            public void P1Wins_AllMarkersDiagonale()
            {
                // X..
                // 0X0
                // ..X
                // var board = new [,] { { "X", "", "" }, { "0", "X", "0" }, { "", "", "X" } };
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

            [Fact]
            public void P2Wins_AllMarkersColumn()
            {
                // 0XX
                // 00.
                // 0.X
                //  var board = new[,] { { "0", "X", "X" }, { "0", "0", "" }, { "0", "", "X" } };
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

    
        }

        [Fact]
        public void ThrowException_If_Same_Player_Play_Twice()
        {
            Game game = new Game();
            game.Play("X", 0, 0);

            Assert.Throws<InvalidOperationException>(() => game.Play("X", 1, 0));
        }

        [Fact]
        public void ThrowException_If_Marker_Already_Placed()
        {
            Game game = new Game();
            game.Play("X", 0, 0);
            game.Play("0", 0, 1);

            Assert.Throws<InvalidOperationException>(() => game.Play("X", 0, 0));
        }
    }
}
