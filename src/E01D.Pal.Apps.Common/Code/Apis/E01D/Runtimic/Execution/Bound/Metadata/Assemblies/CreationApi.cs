﻿using System.Reflection;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Assemblies
{
	public class CreationApi<TContainer> : BoundApiNode<TContainer>, CreationApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {

		/// <summary>
		/// 
		/// </summary>
		/// <param name="semanticModel"></param>
		/// <param name="assemblyDefinition"></param>
		/// <returns></returns>
		/// <remarks>The only way an semantic assembly should be created is via the use of an assembly definition.  This forces the structural model to be 
		/// updated to include the assembly definition first. </remarks>
		public BoundAssemblyMask_I CreateAssemblyEntry(InfrastructureRuntimicModelMask_I semanticModel, AssemblyDefinition assemblyDefinition, Assembly assembly)
        {
            var boundAssembly = new BoundAssembly()
            {
                Name = assemblyDefinition.Name.Name,
                FullName = assemblyDefinition.FullName,
                AssemblyDefinition = assemblyDefinition,
				Assembly = assembly,
                ObjectNetwork = semanticModel,
            };

            

            return boundAssembly;
        }
    }
}
