using Root.Code.Apis.E01D.Runtimic.Execution.Bound.Models.Types;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Models
{
	public class ModelApi<TContainer> : BoundApiNode<TContainer>, ModelApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
        public new ModelAssembliesApi_I<TContainer> Assemblies { get; set; }


        ModelAssembliesApiMask_I ModelApiMask_I.Assemblies => Assemblies;

        public new ModelModulesApi_I<TContainer> Modules { get; set; }


        ModelModulesApiMask_I ModelApiMask_I.Modules => Modules;

        public new ModelTypesApi_I<TContainer> Types { get; set; }
        

        ModelTypesApiMask_I ModelApiMask_I.Types => Types;

        //public void AddAssemblyDefinition(SemanticModelMask_I semanticModel, AssemblyDefinition assemblyDefinition)
        //{
        //    if (assemblyDefinition == null) return;

        //    if (semanticModel.Assemblies.Definitions.ContainsKey(assemblyDefinition.FullName)) return;

        //    semanticModel.Assemblies.Definitions.Add(assemblyDefinition.FullName, assemblyDefinition);

        //    for (int i = 0; i < assemblyDefinition.Modules.Count; i++)
        //    {
        //        var module = assemblyDefinition.Modules[i];

        //        for (int j = 0; j < module.Types.Count; j++)
        //        {
        //            var type = module.Types[j];

        //            if (j == 19)
        //            {
                        
        //            }
                                        
        //            if (type.FullName == "Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types.SimpleGenericClass`1")
        //            {

        //            }

        //            Types.Ensure(semanticModel, assemblyDefinition, module, type);

        //            if (!type.HasNestedTypes) continue;

        //            for (int k = 0; k < type.NestedTypes.Count; k++)
        //            {
        //                var nestedType = type.NestedTypes[k];

        //                Types.Ensure(semanticModel, assemblyDefinition, module, nestedType);
        //            }
        //        }
        //    }
        //}

        
    }
}
