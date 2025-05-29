
using System.Collections.Generic;

namespace AreaCalculator.Models
{
	public class UnknowShape : GeometricFigure
	{
		private readonly List<double> _sides;
		private readonly List<double> _angles;

		public UnknowShape(List<double> sides, List<double> angles)
		{
			if (sides.Min() <= 0) throw new ArgumentException("Invalid values for sides.");
			if (sides.Count <= 2) throw new ArgumentException("Invalid number of sides.");
			if (sides.Count != angles.Count) throw new ArgumentException("Invalid number of sides or angles.");

			_sides = sides;
			_angles = angles;
		}

		public override double CalculateArea()
		{
			double area = 0;
			int length = _sides.Count;
			int anglesNr = _angles.Count;

			for (int sideNumber = 1; sideNumber < _sides.Count - 1; sideNumber++)
			{
				area += 0.5 * _sides[sideNumber] * _sides[sideNumber + 1] * (Math.Sin(_angles[sideNumber] * Math.PI / 180));
			}

			return area;
		}
	}
}
