﻿using System;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Internal;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Modeling;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion
{
    public class ConversionApi<TContainer> : ConversionApiNode<TContainer>, ConversionApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
		#region Api(s)

	    

		public InternalApi_I<TContainer> Internal { get; set; }

		public new MetadataApi_I<TContainer> Metadata { get; set; }

        public new ModelApi_I<TContainer> Models { get; set; }

	   

		InternalApiMask_I ConversionApiMask_I.Internal
	    {
		    get { return Internal; }
	    }

		MetadataApiMask_I ConversionApiMask_I.Metadata
        {
            get { return Metadata; }
        }

	    ModelApiMask_I ConversionApiMask_I.Models => Models;

		#endregion

		/*
		 * -----------------------------------------------------------------------------------------------------------
		 * Conversion Cases
		 * -----------------------------------------------------------------------------------------------------------
		 * 
		 * There are a total of fourr major cases, with each major case containing two sub cases.  The purpose of this
		 * API is to make it easy for developers to consume.  They should be able to just get the types they want if
		 * that is all they want.  If they want the entire conversion result, including the model that is produced,
		 * they can get that from accessing the conversion result.
		 * 
		 * Case A: Converting a type
		 *   Case A1: Just returns the dynamic type
		 *   Case A2: Returns the dynamic type and returns an ILConversion result
		 * 
		 * Case B: Converting a series of types
		 *   Case B1: Just returns the array of dynamic types that correspond to the types provided.
		 *   Case B2: returns the array of dynamic types that correspond to the types provided
		 *            and returns an ILConversion result
		 * 
		 * Case C: Converting an Assembly
		 *  
		 * Case D: Converting a series of Assemblies
		 * 
		 * Case E: Converting an Assembly Definition
		 *  
		 * Case F: Converting a series of Assembly Definitions
		 * 
		 * -----------------------------------------------------------------------------------------------------------
		 * Conversion Process
		 * -----------------------------------------------------------------------------------------------------------
		 * 
		 *  * Create the IL Conversion
		 *  
		 *  * Assign the appropriate Input to the ILConversion
		 * 
		 *  * Transform the primary inputs into assembly definitions and type definitions
		 *    
		 *  * Load all of the assembly definitions and type definitions into the model so they can be searched and referenced.  
		 *  
		 *  * Add the assembly definitions that came in as inputs to the conversion list.
		 *       
		 *  * Create a dynamic assembly associated with each assembly definition in the conversion list.
		 *     
		 *  * Make sure the assembly definitions that are inputs are mapped to outputs.
		 *       
		 *  * Determine all assemblies that are referenced by the input assemblies and create bound assemblies for each one.
		 *       
		 *  * Create a list of a type definitions that needed to be converted either from the types inputted or the assemblies inputted.
		 */

	    private ILConversion CreateConversion(ILConversionInput input)
	    {
		    var conversion = new ILConversion
		    {
			    Input = input
		    };

		    conversion.Model.Conversion = conversion;

		    return conversion;
	    }

		public ILConversionResult Convert(Type type)
		{
			var conversion = CreateConversion(new ILConversionTypesInput()
			{
				Types = new []{type}
			});

			return Internal.Convert(conversion, type);
		}

	    public ILConversionResult Convert(Type type, AssemblyBuilderAccess access)
	    {
		    var conversion = CreateConversion(new ILConversionTypesInput()
		    {
			    Types = new[] { type }
		    });

		    var conversionOptions = Internal.CreateDefaultConversionOptions();
		    conversionOptions.BuilderAccess = access;

		    return Internal.Convert(conversion, type, conversionOptions);
	    }

		public ILConversionResult Convert(Type type, ILConversionOptions conversionOptions)
	    {
		    var conversion = CreateConversion(new ILConversionTypesInput()
		    {
			    Types = new[] { type }
			});

		    return Internal.Convert(conversion, type, conversionOptions);
	    }

		public Type QuickConvert(Type type)
	    {
		    return QuickConvert(type, out ILConversionResult result);
	    }

		public Type QuickConvert(Type type, out ILConversionResult result)
	    {
		    var conversion = CreateConversion(new ILConversionTypesInput()
			{
				Types = new[] { type }
			});

			result = Internal.Convert(conversion, type);

			var output = (ILConversionTypesOutput)result.Output;

			return output.Types[0];
	    }

	   

	    public Type[] QuickConvert(Type[] types)
	    {
		    return QuickConvert(types, out ILConversionResult result);
	    }


		public Type[] QuickConvert(Type[] types, out ILConversionResult result)
	    {
		    var conversion = CreateConversion(new ILConversionTypesInput()
			{
				Types = types
			});

			conversion.Model.Conversion = conversion;

			for (int i = 0; i < types.Length; i++)
			{
				var type = types[i];

				string name = type.Assembly.FullName;

				name = name.Split(',')[0];

				if (!conversion.Configuration.ConvertedAssemblies.ContainsKey(name))
				{
					conversion.Configuration.ConvertedAssemblies.Add(name, type.Assembly);
				}
			}

			result = Internal.Convert(conversion, types);

			var output = (ILConversionTypesOutput)result.Output;

			return output.Types;
		    

	    }

	    // -------- CONVERSION CASE C1 ---------------
		/// <summary>
		/// 
		/// </summary>
		/// <param name="assembly"></param>
		/// <returns></returns>
		public Assembly QuickConvert(Assembly assembly)
		{
			return QuickConvert(assembly, out ILConversionResult result);
		}

	    public Assembly QuickConvert(Assembly assembly, ILConversionOptions options)
	    {
		    return QuickConvert(assembly, options, out ILConversionResult result);
	    }

	    public Assembly QuickConvert(Assembly assembly, AssemblyBuilderAccess assemblyBuilderAccess)
	    {
		    var conversionOptions = Internal.CreateDefaultConversionOptions();
		    conversionOptions.BuilderAccess = assemblyBuilderAccess;

			return QuickConvert(assembly, conversionOptions, out ILConversionResult result);
	    }

		// -------- CONVERSION CASE C2 ---------------
		/// <summary>
		/// Converts the assembly an assembly to a dynamic assembly and returns the conversion result as an out parameter.
		/// </summary>
		/// <param name="assembly"></param>
		/// <param name="result"></param>
		/// <returns></returns>
		public Assembly QuickConvert(Assembly assembly, out ILConversionResult result)
		{
			return QuickConvert(assembly, Internal.CreateDefaultConversionOptions(), out result);

		}

	    /// <summary>
	    /// Converts the assembly an assembly to a dynamic assembly and returns the conversion result as an out parameter.
	    /// </summary>
	    /// <param name="assembly"></param>
	    /// <param name="result"></param>
	    /// <returns></returns>
	    public Assembly QuickConvert(Assembly assembly, ILConversionOptions conversionOptions, out ILConversionResult result)
	    {
		    var conversion = CreateConversion(new ILConversionAssembliesInput()
		    {
			    Assemblies = new[] { assembly }
		    });

		    result = Internal.Convert(conversion, assembly, conversionOptions);

		    var output = (ILConversionAssembliesOutput)result.Output;

		    return output.Assemblies[0];

	    }

		// -------- CONVERSION CASE D1 ---------------
		/// <summary>
		/// 
		/// </summary>
		/// <param name="assembly"></param>
		/// <returns></returns>
		public Assembly[] QuickConvert(Assembly[] assemblies)
	    {
		    return QuickConvert(assemblies, out ILConversionResult result);
	    }

	    // -------- CONVERSION CASE D2 ---------------
	    /// <summary>
	    /// Converts the assembly an assembly to a dynamic assembly and returns the conversion result as an out parameter.
	    /// </summary>
	    /// <param name="assembly"></param>
	    /// <param name="result"></param>
	    /// <returns></returns>
	    public Assembly[] QuickConvert(Assembly[] assemblies, out ILConversionResult result)
	    {
		    var conversion = CreateConversion(new ILConversionAssembliesInput()
		    {
			    Assemblies = assemblies
			});

			result =  Internal.Convert(conversion, assemblies);

		    var output = (ILConversionAssembliesOutput)result.Output;

		    return output.Assemblies;

		}

		// -------- CONVERSION CASE E1 ---------------
		/// <summary>
		/// 
		/// </summary>
		/// <param name="stream"></param>
		/// <returns></returns>
		public Assembly Convert(Stream stream)
	    {
		    return Convert(stream, Internal.CreateDefaultConversionOptions(), out ILConversionResult result);
	    }

	    public Assembly Convert(Stream stream, ILConversionOptions conversionOptions)
	    {
		    return Convert(stream, conversionOptions, out ILConversionResult result);
	    }

		// -------- CONVERSION CASE E2 ---------------
		/// <summary>
		/// Converts the assembly an assembly to a dynamic assembly and returns the conversion result as an out parameter.
		/// </summary>
		/// <param name="stream">A stream containing an assembly.</param>
		/// <param name="conversionOptions"></param>
		/// <param name="result"></param>
		/// <returns></returns>
		public Assembly Convert(Stream stream, ILConversionOptions conversionOptions, out ILConversionResult result)
	    {
		    result = Internal.Convert(new ILConversion(), stream, conversionOptions);

		    var output = (ILConversionAssembliesOutput)result.Output;

		    return output.Assemblies[0];

		}





		


	}
}
