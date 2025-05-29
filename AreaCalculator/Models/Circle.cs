namespace AreaCalculator.Models
{
	public class Circle : IGeometricFigure
	{
		private readonly int _radius;
		public virtual double Area
		{
			get {  return Math.PI*Math.Pow(_radius,2); }
		}

		public Circle( int radius )
		{
			_radius = radius;
		}
	}
}
