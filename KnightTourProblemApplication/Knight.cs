namespace KnightTourProblemApplication
{
    public class Knight(int x, int y)
    {
        public int PositionX { get; private set; } = x;
        public int PositionY { get; private set; } = y;

        public (int x, int y)[] GetMovements(int tableN)
        {
            var moves = new (int, int)[]
            {
                MoveUpRight(PositionX, PositionY),
                MoveUpLeft(PositionX, PositionY),
                MoveDownRight(PositionX, PositionY),
                MoveDownLeft(PositionX, PositionY),

                MoveRightUp(PositionX, PositionY),
                MoveRightDown(PositionX, PositionY),
                MoveLeftUp(PositionX, PositionY),
                MoveLeftDown(PositionX, PositionY)
            };

            return PossibleMovesReturn(moves, tableN);
        }

        public static (int x, int y)[] GetMovements(int tableN, int x, int y)
        {
            var moves = new (int, int)[]
            {
                MoveUpRight(x, y),
                MoveUpLeft(x, y),
                MoveDownRight(x, y),
                MoveDownLeft(x, y),

                MoveRightUp(x, y),
                MoveRightDown(x, y),
                MoveLeftUp(x, y),
                MoveLeftDown(x, y)
            };

            return PossibleMovesReturn(moves, tableN);
        }

        public void Set(int x, int y)
        {
            PositionX = x;
            PositionY = y;
        }

        private static (int x, int y)[] PossibleMovesReturn((int, int)[] moves, int tableN)
        {
            // Movimentos dentro do tabuleiro
            return moves.Where(move => move.Item1 >= 0 && move.Item1 <= tableN - 1)
                        .Where(move => move.Item2 >= 0 && move.Item2 <= tableN - 1)
                        .Select(x => (x.Item1, x.Item2))
                        .ToArray();
        }

        private static (int x, int y) MoveUpRight(int x, int y) => (x + 1, y + 2);
        private static (int x, int y) MoveUpLeft(int x, int y) => (x - 1, y + 2);

        private static (int x, int y) MoveDownRight(int x, int y) => (x + 1, y - 2);
        private static (int x, int y) MoveDownLeft(int x, int y) => (x - 1, y - 2);

        private static (int x, int y) MoveRightUp(int x, int y) => (x + 2, y + 1);
        private static (int x, int y) MoveRightDown(int x, int y) => (x + 2, y - 1);

        private static (int x, int y) MoveLeftUp(int x, int y) => (x - 2, y + 1);
        private static (int x, int y) MoveLeftDown(int x, int y) => (x - 2, y - 1);
    }
}
