using System;

namespace jalgpall
{
    public class Player
    {
        public string Name { get; } // Имя игрока
        public double X { get; set; } // Горизонтальная координата игрока
        public double Y { get; set; } // Вертикальная координата игрока
        private double _vx, _vy; // Расстояние между игроком и мячом
        public Team? Team { get; set; } = null; // Команда, в которой играет игрок

        public const double MaxSpeed = 5; // Максимальная скорость игрока
        public const double MaxKickSpeed = 25; // Максимальная скорость удара мяча
        public const double BallKickDistance = 10; // Расстояние, с которого можно ударить мяч

        private Random _random = new Random(); // Генератор случайных чисел

        public Player(string name)
        {
            Name = name;
        }

        public Player(string name, double x, double y, Team team)
        {
            Name = name;
            X = x;
            Y = y;
            Team = team;
        }

        public void SetPosition(double x, double y)
        {
            X = x;
            Y = y;
        }

        public (double, double) GetAbsolutePosition()
        {
            return Team!.Game.GetPositionForTeam(Team, X, Y);
        }

        public double GetDistanceToBall()
        {
            var ballPosition = Team!.GetBallPosition();
            var dx = ballPosition.Item1 - X;
            var dy = ballPosition.Item2 - Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public void MoveTowardsBall()
        {
            var ballPosition = Team!.GetBallPosition();
            var dx = ballPosition.Item1 - X;
            var dy = ballPosition.Item2 - Y;
            var ratio = Math.Sqrt(dx * dx + dy * dy) / MaxSpeed;
            _vx = dx / ratio;
            _vy = dy / ratio;
        }

        public void Move()
        {
            if (Team!.GetClosestPlayerToBall() != this)
            {
                _vx = 0;
                _vy = 0;
            }

            if (GetDistanceToBall() < BallKickDistance)
            {
                Team.SetBallSpeed(
                    MaxKickSpeed * _random.NextDouble(),
                    MaxKickSpeed * (_random.NextDouble() - 0.5)
                );
            }

            var newX = X + _vx;
            var newY = Y + _vy;
            var newAbsolutePosition = Team.Game.GetPositionForTeam(Team, newX, newY);
            if (Team.Game.Stadium.IsIn(newAbsolutePosition.Item1, newAbsolutePosition.Item2))
            {
                X = newX;
                Y = newY;
            }
            else
            {
                _vx = _vy = 0;
            }
        }
    }
}
