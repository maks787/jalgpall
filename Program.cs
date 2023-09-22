using System;
using System.Collections.Generic;
using System.Threading;
using jalgpall;

namespace FootballGame
{
    internal class Program
    {
        private static readonly ConsoleColor HomeTeamColor = ConsoleColor.Red;
        private static readonly ConsoleColor AwayTeamColor = ConsoleColor.Blue;
        private static readonly ConsoleColor BallColor = ConsoleColor.White;

        public static void Main()
        {
            // Создание игры, команд и стадиона
            Team homeTeam = new Team("Home Team");
            Team awayTeam = new Team("Away Team");
            Stadium stadium = new Stadium(60, 20);
            Game game = new Game(homeTeam, awayTeam, stadium);

            // Создание и добавление игроков в команды
            for (int i = 1; i <= 11; i++)
            {
                Player player = new Player($"Player {i}");
                homeTeam.AddPlayer(player);
            }

            for (int i = 12; i <= 22; i++)
            {
                Player player = new Player($"Player {i}");
                awayTeam.AddPlayer(player);
            }

            game.Start();
            Console.Title = "Football Game";
            Console.WindowWidth = stadium.Width + 5; // Ширина консоли
            Console.WindowHeight = stadium.Height + 3; // Высота консоли

            while (true)
            {
                game.Move();
                DisplayField(stadium.Width, stadium.Height, homeTeam.Players, awayTeam.Players, game.Ball);
                Thread.Sleep(100);
                Console.SetCursorPosition(0, 0); // Установка курсора в начало консоли
            }
        }

        private static void DisplayField(int width, int height, List<Player> homePlayers, List<Player> awayPlayers, Ball ball)
        {
            for (int y = 0; y < height; y++)
            {
                Console.SetCursorPosition(0, y + 1); // Позиция курсора для отображения поля
                Console.Write("|"); // Левая вертикальная рамка

                for (int x = 0; x < width; x++)
                {
                    if (IsPlayerAtPosition(x, y, homePlayers))
                    {
                        Console.ForegroundColor = HomeTeamColor; // Цвет игрока команды HomeTeam
                        Console.Write("1");
                        Console.ResetColor(); // Сброс цвета
                    }
                    else if (IsPlayerAtPosition(x, y, awayPlayers))
                    {
                        Console.ForegroundColor = AwayTeamColor; // Цвет игрока команды AwayTeam
                        Console.Write("2");
                        Console.ResetColor(); // Сброс цвета
                    }
                    else if (IsBallAtPosition(x, y, ball))
                    {
                        Console.Write("0"); // Мяч 
                    }
                    else
                    {
                        Console.Write(" "); // Пустая ячейка поля
                    }
                }

                Console.Write("|"); // Правая вертикальная рамка
            }
        }

        private static bool IsPlayerAtPosition(int x, int y, List<Player> players)
        {
            foreach (var player in players)
            {
                int playerX = (int)Math.Round(player.X);
                int playerY = (int)Math.Round(player.Y);

                if (playerX == x && playerY == y)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsBallAtPosition(int x, int y, Ball ball)
        {
            int ballX = (int)Math.Round(ball.X);
            int ballY = (int)Math.Round(ball.Y);

            return ballX == x && ballY == y;
        }
    }
}
