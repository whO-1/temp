using AreaCalculator.Models;

namespace GeometryTests
{
	public class UnknownShapeTests
	{
		[Test]
		public void Constructor_NegativeValues_ArgumentException()
		{
			//Arrange

			var sides = new List<double> { -5, 6, 7 };
			var angles = new List<double> { 60, 60, 60 };

			//Act & Assert

			var ex = Assert.Throws<ArgumentException>(() => new UnknowShape(sides, angles));
			Assert.That(ex.Message, Does.Contain("Invalid values for sides."));
		}

		[Test]
		public void Constructor_TooFewSides_ArgumentException()
		{
			//Arrange

			var sides = new List<double> { 3, 4 };
			var angles = new List<double> { 60, 60 };

			//Act & Assert

			var ex = Assert.Throws<ArgumentException>(() => new UnknowShape(sides, angles));
			Assert.That(ex.Message, Does.Contain("Invalid number of sides."));
		}

		[Test]
		public void Constructor_SidesAndAnglesCountMismatch_ArgumentException()
		{
			//Arrange

			var sides = new List<double> { 3, 4, 5 };
			var angles = new List<double> { 60, 60 };

			//Act & Assert

			var ex = Assert.Throws<ArgumentException>(() => new UnknowShape(sides, angles));
			Assert.That(ex.Message, Does.Contain("Invalid number of sides or angles."));
		}

		[Test]
		public void CalculateArea_ValidInput_ReturnsCorrectArea()
		{
			//Arrange
			var sides = new List<double> { 3, 4, 5 };
			var angles = new List<double> { 60, 60, 60 };

			var shape = new UnknowShape(sides, angles);
			var expected = 0.5 * 4 * 5 * Math.Sin(60 * Math.PI / 180);

			//Act
			double area = shape.Area;

			//Assert
			Assert.That(area, Is.EqualTo(expected).Within(0.01));
		}
	}
}
