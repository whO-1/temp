using AreaCalculator.Models;
using Moq;

namespace GeometryTests
{
	public class CircleTests
	{
		[Test]
		public void Circle_InvalidRadius_ThrowsException()
		{
			//Arrange
			double r = -2;
			var circleMock = new Mock<Circle>(r);
			circleMock.CallBase = true;
			//Act & Assert
			var ex = Assert.Throws<ArgumentException>(() => new Circle(r));
			Assert.That(ex.Message, Does.Contain("Radius must be greater than 0."));
		}

		[Test]
		public void CalculateArea_Result_IsCached()
		{
			//Arrange
			double r = 6;
			var circleMock = new Mock<Circle>(r);
			circleMock.CallBase = true;
			//Act
			var result = circleMock.Object.Area;
			var result2 = circleMock.Object.Area;
			//Assert

			Assert.That(result.Equals(Math.PI * Math.Pow(r, 2)));
			circleMock.Verify(obj => obj.CalculateArea(), Times.Exactly(1));
		}
	}
}
