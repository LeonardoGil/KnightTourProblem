namespace KnightTourProblemConsole
{
    internal class Knight(int x, int y)
    {
        public int PositionX { get; private set; } = x;
        public int PositionY { get; private set; } = y;

        public (int x, int y)[] GetMovements(int tableN)
        {
            var moves = new (int, int)[]
            {
                MoveUpRight(),
                MoveUpLeft(),
                MoveDownRight(),
                MoveDownLeft(),

                MoveRightUp(),
                MoveRightDown(),
                MoveLeftUp(),
                MoveLeftDown()
            };
            
            // Movimentos dentro do tabuleiro
            return moves.Where(move => move.Item1 >= 0 && move.Item1 <= tableN - 1)
                        .Where(move => move.Item2 >= 0 && move.Item2 <= tableN - 1)
                        .Select(x => (x.Item1, x.Item2))
                        .ToArray();
        }

        public void Set(int x, int y)
        {
            PositionX = x;
            PositionY = y;
        }

        private (int x, int y) MoveUpRight() => (PositionX + 1, PositionY + 2);
        private (int x, int y) MoveUpLeft() => (PositionX - 1, PositionY + 2);

        private (int x, int y) MoveDownRight() => (PositionX + 1, PositionY - 2);
        private (int x, int y) MoveDownLeft() => (PositionX - 1, PositionY - 2);

        private (int x, int y) MoveRightUp() => (PositionX + 2, PositionY + 1);
        private (int x, int y) MoveRightDown() => (PositionX + 2, PositionY - 1);

        private (int x, int y) MoveLeftUp() => (PositionX - 2, PositionY + 1);
        private (int x, int y) MoveLeftDown() => (PositionX - 2, PositionY - 1);
    }
}
