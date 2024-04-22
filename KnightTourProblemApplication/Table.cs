using KnightTourProblemApplication.DTOs;
using KnightTourProblemApplication.Enums;

namespace KnightTourProblemApplication
{
    public class Table
    {
        public Knight _Knight { get; private set; }

        public int Turn { get; private set; } = 1;

        public MoveResultEnum Result { get; private set; }

        public readonly int n;

        public readonly (int x, int y)?[] Historic;

        public readonly bool[,] Positions;

        public event EventHandler SetCell;

        public event EventHandler ClearCell;

        public Table(int n)
        {
            this.n = n;
            Positions = new bool[this.n, this.n];
            Historic = new (int, int)?[n * n];
        }

        public void Start()
        {
            InitializeKnight();
            Result = NextMove();
        }

        public CheckRemainingCellsResult CheckRemainingCells()
        {
            var AllTraversedPositions = true;

            for (int x = 0; x < Positions.GetLength(0); x++)
                for (int y = 0; y < Positions.GetLength(1); y++)
                {
                    if (!Positions[x, y])
                    {
                        AllTraversedPositions = false;

                        if (Knight.GetMovements(n, x, y).Length == 0)
                            return CheckRemainingCellsResult.LockedCell;
                    }
                }

            return AllTraversedPositions ? CheckRemainingCellsResult.AllTraversedPositions : CheckRemainingCellsResult.none;
        }

        public int NumberOfMovesForTheNextMove(int x, int y)
        {
            var moves = Knight.GetMovements(n, x, y);
            moves = AvailableMoves(moves, x, y);

            return moves.Length;
        }


        private MoveResultEnum NextMove()
        {
            switch (CheckRemainingCells())
            {
                case CheckRemainingCellsResult.AllTraversedPositions:
                    return MoveResultEnum.Complete;

                case CheckRemainingCellsResult.LockedCell:
                    return MoveResultEnum.Fail;
            }

            var knightMoves = _Knight.GetMovements(n);
            var possiblesMoves = AvailableMoves(knightMoves);

            if (!possiblesMoves.Any())
                return MoveResultEnum.Fail;

            possiblesMoves = [.. possiblesMoves.OrderBy(move => NumberOfMovesForTheNextMove(move.x, move.y))];

            for (int i = 0; i < possiblesMoves.Length; i++)
            {
                var move = possiblesMoves[i];
                SetMove(move.x, move.y);
                Turn++;

                var result = NextMove();

                switch (result)
                {
                    case MoveResultEnum.Fail:
                        Turn--;
                        var lastMove = Historic[Turn - 1];
                        UnsetMove(lastMove.Value.x, lastMove.Value.y);
                        break;

                    case MoveResultEnum.Sucess:
                    case MoveResultEnum.Complete:
                        return result;
                }
            }

            return MoveResultEnum.Fail;
        }

        private (int x, int y)[] AvailableMoves((int x, int y)[] moves)
        {
            return moves.Where(move => !Positions[move.x, move.y]).ToArray();
        }

        private (int x, int y)[] AvailableMoves((int x, int y)[] moves, int nextMoveX, int nextMoveY)
        {
            return moves.Where(move => !Positions[move.x, move.y] || (!(nextMoveX == move.x && nextMoveY == move.y))).ToArray();
        }

        private void UnsetMove(int x, int y)
        {
            _Knight.Set(x, y);
            Positions[x, y] = false;
            Historic[Turn - 1] = default;

            ClearCell?.Invoke(new CellDTO(Turn, x, y), EventArgs.Empty);
        }

        private void SetMove(int x, int y)
        {
            _Knight.Set(x, y);
            Positions[x, y] = true;
            Historic[Turn - 1] = (x, y);

            SetCell?.Invoke(new CellDTO(Turn, x, y), EventArgs.Empty);
        }

        private void InitializeKnight()
        {
            // TO DO:

            //var random = new Random();
            //var knightX = random.Next(0, n - 1);
            //var knightY = random.Next(0, n - 1);

            //Knight = new Knight(knightX, knightY);

            _Knight = new Knight(0, 0);
            SetMove(0, 0);
        }

    }
    public enum CheckRemainingCellsResult
    {
        none = 0,

        AllTraversedPositions = 1,

        LockedCell = 2
    }
}
