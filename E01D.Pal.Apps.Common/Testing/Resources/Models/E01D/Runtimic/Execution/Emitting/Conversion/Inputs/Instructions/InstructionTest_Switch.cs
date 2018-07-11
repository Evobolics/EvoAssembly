using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Instructions
{
	public class InstructionTest_Switch
	{
		public int Execute()
		{
			int sum = 0;

			for (int i = 0; i <= 10; i++)
			{

				switch (i)
				{
					case 0:
					{
						sum += 0;

						break;
					}
					case 1:
					{
						sum += 1;
						break;
					}
					case 2:
					{
						sum += 2;
						break;
					}
					case 3:
					{
						sum += 3;
						break;
					}
					case 4:
					{
						sum += 4;
						break;
					}
					case 5:
					{
						sum += 5;
						break;
					}
					case 6:
					{
						sum += 6;
						break;
					}
					case 7:
					{
						sum += 7;
						break;
					}
					case 8:
					{
						sum += 8;
						break;
					}
					case 9:
					{
						sum += 9;
						break;
					}
					case 10:
					{
						sum += 10;
						break;
					}
				}
			}

			return sum;
		}
	}
}
