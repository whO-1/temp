namespace AreaCalculator.Models
{
	public class Square : GeometricFigure
	{
		private readonly double _side;
		
		public Square(double side)
		{
			_side = side;
		}

		public override double CalculateArea()
		{
			return Math.Pow(_side, 2); 
		}
	}
}
