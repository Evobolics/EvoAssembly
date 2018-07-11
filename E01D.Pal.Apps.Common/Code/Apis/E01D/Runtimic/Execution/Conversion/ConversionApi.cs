using System;
using System.IO;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Modeling;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion
{
    public class ConversionApi<TContainer> :Api<TContainer>, ConversionApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {





        public MetadataApi_I<TContainer> Metadata { get; set; }

        public ModelApi_I<TContainer> Models { get; set; }

        ModelApiMask_I ConversionApiMask_I.Models => Models;

        MetadataApiMask_I ConversionApiMask_I.Metadata
        {
            get { return this.Metadata; }
        } 
        




        public ILConversionResult ConvertType(Type type)
        {
            ILConversion conversion = null;

            try
            {
                conversion = new ILConversion
                {
                    InputTypes = new[] { type },
                    Configuration =
                    {
                        IsConvertingTypeSet = true
                    },
                };

                conversion.Model.Conversion = conversion;

                // "E01D.Pal.Apps.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"
                string name = type.Assembly.FullName;

                name = name.Split(',')[0];

                if (!conversion.Configuration.ConvertedAssemblies.ContainsKey(name))
                {
                    conversion.Configuration.ConvertedAssemblies.Add(name, type.Assembly);
                }

                return Metadata.Assemblies.Convert(conversion, conversion.InputTypes);
            }
            finally
            {
                if (conversion?.Model?.Structural.Streams != null)
                {
                    for (int i = 0; i < conversion.Model.Structural.Streams.Count; i++)
                    {
                        var stream = conversion.Model.Structural.Streams[i];

                        try
                        {
                            stream.Dispose();
                        }
                        catch
                        {
                            // ignore
                        }
                    }
                }
            }

            
        }

        public ILConversionResult ConvertTypes(Type[] types)
        {
            ILConversion conversion = null;

            try
            {
                conversion = new ILConversion
                {
                    InputTypes = types,
                    Configuration =
                    {
                        IsConvertingTypeSet = true
                    }
                };

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

                return Metadata.Assemblies.Convert(conversion, types);
            }
            finally
            {
                if (conversion?.Model?.Structural.Streams != null)
                {
                    for (int i = 0; i < conversion.Model.Structural.Streams.Count; i++)
                    {
                        var stream = conversion.Model.Structural.Streams[i];

                        try
                        {
                            stream.Dispose();
                        }
                        catch
                        {
                            // ignore
                        }
                    }
                }
            }
            
        }

        public ILConversionResult ConvertAssembly(Stream stream)
        {
            var conversion = new ILConversion();

            //AddTypes(conversion);

            Metadata.Assemblies.Convert(conversion, new Stream[] { stream });

            return conversion.Result;
        }

        public ILConversionResult ConvertAssembly(Stream[] streams)
        {
            var conversion = new ILConversion();

            //AddTypes(conversion);

            Metadata.Assemblies.Convert(conversion, streams);

            return conversion.Result;
        }

        //public void AddTypes(ILConversion conversion)
        //{
        //    var simpleTypes = new []
        //    {
        //        "System.Boolean",
        //        "System.Byte",
        //        "System.Char",
        //        "System.Decimal",
        //        "System.Double",
        //        "System.Single",
        //        "System.SByte",
        //        "System.Int16",
        //        "System.Int32",
        //        "System.Int64",
        //        "System.UInt16",
        //        "System.UInt32",
        //        "System.UInt64",
        //        "System.ValueType",
        //    };

        //    var boundTypes = new[]
        //    {
        //        "System.String",
        //        "System.Object",
        //        "System.Array",
        //        "System.Enum",
        //        "System.MulticastDelegate",
        //        "System.Attribute",
        //    };

        //    foreach (var fullName in simpleTypes)
        //    {
        //        var typeDefinition = new BoundSimpleClTypeDefinition() 
        //        {
        //            FullName = fullName,
        //            UnderlyingType = System.Type.GetType(fullName)
        //        };

        //        conversion.Model.Types.SimpleTypes.Add(fullName, typeDefinition);
        //        conversion.Model.Types.SpecialTypes.Add(fullName, typeDefinition);
        //        conversion.Model.Types.ByResolutionName.Add(fullName, typeDefinition);
        //    }

        //    foreach (var fullName in boundTypes)
        //    {
        //        var typeDefinition = new BoundClassTypeDefinition()
        //        {
        //            FullName = fullName,
        //            UnderlyingType = System.Type.GetType(fullName)
        //        };

        //        conversion.Model.Types.BuiltInTypes.Add(fullName, typeDefinition);
        //        conversion.Model.Types.SpecialTypes.Add(fullName, typeDefinition);
        //        conversion.Model.Types.ByResolutionName.Add(fullName, typeDefinition);
        //    }
        //}

       
    }
}
