using System;
using System.Collections.Generic;

namespace Root.Code.Apis.E01D.Sorting
{
	public interface QuickApiMask_I
	{
		void Sort<T>(List<T> assemblyList, Func<T, T, long> func);
	}
}
