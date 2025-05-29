namespace AreaCalculator.Models
{
	public abstract class GeometricFigure : IGeometricFigure
	{
		private double? _cachedArea = null;
		public double Area {
			get
			{
				if (_cachedArea is not null)
				{
					return _cachedArea.Value;
				}

				_cachedArea = CalculateArea();
				return _cachedArea.Value;
			}
		}

		public abstract double CalculateArea();
		public GeometricFigure() { }
	}
}
