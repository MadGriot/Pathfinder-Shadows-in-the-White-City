
namespace PathfinderSecondEdition.Grid
{
    public class GridPosition : IEquatable<GridPosition>
    {

        public int X;
        public int Z;

        public GridPosition(int x, int z)
        {
            X = x;
            Z = z;
        }

        public override bool Equals(object obj)
        {
            return obj is GridPosition position &&
                X == position.X &&
                Z == position.Z;
        }

        public override string ToString()
        {
            return $"x: {X}; z: {Z}";
        }
        public bool Equals(GridPosition other) => this == other;
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Z);
        }


        public static bool operator ==(GridPosition a, GridPosition b)
        {
            return a.X == b.X && a.Z == b.Z;
        }

        public static bool operator !=(GridPosition a, GridPosition b)
        {
            return !(a == b);
        }

        public static GridPosition operator +(GridPosition a, GridPosition b)
        {
            return new GridPosition(a.X + b.X, a.Z + b.Z);
        }

        public static GridPosition operator -(GridPosition a, GridPosition b)
        {
            return new GridPosition(a.X - b.X, a.Z - b.Z);
        }
    }
}
