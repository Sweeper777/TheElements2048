using System;
namespace The_Elements_2048
{
    public struct BoardResult
    {
        public Element[,] Board { get; }
        public MovementResult[,] Movements { get; }

        public BoardResult(Element[,] board, MovementResult[,] movements)
        {
            Board = board;
            Movements = movements;
        }
        public BoardResult RotateCounterClockwise() {
            return new BoardResult(Board.RotateCounterClockwise(), Movements.RotateCounterClockwise());
        }

        public BoardResult RotateClockwise()
        {
            return new BoardResult(Board.RotateClockwise(), Movements.RotateClockwise());
        }
    }

    public struct RowResult {
        public Element[] Row { get; }
        public MovementResult[] Movements { get; }

        public RowResult(Element[] row, MovementResult[] movements)
        {
            Row = row;
            Movements = movements;
        }
    }
}
