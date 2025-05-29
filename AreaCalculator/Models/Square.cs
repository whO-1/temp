namespace AreaCalculator.Models
{
	public class Square : IGeometricFigure
	{
		private int _side;
		public virtual double Area
		{
			get { return Math.Pow(_side, 2); }
		}

		public Square(int side)
		{
			_side = side;
		}
	}
}
