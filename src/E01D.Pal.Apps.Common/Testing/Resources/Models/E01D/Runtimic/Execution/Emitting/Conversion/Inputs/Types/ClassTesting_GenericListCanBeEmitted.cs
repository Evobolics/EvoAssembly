using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
    public class ClassTesting_GenericListCanBeEmitted
    {
        public Type a;

        public ClassTesting_GenericListCanBeEmitted()
        {
            new List<int>();

            new Dictionary<string, string>();

            a = typeof(Dictionary<string, string>);

            a = typeof(Dictionary<,>);
        }

        
    }
}
