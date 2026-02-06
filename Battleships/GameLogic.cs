using System;
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
        private Random random = new Random();

        public GameLogic()
        {
            InitializeFields();
        }

        private void InitializeFields()
        {
            for (int x = 0; x < 10; x++)
                for (int y = 0; y < 10; y++)
                {
                    MyField[x, y] = CellState.Empty;
                    EnemyField[x, y] = CellState.Empty;
                }
        }

        public void AutoPlaceShips()
        {
            int[] shipSizes = { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };
            bool success = false;

            while (!success)
            {
                InitializeFields();
                MyShips.Clear();
                success = true;

                foreach (int size in shipSizes)
                {
                    bool placed = false;
                    int attempts = 0;

                    while (!placed && attempts < 100)
                    {
                        int x = random.Next(0, 10);
                        int y = random.Next(0, 10);
                        bool isVertical = random.Next(0, 2) == 0;

                        if (CanPlaceShip(x, y, size, isVertical))
                        {
                            PlaceShip(x, y, size, isVertical);
                            placed = true;
                        }
                        attempts++;
                    }

                    if (!placed)
                    {
                        success = false;
                        break;
                    }
                }
            }
        }

        private bool CanPlaceShip(int x, int y, int size, bool isVertical)
        {
            if (isVertical)
            {
                if (y + size > 10) return false;
            }
            else
            {
                if (x + size > 10) return false;
            }

            // Проверка пересечений и касаний
            for (int i = 0; i < size; i++)
            {
                int cx = isVertical ? x : x + i;
                int cy = isVertical ? y + i : y;

                // Проверяем клетку и всех её соседей
                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        int nx = cx + dx;
                        int ny = cy + dy;

                        // Если сосед в пределах поля и там уже есть корабль -> нельзя
                        if (nx >= 0 && nx < 10 && ny >= 0 && ny < 10)
                        {
                            if (MyField[nx, ny] != CellState.Empty) return false;
                        }
                    }
                }
            }
            return true;
        }

        private void PlaceShip(int x, int y, int size, bool isVertical)
        {
            List<Point> decks = new List<Point>();
            for (int i = 0; i < size; i++)
            {
                int cx = isVertical ? x : x + i;
                int cy = isVertical ? y + i : y;

                MyField[cx, cy] = CellState.Ship;
                decks.Add(new Point(cx, cy));
            }
            MyShips.Add(new Ship(decks));
        }

        public string ProcessEnemyShot(int x, int y)
        {
            if (MyField[x, y] == CellState.Ship)
            {
                MyField[x, y] = CellState.Hit;
                var ship = MyShips.FirstOrDefault(s => s.Decks.Contains(new Point(x, y)));
                if (ship != null)
                {
                    ship.Hits.Add(new Point(x, y));
                    if (ship.IsSunk) return "Sunk";
                }
                return "Hit";
            }
            else if (MyField[x, y] == CellState.Hit || MyField[x, y] == CellState.Miss)
            {
                return "Repeated";
            }

            MyField[x, y] = CellState.Miss;
            return "Miss";
        }
    }
}