
namespace AreaCalculator.Models
{
	public class UnknowShape : IGeometricFigure
	{
		private List<double> _sides;
		private List<double> _angles;

		public virtual double Area
		{
			get
			{
				double area = 0;
				int length = _sides.Count;
				int anglesNr = _angles.Count;

				if (length <= 2 || anglesNr <= 2)
				{
					throw new ArgumentException("Invalid nr of sides or angles.");
				}

				for (int sideNumber = 1; sideNumber < _sides.Count - 1; sideNumber++)
				{
					area += 0.5 * _sides[sideNumber] * _sides[sideNumber + 1] * (Math.Sin(_angles[sideNumber] * Math.PI / 180));
				}

				return area;
			}
		}

		public UnknowShape(List<double> sides, List<double> angles)
		{
			_sides = sides;
			_angles = angles;
		}
	}
}
