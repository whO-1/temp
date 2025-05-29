using AreaCalculator.Models;
using Moq;

namespace GeometryTests
{
	public class TriangleTests
	{
		[Test]
		public void Triangle_InvalidSidesValue_ThrowsException()
		{
			//Arrange
			List<double> sides = [-26, 5, 2];
			var circleMock = new Mock<Triangle>(sides);
			circleMock.CallBase = true;
			//Act & Assert
			var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Triangle(sides));
			Assert.That(ex.Message, Does.Contain("Invalid values for sides."));
		}
		[Test]
		public void Triangle_InvalidSidesNumber_ThrowsException()
		{
			//Arrange
			List<double> sides = [6,5,4,2];
			var circleMock = new Mock<Triangle>(sides);
			circleMock.CallBase = true;
			//Act & Assert
			var ex = Assert.Throws<ArgumentException>(() => new Triangle(sides));
			Assert.That(ex.Message, Does.Contain("Invalid nr of sides for a trinagle."));
		}

		[Test]
		public void CalculateArea_Result_IsCached()
		{
			//Arrange
			List<double> sides = [3,4,5];
			var circleMock = new Mock<Triangle>(sides);
			circleMock.CallBase = true;
			//Act
			var result = circleMock.Object.Area;
			var result2 = circleMock.Object.Area;
			//Assert

			Assert.That(result.Equals(6));
			circleMock.Verify(obj => obj.CalculateArea(), Times.Exactly(1));
		}

		[Test]
		public void IsRightAngle_WorksCorrect()
		{
			//Arrange
			List<double> sides1 = [5, 12, 13];
			List<double> sides2 = [5, 7, 13];
			var RightAngleCircleMock = new Mock<Triangle>(sides1);
			var NotRightAngleCircleMock = new Mock<Triangle>(sides2);
			RightAngleCircleMock.CallBase = true;
			NotRightAngleCircleMock.CallBase = true;
			//Act
			var result = RightAngleCircleMock.Object.IsRightAngle;
			var result2 = NotRightAngleCircleMock.Object.IsRightAngle;

			//Assert

			Assert.That(result.Equals(true));
			Assert.That(result2.Equals(false));
		}
	}
}
