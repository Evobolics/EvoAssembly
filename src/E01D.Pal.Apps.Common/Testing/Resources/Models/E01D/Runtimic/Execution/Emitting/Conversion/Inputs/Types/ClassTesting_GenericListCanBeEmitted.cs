using System;
using System.Collections.Generic;

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
