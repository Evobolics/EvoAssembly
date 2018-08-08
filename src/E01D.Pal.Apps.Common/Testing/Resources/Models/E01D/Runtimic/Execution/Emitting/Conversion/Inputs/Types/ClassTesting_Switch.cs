using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public class ClassTesting_Switch
	{
		public object Execute()
		{
			int a = 1;

			switch (a)
			{
				case 0:
				{
					return false;
				}
				case 1:
				{
					return true;
				}
				case 2:
				{
					return false;
				}
				case 3:
				{
					return false;
				}
				default:
				{
					return false;
				}
			}
		}
	}
}
