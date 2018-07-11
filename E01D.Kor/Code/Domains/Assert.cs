#region NUnit License

// ***********************************************************************
// Copyright (c) 2014 Charlie Poole, Rob Prouse
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ***********************************************************************
#endregion

using System;
using System.Diagnostics;
using Root.Code.Attributes.E01D;

namespace Root.Code.Domains
{
    /// <summary>
    /// Provides basic assertiion capability. 
    /// </summary>
    [KorType]
    public static partial class Assert
    {
        [DebuggerStepThrough]
        public static void IsNotNull(object expected)
        {
            if (expected == null) throw new Exception("Expected a non-null value.");
        }

        [DebuggerStepThrough]
        public static void AreEqual(int expected, int actual)
        {
            if (expected != actual)
            {
                throw new Exception($"Expected {expected} but is actually {actual}.");
            }
        }

        [DebuggerStepThrough]
        public static void AreEqual(uint expected, uint actual)
        {
            if (expected != actual)
            {
                throw new Exception($"Expected {expected} but is actually {actual}.");
            }
        }

        [DebuggerStepThrough]
        public static void AreEqual(string expected, string actual)
        {
            if (string.Compare(expected, actual, StringComparison.CurrentCulture) != 0)
            {
                throw new Exception($"Expected {expected} but is actually {actual}.");
            }
        }

        [DebuggerStepThrough]
        public static void AreEqual(bool expected, bool actual)
        {
            if (expected != actual)
            {
                throw new Exception($"Expected {expected} but is actually {actual}.");
            }
        }

        public static void AreSame(object expected, object actual)
        {
            if (!object.ReferenceEquals(expected, actual))
            {
                throw new Exception($"References are not equal.");
            }
        }

	    public static void IsTrue(bool actual)
	    {
			if (true != actual)
			{
				throw new Exception($"Expected {true} but is actually {false}.");
			}
		}

	    public static void IsFalse(bool actual)
	    {
		    if (actual)
		    {
			    throw new Exception($"Expected {false} but is actually {true}.");
		    }
	    }
	}
}
