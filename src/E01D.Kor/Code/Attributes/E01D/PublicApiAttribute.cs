using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root.Code.Attributes.E01D
{
	/// <summary>
	/// Marks a public api that has an interface that is not arbitrary.  If the interface needs to be changed, an method overload should be considered instead
	/// of a name change.
	/// </summary>
	public class PublicApiAttribute:System.Attribute
	{

	}
}
