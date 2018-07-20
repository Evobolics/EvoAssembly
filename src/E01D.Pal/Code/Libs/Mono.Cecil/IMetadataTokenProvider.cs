//
// Author:
//   Jb Evain (jbevain@gmail.com)
//
// Copyright (c) 2008 - 2015 Jb Evain
// Copyright (c) 2008 - 2011 Novell, Inc.
//
// Licensed under the MIT/X11 license.
//

using Root.Code.Libs.Mono.Cecil.Metadata;

namespace Root.Code.Libs.Mono.Cecil {

	public interface IMetadataTokenProvider {

		MetadataToken MetadataToken { get; set; }
	}
}
