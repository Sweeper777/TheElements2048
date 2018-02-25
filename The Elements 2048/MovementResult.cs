using System;
namespace The_Elements_2048
{
    public struct MovementResult
    {
        public bool Merged { get; }
        public int DistanceMoved { get; }

        public MovementResult(bool merged, int distanceMoved)
        {
            Merged = merged;
            DistanceMoved = distanceMoved;
        }
    }
}
