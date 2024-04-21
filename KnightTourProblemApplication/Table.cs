﻿using KnightTourProblemApplication.DTOs;
using KnightTourProblemApplication.Enums;

namespace KnightTourProblemApplication
{
    public class Table
    {
        public Knight Knight { get; private set; }

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

        public bool AllTraversedPositions()
        {
            for (int x = 0; x < Positions.GetLength(0); x++)
                for (int y = 0; y < Positions.GetLength(1); y++)
                    if (!Positions[x, y])
                        return false;

            return true;
        }

        private MoveResultEnum NextMove()
        {
            Thread.Sleep(200);

            if (AllTraversedPositions())
                return MoveResultEnum.Complete;

            var knightMoves = Knight.GetMovements(n);
            var possiblesMoves = AvailableMoves(knightMoves);

            if (!possiblesMoves.Any())
                return MoveResultEnum.Fail;

            for (int i = 0; i < possiblesMoves.Length; i++)
            {
                var move = possiblesMoves[i];
                SetMove(move.x, move.y);
                
                SetCell?.Invoke(new CellDTO(Turn, move.x, move.y), EventArgs.Empty);

                Turn++;

                var result = NextMove();

                switch (result)
                {
                    case MoveResultEnum.Fail:

                        ClearCell?.Invoke(new CellDTO(Turn, move.x, move.y), EventArgs.Empty);

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

        private void UnsetMove(int x, int y)
        {
            Knight.Set(x, y);
            Positions[x, y] = false;
            Historic[Turn - 1] = default;
        }

        private void SetMove(int x, int y)
        {
            Knight.Set(x, y);
            Positions[x, y] = true;
            Historic[Turn - 1] = (x, y);
        }

        private void InitializeKnight()
        {
            // TO DO:

            //var random = new Random();
            //var knightX = random.Next(0, n - 1);
            //var knightY = random.Next(0, n - 1);

            //Knight = new Knight(knightX, knightY);

            Knight = new Knight(0, 0);
            SetMove(0, 0);
        }

    }
}