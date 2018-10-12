using System;
using Xunit;
using TicTacToeKata.Lib;

namespace TicTacToeKata.Tests
{
    public class TicTacToeTests
    {
        [Fact]
        public void Game_P1Wins_AllMarkersDiagonale()
        {
            // X..
            // 0X0
            // ..X
            Game game = new Game();
            game.Play("X", 0, 0);
            game.Play("0", 0, 1);
            game.Play("X", 1, 1);
            game.Play("0", 2, 1);
            game.Play("X", 2, 2);

            // P1 Wins!
            Assert.True(game.GetWinner() == "X");
        }

        [Fact]
        public void Game_P1Wins_AllMarkersLine()
        {
            // ..0
            // 00.
            // XXX
        }

        [Fact]
        public void Game_P1Wins_AllMarkersColumn()
        {
            // 0..
            // XXX
            // .0.
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
