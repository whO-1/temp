using SF = SumFinder.SumFinder;

namespace SumFinderTests
{
	[TestFixture]
	public class SumFinderTests
	{

		[Test, TestCaseSource(typeof(TestData), nameof(TestData.TestLists))]
		public void FindElementsForSum_WorksCorrect(List<uint> inputList, uint sum, int  expStart, int expEnd)
		{
			//Arrange

			inputList.ForEach(x => Console.WriteLine(x));
			Console.WriteLine("Sum: " + sum);

			//Act
			SF.FindElementsForSum(inputList, sum, out int start, out int end);

			Console.WriteLine("Start: " + start);
			Console.WriteLine("End: " + end);
			//Assert

			Assert.That(start, Is.EqualTo(expStart));
			Assert.That(end, Is.EqualTo(expEnd));
		}
	}
}
