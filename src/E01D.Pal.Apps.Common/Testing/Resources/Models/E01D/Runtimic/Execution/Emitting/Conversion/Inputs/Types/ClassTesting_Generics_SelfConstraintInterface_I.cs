using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
    public interface ClassTesting_Generics_SelfConstraintInterface_I<TContainer>
        where TContainer: ClassTesting_Generics_SelfConstraintInterface_I<TContainer>
    {
    }
}
