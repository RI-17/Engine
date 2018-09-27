namespace LibTest
{
    public struct Point2
    {
        public readonly int X;
        public readonly int Y;

        public static Point2 Zero = new Point2(0, 0);

        public Point2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Point2 p1, Point2 p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        public static bool operator !=(Point2 p1, Point2 p2)
        {
            return !(p1 == p2);
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }
        
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj.GetType() != typeof(Point2)) return false;
            return Equals((Point2)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }
    }
}