using System;
using System.Reflection;
using System.Reflection.Emit;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
	public class CreationApi<TContainer> : ConversionApiNode<TContainer>, CreationApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
        

        

        /// <summary>
        /// Creates a converted assembly from  a collection of types that are passed into the the conversion.
        /// </summary>
        /// <param name="conversion"></param>
        /// <returns></returns>
		public ConvertedAssembly CreateConvertedAssembly(ILConversion conversion)
		{
			var name = Assemblies.Naming.GetAssemblyName(conversion, "typeCollection_" + Guid.NewGuid().ToString("N"));

			return CreateConvertedAssembly(conversion, name, null);
		}

        

        public ConvertedAssembly CreateConvertedAssembly(ILConversion conversion, string name, ConvertedAssemblyNode assemblyNode)
        {

            // compiler crash / compiler error - do not put this line with initializer.
            // If you use a fullname with version, public key, etc.  It will crash the compiler
            var builder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(name), conversion.Configuration.BuilderAccess);

            var convertedAssembly = new ConvertedAssembly()
            {
                AssemblyBuilder = builder,
                Name = name,
                FullName = name,
                AssemblyNode = assemblyNode,
                Conversion = conversion,
            };

            return convertedAssembly;
        }


    }
}
