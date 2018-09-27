namespace LibTest
{
    public struct Point2
    {
        public double X;
        public double Y;

        public Point2(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Point2 p1, Point2 p2)
            => p1.X == p2.X && p1.Y == p2.Y;

        public static bool operator !=(Point2 p1, Point2 p2)
            => !(p1 == p2);
    }
}