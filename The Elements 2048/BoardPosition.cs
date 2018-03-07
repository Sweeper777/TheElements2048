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

        public bool Equals(BoardPosition other)
        {
            return other.X == X && other.Y == Y;
        }

        public override bool Equals(object obj) => obj as BoardPosition != null && Equals(other: obj as BoardPosition);

        public override int GetHashCode()
        {
            return X + 1000 + Y;
        }

        public static bool operator ==(BoardPosition lhs, BoardPosition rhs) {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(BoardPosition lhs, BoardPosition rhs)
        {
            return !(lhs == rhs);
        }
    }
}
