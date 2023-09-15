using jalgpall;
using System;
using System.Collections.Generic;

namespace jalgpall;

public class Team
{
    public List<Player> Players { get; } = new List<Player>(); //список обьектов player
    public string Name { get; private set; }//
    public Game Game { get; set; }//тип данных класс game

    public Team(string name)//
    {
        Name = name;
    }

    public void StartGame(int width, int height)//запускатеся игра 
    {
        Random rnd = new Random();
        foreach (var player in Players)
        {
            player.SetPosition(
                rnd.NextDouble() * width,
                rnd.NextDouble() * height
                );
        }
    }

    public void AddPlayer(Player player)//добавляем игрока
    {
        if (player.Team != null) return;
        Players.Add(player);
        player.Team = this;
    }

    public (double, double) GetBallPosition()
    {
        return Game.GetBallPositionForTeam(this);
    }

    public void SetBallSpeed(double vx, double vy)
    {
        Game.SetBallSpeedForTeam(this, vx, vy);
    }

    public Player GetClosestPlayerToBall()
    {
        Player closestPlayer = Players[0];
        double bestDistance = Double.MaxValue;
        foreach (var player in Players)
        {
            var distance = player.GetDistanceToBall();
            if (distance < bestDistance)
            {
                closestPlayer = player;
                bestDistance = distance;
            }
        }

        return closestPlayer;
    }

    public void Move()
    {
        GetClosestPlayerToBall().MoveTowardsBall();
        Players.ForEach(player => player.Move());
    }
}
