using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members;

namespace Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members
{
	public interface ExecutionType_I: ExecutionMember_I, Type_I
	{
		//new string AssemblyQualifiedName { get; set; }

		//new string FullName { get; set; }
	}
}
