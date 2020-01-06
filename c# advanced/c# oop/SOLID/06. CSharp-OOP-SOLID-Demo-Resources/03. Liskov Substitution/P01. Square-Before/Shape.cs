namespace P01._Square_Before
{
    public abstract class Shape
    {
        public abstract double Area { get; }


        public virtual double Width { get; set; }

        public virtual double Height { get; set; }
    }
}