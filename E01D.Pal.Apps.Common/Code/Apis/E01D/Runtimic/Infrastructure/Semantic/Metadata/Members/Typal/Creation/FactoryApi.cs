using System;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Creation
{
    public class FactoryApi<TContainer> : SemanticApiNode<TContainer>, FactoryApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public object CreateType
        <
            TGenericStructTypeDefinition,
            TGenericDelegateTypeDefinition,
            TGenericClassTypeDefinition,
            TGenericInterfaceTypeDefinition,
            TGenericNestedStructTypeDefinition,
            TGenericNestedDelegateTypeDefinition,
            
            TGenericNestedClassTypeDefinition,
            TGenericNestedInterfaceTypeDefinition,
            TNestedEnumTypeDefinition,
            TNestedStructTypeDefinition,
            TNestedDelegateTypeDefinition,
            
            TNestedClassTypeDefinition,
            TNestedInterfaceTypeDefinition,
            TSimpleClTypeDefinition,
            TEnumTypeDefinition,
            TStructTypeDefinition,
            TDelegateTypeDefinition,
            TArrayTypeDefinition,
            TClassTypeDefinition,
            TInterfaceTypeDefinition,
			TPointerTypeDefinition,
	        TRequiredModifierTypeDefinition>(SemanticTypeInformation typeInformation)
            where TGenericNestedStructTypeDefinition :  new()
            where TGenericNestedDelegateTypeDefinition :   new()
            
            where TGenericNestedClassTypeDefinition :   new()
            where TGenericNestedInterfaceTypeDefinition :  new()
            
            where TGenericStructTypeDefinition :   new()
            where TGenericDelegateTypeDefinition :   new()
            where TGenericClassTypeDefinition :   new()
            where TGenericInterfaceTypeDefinition :   new()
            where TNestedEnumTypeDefinition :  new()
            where TNestedStructTypeDefinition :  new()
            where TNestedDelegateTypeDefinition :  new()
            
            where TNestedClassTypeDefinition :  new()
            where TNestedInterfaceTypeDefinition :  new()
            where TSimpleClTypeDefinition :  new()
            where TEnumTypeDefinition :  new()
            where TStructTypeDefinition :  new()
            where TDelegateTypeDefinition :  new()
            where TArrayTypeDefinition :  new()
            where TClassTypeDefinition :  new()
            where TInterfaceTypeDefinition :  new()
			where TPointerTypeDefinition: new()
			where TRequiredModifierTypeDefinition: new()

		{


            object boundTypeDefinition;

            if (typeInformation.IsGeneric)
            {
                if (typeInformation.IsNested)
                {
                    if (typeInformation.IsValueType) // needs to be before 
                    {
                        if (IsSimpleType(typeInformation.FullName))
                        {
                            throw new System.Exception("There are no generic simple types.  This is not expected.");
                        }
                        if (typeInformation.IsEnum)
                        {
							// Not really a generic, but this logic does occur.
							boundTypeDefinition = new TNestedEnumTypeDefinition();
						}
                        else
                        {
                            boundTypeDefinition = new TGenericNestedStructTypeDefinition();
                        }
                    }
                    else if (typeInformation.IsDelegate)//(typeDefinition.IsFunctionPointer || typeDefinition.BaseType?.FullName == "System.Delegate" || typeDefinition.BaseType?.FullName == "System.MulticastDelegate")
                    {
                        boundTypeDefinition = new TGenericNestedDelegateTypeDefinition();
                    }
                    else if (typeInformation.IsArray)
                    {
                        throw new System.Exception("Not supported");

                    }
                    else if (typeInformation.IsClass)
                    {
                        boundTypeDefinition = new TGenericNestedClassTypeDefinition();

                    }
                    else if (typeInformation.IsInterface)
                    {
                        boundTypeDefinition = new TGenericNestedInterfaceTypeDefinition();
                    }
                    else
                    {
                        throw new System.NotImplementedException();
                    }
                }
                else
                {
                    if (typeInformation.IsValueType) // needs to be before 
                    {
                        if (IsSimpleType(typeInformation.FullName))
                        {
                            throw new System.Exception("Not implemented.");
                        }

                        else if (typeInformation.IsEnum)
                        {
                            throw new System.Exception("Not expected");
                        }
                        else
                        {
                            boundTypeDefinition = new TGenericStructTypeDefinition();
                        }
                    }
                    else if (typeInformation.IsDelegate)//(typeDefinition.IsFunctionPointer || typeDefinition.BaseType?.FullName == "System.Delegate" || typeDefinition.BaseType?.FullName == "System.MulticastDelegate")
                    {
                        boundTypeDefinition = new TGenericDelegateTypeDefinition();
                    }
                    else if (typeInformation.IsArray)
                    {
                        throw new System.Exception("Not supported");

                    }
                    else if (typeInformation.IsClass)
                    {
                        boundTypeDefinition = new TGenericClassTypeDefinition();

                    }
                    else if (typeInformation.IsInterface)
                    {
                        boundTypeDefinition = new TGenericInterfaceTypeDefinition();
                    }
                    else
                    {
                        throw new System.NotImplementedException();
                    }
                }

                


            }
            else
            {
                if (typeInformation.IsNested)
                {
                    if (typeInformation.IsValueType) // needs to be before 
                    {
                        if (IsSimpleType(typeInformation.FullName))
                        {
                            throw new System.Exception("Not expected");
                        }
                        if (typeInformation.IsEnum)
                        {
                            boundTypeDefinition = new TNestedEnumTypeDefinition();
                        }
                        else
                        {
                            boundTypeDefinition = new TNestedStructTypeDefinition();
                        }
                    }
                    else if (typeInformation.IsDelegate)//(typeDefinition.IsFunctionPointer || typeDefinition.BaseType?.FullName == "System.Delegate" || typeDefinition.BaseType?.FullName == "System.MulticastDelegate")
                    {
                        boundTypeDefinition = new TNestedDelegateTypeDefinition();
                    }
                    else if (typeInformation.IsArray)
                    {
                        throw new System.Exception("Not supported");

                    }
                    else if (typeInformation.IsClass)
                    {
                        boundTypeDefinition = new TNestedClassTypeDefinition();

                    }
                    else if (typeInformation.IsInterface)
                    {
                        boundTypeDefinition = new TNestedInterfaceTypeDefinition();
                    }
                    else
                    {
                        throw new System.NotImplementedException();
                    }
                }
                else
                {
                    if (typeInformation.IsValueType) // needs to be before 
                    {
                        if (IsSimpleType(typeInformation.FullName))
                        {
                            boundTypeDefinition = new TSimpleClTypeDefinition();
                        }

                        else if (typeInformation.IsEnum)
                        {
                            boundTypeDefinition = new TEnumTypeDefinition();
                        }
                        else
                        {
                            boundTypeDefinition = new TStructTypeDefinition();
                        }
                    }
                    else if (typeInformation.IsDelegate)
                    {
                        boundTypeDefinition = new TDelegateTypeDefinition();
                    }
                    else if (typeInformation.IsArray)
                    {
                        boundTypeDefinition = new TArrayTypeDefinition();

                    }
                    else if (typeInformation.IsClass)
                    {
                        boundTypeDefinition = new TClassTypeDefinition();



                    }
                    else if (typeInformation.IsInterface)
                    {
                        boundTypeDefinition = new TInterfaceTypeDefinition();
                    }
                    else if (typeInformation.IsPointer)
                    {
	                    boundTypeDefinition = new TPointerTypeDefinition();
                    }
                    else if (typeInformation.IsRequiredModifier)
                    {
	                    boundTypeDefinition = new TRequiredModifierTypeDefinition();
                    }
					else
                    {
	                    throw new Exception("Not expected.");
                    }
                }
            }



            

            return boundTypeDefinition;
        }

        private bool IsSimpleType(string fullName)
        {
            switch (fullName)
            {
                case "System.Boolean":
                case "System.Byte":
                case "System.Char":
                case "System.Decimal":
                case "System.Double":
                case "System.Single":
                case "System.SByte":
                case "System.Int16":
                case "System.Int32":
                case "System.Int64":
                case "System.UInt16":
                case "System.UInt32":
                case "System.UInt64":
                case "System.String":
                case "System.Void":
                case "System.Object":
                    return true;
                default:
                    return false;
            }
        }
    }
}
