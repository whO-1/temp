namespace AreaCalculator.Models
{
	public class Circle : GeometricFigure
	{
		private readonly double _radius;
		
		public Circle( double radius )
		{
			if (radius <= 0)
			{
				throw new ArgumentException("Radius must be greater than 0.");
			}
			_radius = radius;
		}
		public override double CalculateArea()
		{
			return Math.PI * Math.Pow(_radius, 2);
		}
	}
}
