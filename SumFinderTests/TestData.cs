namespace SumFinderTests
{
	public class TestData
	{
		public static IEnumerable<object[]> TestLists
		{
			get
			{
				yield return new object[] { new List<uint> { 1, 2, 3 }, (uint) 100, 0, 0 };                     // Too great sum
				yield return new object[] { new List<uint> { 200, 500, 600 }, (uint)13, 0, 0 };                 // Too great numbers
				yield return new object[] { new List<uint> { 0, 5, 10 }, (uint)0, 0, 0 };						// 0 sum
				yield return new object[] { new List<uint> { 1000, 2000, 10, 3000, 4000 }, (uint)10, 2, 3 };    // One number sum 
				yield return new object[] { new List<uint> { 20, 40, 100, 300, 200 }, (uint)60, 0, 2 };         // Beginning distribution
				yield return new object[] { new List<uint> { 10, 20, 30, 40 }, (uint)50, 1, 3 };                // Middle distribution sum
				yield return new object[] { new List<uint> { 1000, 2000, 100, 30, 20 }, (uint)50, 3, 5 };       // Ending distribution
				yield return new object[] { new List<uint> { 2, 5, 6 }, (uint)13, 0, 3 };                       // Entire list distribution
			}
		}
	}
}
