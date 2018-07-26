using System;
using System.Reflection;
using System.Reflection.Emit;
using Root.Code.Attributes.E01D;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Assemblies
{
    public class AssemblyDomainApi
    {
        [Task("Make it able to return a PAL assembly.")]
        [Task("Make app domain access a PAL method call.")]
        public Assembly FindAssemblyInAppDomain(string fullAssemblyName)
        {
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var loadedAssembly in loadedAssemblies)
            {
                if (loadedAssembly.FullName == fullAssemblyName)
                {
                    return loadedAssembly;
                }
            }

            return null;
        }

	    public Assembly FindAssembly(string fullName)
	    {
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();

		    Assembly assembly = FindAssemblyInAppDomain(fullName);

		    if (assembly != null) return assembly;

			try
			{
				// Attempt to load from GAC
				assembly = Assembly.Load(fullName);
			}
			catch (Exception)
			{


			}
		    

		    if (assembly == null)
		    {
			    throw new NotSupportedException($"Could not resolve assembly reference '{fullName}'.");
		    }

		    return assembly;
	    }

        public Type GetTypeInAssembly(Assembly assembly, Type type)
        {
	        Type[] types;

	        try
	        {
		        types = assembly.GetTypes();
	        }
	        catch (System.Reflection.ReflectionTypeLoadException e)
	        {
		        for (int j = 0; j < e.LoaderExceptions.Length; j++)
		        {
			        Console.WriteLine(e.LoaderExceptions[j].Message);
		        }


		        throw e.LoaderExceptions[0];
	        }
			

            return GetTypeInAssembly(types, type);
        }

        public Type GetTypeInAssembly(Type[] types, Type type)
        {
            if (type.IsGenericType && !type.IsGenericTypeDefinition)
            {
                var genericTypeDefinition = type.GetGenericTypeDefinition();

                var genericTypeDefinitionInAssembly = GetTypeInAssembly(types, genericTypeDefinition);

                if (genericTypeDefinitionInAssembly == null) return null;

                var arguments = type.GenericTypeArguments;

                var argumentsInAssembly = new Type[arguments.Length];

                for (int i = 0; i < arguments.Length; i++)
                {
                    var argument = arguments[i];

                    argumentsInAssembly[i] = GetTypeInAssembly(types, argument);

                    if (argumentsInAssembly[i] == null)
                    {
                        argumentsInAssembly[i] = GetTypeInCorLib(argument);

                        if (argumentsInAssembly[i] == null)
                        {
                            throw new Exception($"Could not find type {argument.FullName} in assembly or mscorlib.");
                        }
                        
                    }
                }

                var result = MakeGenericType(genericTypeDefinitionInAssembly, argumentsInAssembly);

				return result;
            }

            return GetTypeInAssembly(types, type.FullName);
        }
		/// <summary>
		/// Used to make generic types in a single location.  This helps to make sure that all generic types are made in the same way and that
		/// all generic types that are based upon type builder actually use th typeBuilder.MakeGenericType() method and not Type.MakeGenericType() method.
		/// </summary>
		/// <param name="genericTypeDefinition"></param>
		/// <param name="typeParameters"></param>
		/// <returns></returns>
	    public System.Type MakeGenericType(System.Type genericTypeDefinition, Type[] typeParameters)
	    {
		    if (genericTypeDefinition is TypeBuilder typeBuilder)
		    {
				// For TypeBuilder.GetConstructor(), TypeBuilder.GetMethod() and TypeBuilder.GetField() to work,
				// the typebuilder needs to keep track of generic types that it produces.  To do this, the typeBuilder
				// MakeGeneric method needs to be used over just the normal Type.MakeGenericType() method.
			    //for (int i = 0; i < typeParameters.Length; i++)
			    //{
				   // Console.WriteLine($"MakeGenericType TP[{i}]: {typeParameters[i].Name}");
			    //}
				
			    return typeBuilder.MakeGenericType(typeParameters);
		    }

		    //for (int i = 0; i < typeParameters.Length; i++)
		    //{
			   // var parameter = typeParameters[i];

			   // if (parameter.DeclaringType != null && ReferenceEquals(genericTypeDefinition, parameter.DeclaringType))
			   // {
				  //  throw new Exception("Declaring type of parameter is same as generic type definition.");
			   // }
		    //}

		    var result = genericTypeDefinition.MakeGenericType(typeParameters);

		    //if (result.IsGenericTypeDefinition)
		    //{
			   // throw new Exception("MakeGenericType returned a generic type definition and not a generic instance.");
		    //}
            return result;
	    }

		private Type GetTypeInCorLib(Type argument)
        {
            if (argument.Assembly.FullName.StartsWith("mscorlib")) return argument;

            return null;

        }

        public Type GetTypeInAssembly(Type[] types, string resolutionName)
        {
            foreach (var type in types)
            {


                if (type.FullName == resolutionName)
                {
                    return type;
                }
            }

            return null;
        }
    }
}
