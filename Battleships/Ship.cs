using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SeaBattle
{
    public class Ship
    {
        public List<Point> Decks { get; set; } = new List<Point>();
        public List<Point> Hits { get; set; } = new List<Point>();
        public bool IsSunk => Decks.Count == Hits.Count;

        public Ship(IEnumerable<Point> points)
        {
            Decks.AddRange(points);
        }
    }
}