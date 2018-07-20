using System.IO;
using System.Reflection;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Assemblies
{
	public class CreatingApi<TContainer> : CecilApiNode<TContainer>, CreatingApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		/// <summary>
		/// Creates an assembly definition from an assembly.  It reads all of its bytes and creates a stream, which is then read.
		/// </summary>
		/// <param name="semanticModel"></param>
		/// <param name="assembly"></param>
		/// <returns></returns>
		public AssemblyDefinition Create(InfrastructureRuntimicModelMask_I semanticModel, Assembly assembly)
		{
			byte[] bytes = File.ReadAllBytes(assembly.Location);

			MemoryStream stream = new MemoryStream(bytes);

			semanticModel.Structural.Streams.Add(stream);




			return Create(semanticModel, stream);
		}

		/// <summary>
		/// Creates an assembly definition from a stream.
		/// </summary>
		/// <param name="semanticModel"></param>
		/// <param name="stream"></param>
		/// <returns></returns>
		public AssemblyDefinition Create(InfrastructureRuntimicModelMask_I semanticModel, Stream stream)
		{
			return AssemblyDefinition.ReadAssembly(stream);
		}
	}
}
