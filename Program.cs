using jalgpall;
using System;
using System.Threading;

namespace FootballGame
{
    internal class Program
    {
        public static void Main()
        {
            Console.SetWindowSize(80, 20);

            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");
            Ball ball = new Ball();

            player1.X = 10;
            player1.Y = 5;

            player2.X = 30;
            player2.Y = 5;

            ball.X = 20;
            ball.Y = 10;

            int player1DirectionX = 1;
            int player2DirectionX = -1;

            while (true)
            {
                Console.Clear();

                // Простое движение игроков влево и вправо
                player1.X += player1DirectionX;
                player2.X += player2DirectionX;

                // Управление мячом при приближении игроков
                if (Math.Abs(player1.X - ball.X) < 2 && Math.Abs(player1.Y - ball.Y) < 2)
                {
                    ball.X += player1DirectionX; // Пнуть мяч вправо
                }

                if (Math.Abs(player2.X - ball.X) < 2 && Math.Abs(player2.Y - ball.Y) < 2)
                {
                    ball.X += player2DirectionX; // Пнуть мяч влево
                }

                Console.SetCursorPosition((int)player1.X, (int)player1.Y);
                Console.Write("1");

                Console.SetCursorPosition((int)player2.X, (int)player2.Y);
                Console.Write("2");

                Console.SetCursorPosition((int)ball.X, (int)ball.Y);
                Console.Write("0");

                Thread.Sleep(100);
            }
        }
    }
    public class Player
    {
        public string Name { get; }
        public double X { get; set; }
        public double Y { get; set; }

        public Player(string name)
        {
            Name = name;
        }
    }

    public class Ball
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}