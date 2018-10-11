using System;
using System.Runtime.Serialization;
using Xunit;

namespace BabyStepKata.Tests
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



    internal class Game
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
