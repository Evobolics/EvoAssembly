using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Root.Code.Domains.E01D;
using Root.Code.Models.E01D.Containment;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Mapping;

namespace Root.Code.Apis.E01D.Containment
{
    public class CommonAppContainerDomainApi
    {
        public T CreateContainer<T>()
            where T : Container_I
        {
            return CreateContainer<T>(true);
        }

        public T CreateContainer<T>(bool allowDynamicTypes)
            where T : Container_I
        {
            var iocMap = CreateIocMapping(allowDynamicTypes);

            T t = XCommonAppPal.Api.Activation.CreateInstance<T>();

            SetApisAndContainer(t, t, iocMap);

            return t;
        }

        private IocMap CreateIocMapping(bool allowDynamicTypes)
        {
            Dictionary<string, InterfaceNode> interfaceNodes = new Dictionary<string, InterfaceNode>();

            var assemblies = System.AppDomain.CurrentDomain.GetAssemblies();

            for (int i = 0; i < assemblies.Length; i++)
            {
                var assembly = assemblies[i];

                if (!allowDynamicTypes && assembly.IsDynamic) continue;

	            Type[] types = null;


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
                

                for (int iType = 0; iType < types.Length; iType++)
                {
                    var type = types[iType];

                    if (type.IsClass)
                    {
                        if (type.Name.Contains("RuntimicContainerApi") && !type.Name.Contains("RuntimicContainerApi_I"))
                        {
                            
                        }

                        var interfaces = type.GetInterfaces();

                        for (int iInterface = 0; iInterface < interfaces.Length; iInterface++)
                        {
                            var currentInterface = interfaces[iInterface];

                            var node = AddInterface(currentInterface, interfaceNodes);

                            var className = type.FullName ?? type.Namespace + "." + type.Name;

                            if (!node.Classes.TryGetValue(className, out Type currentClass1))
                            {
                                node.Classes.Add(className, type);
                            }
                            

                            if (currentInterface.IsGenericType)
                            {
                                var definition = currentInterface.GetGenericTypeDefinition();

                                node = AddInterface(definition, interfaceNodes);

                                if (!node.Classes.TryGetValue(className, out Type currentClass2))
                                {
                                    node.Classes.Add(className, type);
                                }
                            }
                            
                        }
                    }
                }

            }

            return new IocMap()
            {
                InterfaceNodes = interfaceNodes
            };
        }

        private static InterfaceNode AddInterface(Type currentInterface, Dictionary<string, InterfaceNode> interfaceNodes)
        {
            var fullName = currentInterface.FullName ?? currentInterface.Namespace + "." + currentInterface.Name;

            if (!interfaceNodes.TryGetValue(fullName, out InterfaceNode currentInterfaceNode))
            {
                currentInterfaceNode = new InterfaceNode()
                {
                    Interface = currentInterface,
                    FullName = fullName
                };

                interfaceNodes.Add(fullName, currentInterfaceNode);
            }

            return currentInterfaceNode;
        }

        private void SetApisAndContainer<T>(object instance, T container, IocMap map)
        {
            // needs to use GetPalType(); to get pal type instead.  This will help eliminate the needs for direct 
            // connection with the .NET / Core / Mono runtime.
            var type = instance.GetType();

            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                SetContainer(property, instance, container, map);
            }
        }

        private void SetContainer<T>(PropertyInfo property, object currentInstance, T container, IocMap map)
        {
            object apiInstance = null;

            if (PropertyExtendsApi(property))
            {
                apiInstance = property.GetValue(currentInstance);

                if (apiInstance == null)
                {
                    try
                    {
                        apiInstance = XCommonAppPal.Api.Activation.CreateInstance(property.PropertyType);

                        if (property.CanWrite)
                        {
                            property.SetValue(currentInstance, apiInstance);
                        }
                    }
                    catch
                    {
                        // ignore
                    }

                }
            }
            else if (IsNamedAnApi(property.PropertyType.Name))
            {
                apiInstance = property.GetValue(currentInstance);

                if (apiInstance == null)
                {

                    var type = property.PropertyType;

                    if (type.IsGenericType)
                    {
                        var typeDefintion = type.GetGenericTypeDefinition();

                        if (type.GenericTypeArguments.Length == 1)
                        {

                            var fullName = typeDefintion.FullName ?? typeDefintion.Namespace + "." + typeDefintion.Name;

                            if (map.InterfaceNodes.TryGetValue(fullName, out InterfaceNode interfaceNode))
                            {
                                var classes = interfaceNode.Classes;

                                if (classes.Count == 1)
                                {
                                    var classType = classes.Values.SingleOrDefault();

                                    if (classType == null) throw new Exception();

                                    try
                                    {
	                                    var result = XCommonAppPal.Api.Runtimic.Execution.Metadata.Assemblies.MakeGenericType(classType,
		                                    new Type[] {container.GetType()});
										

                                        apiInstance = XCommonAppPal.Api.Activation.CreateInstance(result);

                                        if (property.CanWrite)
                                        {
                                            property.SetValue(currentInstance, apiInstance);
                                        }
                                    }
                                    catch (System.Exception)
                                    {

                                    }


                                }
                                else
                                {
                                    throw new Exception("Multiple classes found.");
                                }
                            }
                        }
                        else
                        {
                            
                        }
                    }
                    else
                    {
                        if (type.IsClass)
                        {
                            apiInstance = XCommonAppPal.Api.Activation.CreateInstance(type);

                            if (property.CanWrite)
                            {
                                property.SetValue(currentInstance, apiInstance);
                            }
                        }
                        else if (type.IsInterface)
                        {
                            var fullName = type.FullName ?? type.Namespace + "." + type.Name;

                            if (map.InterfaceNodes.TryGetValue(fullName, out InterfaceNode interfaceNode))
                            {
                                var classes = interfaceNode.Classes;

                                if (classes.Count == 1)
                                {
                                    var classType = classes.Values.SingleOrDefault();

                                    if (classType == null) throw new Exception();

                                    try
                                    {
	                                    var result = XCommonAppPal.Api.Runtimic.Execution.Metadata.Assemblies.MakeGenericType(classType,
		                                    new Type[] { container.GetType() });
										

                                        apiInstance = XCommonAppPal.Api.Activation.CreateInstance(result);

                                        if (property.CanWrite)
                                        {
                                            property.SetValue(currentInstance, apiInstance);
                                        }
                                    }
                                    catch (System.Exception)
                                    {

                                    }


                                }
                                else
                                {
                                    throw new Exception("Multiple classes found.");
                                }
                            }
                        }
                    }
                }
            }
            if (TypeExtends(property.PropertyType, typeof(Api<,>)))
            {
                var undelerlyingProperty = property.PropertyType.GetProperty("Underlying");

                SetContainer(undelerlyingProperty, apiInstance, container, map);
            }

            if (apiInstance != null)
            {
                var apiInstanceType = apiInstance.GetType();

                var containerProperty = apiInstanceType.GetProperty("Container");

                if (containerProperty != null && containerProperty.CanWrite)
                {

                    containerProperty.SetMethod.Invoke(apiInstance, new object[] {container});
                }

                SetApisAndContainer(apiInstance, container, map);
            }
        }

        private bool IsNamedAnApi(string typeName)
        {
            if (typeName.EndsWith("Api")) return true;

            if (typeName.EndsWith("Api_I")) return true;

            if (typeName.Contains("`"))
            {
                var split = typeName.Split(new char[] {'`'});

                if (split.Length > 0 && split[0].EndsWith("Api_I"))
                {
                    return true;
                }
            }

            return false;
        }

        private bool PropertyExtendsApi_I(PropertyInfo property)
        {
            return TypeExtendsApi_I(property.PropertyType);
        }

        private bool TypeExtendsApi_I(Type type)
        {
            return TypeExtends(type, typeof(Api<>));
        }

        private bool PropertyExtendsApi(PropertyInfo property)
        {
            return TypeExtendsApi(property.PropertyType);
        }

        private bool TypeExtendsApi(Type type)
        {
            return TypeExtends(type, typeof(Api<>));
        }

        private bool TypeExtends(Type type, Type targetBaseType)
        {
            Type baseType;

            if (targetBaseType.IsGenericTypeDefinition)
            {
                var nonGenericBaseType = type.BaseType;

                if (nonGenericBaseType == null || !nonGenericBaseType.IsGenericType) return false;

                baseType = nonGenericBaseType.GetGenericTypeDefinition();
            }
            else
            {
                baseType = type.BaseType;
            }

            var result = baseType == targetBaseType;

            if (!result)
            {
                if (baseType != typeof(object))
                {
                    return TypeExtends(baseType, targetBaseType);
                }
            }

            return result;
        }
    }
}
