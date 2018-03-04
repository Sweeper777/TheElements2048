using System;
namespace The_Elements_2048
{
    public class BoardPosition : IEquatable<BoardPosition>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public BoardPosition(int x, int y)
        {
            X = x;
            Y = y;
        }

    }
}
