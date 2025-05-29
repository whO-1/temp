namespace AreaCalculator.Models
{
	public class Triangle : GeometricFigure
	{
		private readonly List<double> _sides;

		private bool? _cachedIsRightAngle = null; 
		public bool IsRightAngle 
		{
			get
			{
				if (_cachedIsRightAngle == null)
				{
					double max = _sides.Max();
					_sides.IndexOf(max);
					_cachedIsRightAngle = _sides.Where(x => x != max).Select(x => x * x).Sum().Equals(max * max);
				}

				return _cachedIsRightAngle.Value;
			}
		} 
		
		public Triangle( List<double> sides ) 
		{
			if (sides.Count != 3 ) throw new ArgumentException("Invalid nr of sides for a trinagle.");
			if (sides.Min() <= 0) throw new ArgumentOutOfRangeException("Invalid values for sides.");
			_sides = sides;
		}

		public override double CalculateArea()
		{
			double s = _sides.Sum()/2;  
			return Math.Sqrt(s * (s-_sides[0])*(s - _sides[1]) * (s - _sides[2]));	// --> Heron formula
		}
	}
}
