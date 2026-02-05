namespace SeaBattle
{

    public enum CellState { Empty, Ship, Miss, Hit, Sunk }

    public enum GameStatus
    {
        Placement,
        WaitingForPeer,
        MyTurn,
        EnemyTurn,
        GameOver
    }
}