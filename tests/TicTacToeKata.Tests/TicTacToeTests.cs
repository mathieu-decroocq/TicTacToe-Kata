using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using TicTacToeKata.Lib;

namespace TicTacToeKata.Tests
{
    public class TicTacToeTests
    {
        public List<Player> Players;
        public List<string[]> Board;
        internal void Initialize()
        {
            Players = new List<Player>
            {
                new Player() {Id = 1, Name = "P1", Marker = "X"},
                new Player() {Id = 2, Name = "P2", Marker = "0"}
            };
        }

        public Player GetPlayerOne()
        {
            return Players.Single(p => p.Id == 1);
        }

        public Player GetPlayerTwo()
        {
            return Players.Single(p => p.Id == 2);
        }

        public class GameTests : TicTacToeTests
        {
            public GameTests()
            {
                Initialize();
            }

            [Fact]
            public void NoWinner()
            {
                Game game = new Game();

                Assert.Null(game.GetWinner()); 
            }
        }

        public class AcceptanceTests : TicTacToeTests
        {
            public AcceptanceTests()
            {
                Initialize();
            }

            [Fact(DisplayName = "P1 wins with all markers in three line")]
            public void P1Wins_AllMarkersLine()
            {
                Board = new List<string[]>
                {
                    new [] {"", "", "0"},
                    new [] {"0", "0", ""},
                    new [] {"X", "X", "X"}
                };

                Game game = new Game(Board, Players[0], Players[1]);

                Assert.True(game.GetWinner() == GetPlayerOne());
            }

            [Fact(DisplayName = "P1 win with all markers in diagonale", Skip = "Plus tard")]
            public void P1Wins_AllMarkersDiagonale()
            {
                var board = new List<string[]>
                {
                    new [] {"X", "", "" },
                    new [] {"0", "X", "0"},
                    new [] {"", "", "X"}
                };

                Game game = new Game(board, Players[0], Players[1]);

                Assert.True(game.GetWinner() == GetPlayerOne());
            }

            [Fact(DisplayName = "P2 win with all markers in first column")]
            public void P2Wins_AllMarkersInFirstColumn()
            {
                var board = new List<string[]>
                {
                    new [] {"0", "X", "X"},
                    new [] {"0", "0", ""},
                    new [] {"0", "", "X"}
                };

                Game game = new Game(board, Players[0], Players[1]);

                Assert.True(game.GetWinner() == GetPlayerTwo());
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

                Game game = new Game(board, Players[0], Players[1]);

                Assert.True(game.GetWinner() == GetPlayerTwo());
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

                Game game = new Game(board, Players[0], Players[1]);

                Assert.True(game.GetWinner() == GetPlayerOne());
            }

            [Fact(DisplayName = "Thrown exception if same player play twice")]
            public void ThrowException_If_Same_Player_Play_Twice()
            {
                Game game = new Game();
                game.Play(GetPlayerOne(), 0, 0);

                Assert.Throws<InvalidOperationException>(() => game.Play(GetPlayerOne(), 1, 0));
            }

            [Fact(DisplayName = "Throw exception if marker already placed")]
            public void ThrowException_If_Marker_Already_Placed()
            {
                Game game = new Game();
                game.Play(GetPlayerOne(), 0, 0);
                game.Play(GetPlayerTwo(), 0, 1);

                Assert.Throws<InvalidOperationException>(() => game.Play(GetPlayerOne(), 0, 0));
            }
        }
    }
}
