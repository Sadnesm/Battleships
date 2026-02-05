using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SeaBattle
{
    public class GameLogic
    {
        public CellState[,] MyField = new CellState[10, 10];
        public CellState[,] EnemyField = new CellState[10, 10];
        public List<Ship> MyShips = new List<Ship>();

        public GameLogic()
        {
            for (int x = 0; x < 10; x++)
                for (int y = 0; y < 10; y++)
                    MyField[x, y] = EnemyField[x, y] = CellState.Empty;
        }

        public bool CanPlaceShip(List<Point> points)
        {
            foreach (var p in points)
            {
                if (p.X < 0 || p.X >= 10 || p.Y < 0 || p.Y >= 10) return false;
                if (MyField[p.X, p.Y] != CellState.Empty) return false;

                for (int dx = -1; dx <= 1; dx++)
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        int nx = p.X + dx, ny = p.Y + dy;
                        if (nx >= 0 && nx < 10 && ny >= 0 && ny < 10 && MyField[nx, ny] == CellState.Ship)
                            return false;
                    }
            }
            return true;
        }

        public string ProcessEnemyShot(int x, int y)
        {
            if (MyField[x, y] == CellState.Ship)
            {
                MyField[x, y] = CellState.Hit;
                var ship = MyShips.First(s => s.Decks.Contains(new Point(x, y)));
                ship.Hits.Add(new Point(x, y));
                return ship.IsSunk ? "Sunk" : "Hit";
            }
            MyField[x, y] = CellState.Miss;
            return "Miss";
        }
    }
}