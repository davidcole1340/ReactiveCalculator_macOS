namespace ALA.Xamarin.Mac.ProgrammingParagadims
{
    public struct Thickness
    {
        public double Left { get; set; }
        public double Top { get; set; }
        public double Right { get; set; }
        public double Bottom { get; set; }

        public Thickness(double uniform)
        {
            Left = Top = Right = Bottom = uniform;
        }

        public Thickness(double left, double top, double right, double bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }
    }
}