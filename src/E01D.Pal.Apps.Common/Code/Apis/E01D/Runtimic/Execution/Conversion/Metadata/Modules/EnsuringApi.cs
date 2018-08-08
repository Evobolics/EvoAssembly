using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Modules
{
    public class EnsuringApi<TContainer> : ConversionApiNode<TContainer>, EnsuringApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    public SemanticModuleMask_I EnsureAssignedModule(ILConversion conversion, System.Type type)
	    {
		    if (Types.IsCorlibType(type) && conversion.Configuration.DoNotConvertCorlib)
		    {
			    // return corlib module.
			    return EnsureModuleFromAssembly(conversion, type);
		    }
		    if (conversion.Configuration.IsConvertingTypeSet)
		    {
			    return conversion.TypeSetModule;
			    // conversion module
		    }

		    return EnsureModuleFromAssembly(conversion, type);
	    }

	    public SemanticModuleMask_I EnsureAssignedModule(ILConversion conversion, TypeReference typeReference)
	    {
		    if (Types.IsCorlibType(typeReference) && conversion.Configuration.DoNotConvertCorlib)
		    {
			    // return corlib module.
			    return EnsureModuleFromAssembly(conversion, typeReference);
		    }
		    if (conversion.Configuration.IsConvertingTypeSet)
		    {
			    return conversion.TypeSetModule;
			    // conversion module
		    }

		    return EnsureModuleFromAssembly(conversion, typeReference);
	    }

	    public SemanticModuleMask_I EnsureModuleFromAssembly(ILConversion conversion, System.Type type)
	    {
		    var resolutionName = Types.Naming.GetResolutionName(type);

		    var semanticType = Infrastructure.Models.Semantic.Types.Collection.Get(conversion.RuntimicSystem, resolutionName);

		    if (semanticType == null)
		    {
			    throw new System.Exception($"Assembly ensure does not support scope '{resolutionName}'");
		    }

		    return semanticType.Module;
	    }

	    public SemanticModuleMask_I EnsureModuleFromAssembly(ILConversion conversion, TypeReference typeReference)
	    {
		    var modulesAssembly = Assemblies.Ensuring.Ensure(conversion, typeReference);

		    return Models.Modules.GetModule(conversion, modulesAssembly, typeReference);
	    }

		//public List<SemanticModuleMask_I> EnsureModuleEntries(BoundAssemblyMask_I entry)
  //      {
  //          List<SemanticModuleMask_I> modules = new List<SemanticModuleMask_I>();

  //          if (entry.AssemblyDefinition != null)
  //          {
  //              // Create module entries that are based upon module definitions
  //              foreach (var moduleDefinition in entry.AssemblyDefinition.Modules)
  //              {
  //                  var moduleEntry = Modules.Creation.CreateModuleEntry(entry, moduleDefinition);

  //                  Modules.Addition.AddModule(moduleEntry);
  //              }

	 //           foreach (var module in entry.Modules.Values)
	 //           {
		            
	 //           }
  //          }
  //          else
  //          {
  //              // Create a module entry that is based upon the types, not based upon 
  //              // the module definition
  //              var moduleEntry = Modules.Creation.CreateModuleEntry(entry);

  //              Modules.Addition.AddModule(moduleEntry);
  //          }

  //          return modules;
  //      }
    }
}
