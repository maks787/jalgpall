using System;

namespace jalgpall;

public class Player
{
    //поля
    public string Name { get; } //имя игрока
    public double X { get; private set; } //горизонтальная координата игрока
    public double Y { get; private set; }//вертикальная координата игрока
    private double _vx, _vy;//расстояние между игроком и мячом
    public Team? Team { get; set; } = null;//команда в которой играет игрок

    private const double MaxSpeed = 5;//максимальная скорость
    private const double MaxKickSpeed = 25;//максимальная скорость удара
    private const double BallKickDistance = 10;//растояние удара по мячу

    private Random _random = new Random();//рандомные числа
    //конструктор
    public Player(string name) //зависит от строки и слово равно к Namega
    {
        Name = name;
    }

    public Player(string name, double x, double y, Team team)//игрок на поле у него есть координата имя и команда он готов к игре
    {
        Name = name;
        X = x;
        Y = y;
        Team = team;
    }

    public void SetPosition(double x, double y)//метод для установки позиции для расстановки игроков
    {
        X = x;
        Y = y;
    }

    public (double, double) GetAbsolutePosition()//метод для установки абсолютной позиции 
    {
        return Team!.Game.GetPositionForTeam(Team, X, Y);
    }

    public double GetDistanceToBall() //метод для вычисления расстояния до мяча
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
        if (Team.GetClosestPlayerToBall() != this)//если будет не равно этому то игрок не передвигается
        {
            _vx = 0;
            _vy = 0;
        }

        if (GetDistanceToBall() < BallKickDistance) //если дистанция до мяча меньше чем дистанция с которой можно бить то тогда задаем скорость
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
