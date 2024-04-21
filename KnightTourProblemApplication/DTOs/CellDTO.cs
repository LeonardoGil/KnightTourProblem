namespace KnightTourProblemApplication.DTOs
{
    public class CellDTO(int turn, int x, int y)
    {
        public readonly int Turn = turn;
        public readonly int X = x;
        public readonly int Y = y;
    }
}
