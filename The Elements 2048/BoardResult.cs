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
