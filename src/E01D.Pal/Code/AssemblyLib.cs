using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Root.Code
{
	public static class AssemblyLib
	{
		public static System.Type MakeGenericType(System.Type genericTypeDefinition, Type[] typeParameters)
		{
			try
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
			catch
			{
				StringBuilder builder = new StringBuilder();
				builder.AppendLine("Could not make a genric type with the following types:");
				builder.AppendLine($"Defininition: {genericTypeDefinition.AssemblyQualifiedName}");
				for (int i = 0; i < typeParameters.Length; i++)
				{
					builder.AppendLine($"{i}: {typeParameters[i].AssemblyQualifiedName}");
				}
				

				throw new Exception(builder.ToString());
			}
		}
	}
}
