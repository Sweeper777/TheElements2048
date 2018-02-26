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
}
