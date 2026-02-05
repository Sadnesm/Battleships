namespace SeaBattle
{
    public class GameMessage
    {
        public string Type { get; set; } // "Shot", "Result", "Start"
        public int X { get; set; }
        public int Y { get; set; }
        public string Status { get; set; } // "Hit", "Miss", "Sunk"
    }
}