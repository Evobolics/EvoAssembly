using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Models
{
    public class ModelApi<TContainer> : RuntimeApiNode<TContainer>, ModelApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        /// <summary>
        /// An outside process can make a call into a subsystem that uses a runtimic system.  If runtimic system is not
        /// passed into the call, then this method ensures that the one the call makes is adequently built out.
        /// </summary>
        /// <param name="runtamicSystem"></param>
        public void EnsureMinimumRuntimicSystem(RuntimicSystemModel runtamicSystem)
        {
            if (runtamicSystem.TypeSystems == null)
            {
                runtamicSystem.TypeSystems = new RuntimicTypeSystemModel();
            }

            if (runtamicSystem.Identification == null)
            {
                runtamicSystem.Identification = new RuntimicIdentificationModel();
            }

            if (runtamicSystem.Io == null)
            {
                runtamicSystem.Io = new RuntimicIoModel();
            }

            if (runtamicSystem.TypeSystems.Conversional == null)
            {
                runtamicSystem.TypeSystems.Conversional = new ConversionSystemModel();
            }

            if (runtamicSystem.TypeSystems.Bound == null)
            {
                runtamicSystem.TypeSystems.Bound = new BoundSystemModel();
            }

            if (runtamicSystem.TypeSystems.Semantic == null)
            {
                runtamicSystem.TypeSystems.Semantic = new SemanticSystemModel();
            }

            if (runtamicSystem.TypeSystems.Structural == null)
            {
                runtamicSystem.TypeSystems.Structural = new StructuralSystemModel();
            }

           

            if (runtamicSystem.TypeSystems.Unified == null)
            {
                runtamicSystem.TypeSystems.Unified = new UnifiedSystemModel();
            }
        }
    }
}
