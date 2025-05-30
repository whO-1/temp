namespace SumFinder
{
    public static class SumFinder
    {


		public static void FindElementsForSum(List<uint> list, ulong sum, out int start, out int end)
		{
			start = 0;
			end = 0;

			int tempStart = 0;
			int tempEnd = 0;
			uint tempSum = 0;
			uint min = list[tempStart];

			while( !(tempStart >= list.Count || tempStart == 0 && tempEnd >= list.Count) )
			{
				if(tempSum > sum)
				{
					if (list[tempEnd - 1] + min >= sum)
					{
						tempSum = 0;
						tempStart = tempEnd;
					}
					else
					{
						tempSum -= list[tempStart];
						tempStart++;
					}
				}	
				else if(tempSum < sum)
				{
					if (list[tempEnd] < min)
					{
						min = list[tempEnd];
					}

					tempSum += list[tempEnd];
					tempEnd++;
				}

				if(tempSum == sum)
				{
					start = tempStart;
					end = tempEnd;
					break;
				}
			}

		}

	}
}
