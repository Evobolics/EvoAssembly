//
// Author:
//   Jb Evain (jbevain@gmail.com)
//
// Copyright (c) 2008 - 2015 Jb Evain
// Copyright (c) 2008 - 2011 Novell, Inc.
//
// Licensed under the MIT/X11 license.
//

namespace Root.Code.Libs.Mono.Cecil.Metadata {

	public abstract class Heap {

		public int IndexSize;

		public readonly byte [] data;

		protected Heap (byte [] data)
		{
			this.data = data;
		}
	}
}
