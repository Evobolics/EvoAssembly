using System;
using System.Reflection;
using System.Reflection.Emit;
using Root.Code.Attributes.E01D;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Domains.E01D;
using Root.Code.Exts.Runtimic;
using Root.Code.PI.E01D;

namespace Root.Testing.Tests.Apis.E01D.Runtimic.Execution.Emitting.Conversion.Inputs
{
	public class AssemblyTests
	{
		[Test]
		public void Convert_EvoPalAppsCommon()
		{
			// 1) Create a conversion container
			var container = EvoAssembly.CreateContainer();

			// 2) Create a conversion container
		    //var collectibleAssembly = container.Convert(typeof(AssemblyTests).Assembly, AssemblyBuilderAccess.RunAndSave);

			var collectibleAssembly = container.Convert(typeof(AssemblyTests).Assembly, AssemblyBuilderAccess.RunAndCollect);

			// c prefix for converted.
			

			var modules = collectibleAssembly.GetModules();

			var module = modules[0];

			var collectibleAssemblyBuilder = (AssemblyBuilder)collectibleAssembly;

			//collectibleAssemblyBuilder.Save(module.ScopeName);

			var cEvoAssembly = XCommonAppPal.Api.Runtimic.Execution.Metadata.Assemblies.GetTypeInAssembly(collectibleAssembly, typeof(EvoAssembly));

			var createContainerMethod = cEvoAssembly.GetMethod("CreateContainer", BindingFlags.Public | BindingFlags.Static, null, new [] {typeof(bool)}, null);

			var cContainer = createContainerMethod.Invoke(null, new object[] {true });

			var cRuntimicContainer = XCommonAppPal.Api.Runtimic.Execution.Metadata.Assemblies.GetTypeInAssembly(collectibleAssembly, typeof(RuntimicContainer));

			var cRuntimicContainerExts = XCommonAppPal.Api.Runtimic.Execution.Metadata.Assemblies.GetTypeInAssembly(collectibleAssembly, typeof(RuntimicContainerExts));

			var convertMethod = cRuntimicContainerExts.GetMethod("Convert", BindingFlags.Public | BindingFlags.Static, null
				 , new Type[]{ cRuntimicContainer, typeof(System.Reflection.Assembly),  typeof(AssemblyBuilderAccess) }, null);

			var result = convertMethod.Invoke(null, new []{cContainer, typeof(AssemblyTests).Assembly, AssemblyBuilderAccess.RunAndCollect});

			

			//try
			//{
			//	var types = collectibleAssembly.GetTypes();
			//}
			//catch (System.Reflection.ReflectionTypeLoadException e)
			//{
			//	//for (int j = 0; j < e.LoaderExceptions.Length; j++)
			//	//{
			//	//	Console.WriteLine(e.LoaderExceptions[j].Message);
			//	//}

			//	throw e.LoaderExceptions[0];
			//}
		}
	}
}
