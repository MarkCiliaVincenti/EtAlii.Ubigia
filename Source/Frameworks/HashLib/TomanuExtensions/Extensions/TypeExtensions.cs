﻿// ReSharper disable all

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace TomanuExtensions
{
    [DebuggerStepThrough]
    public static class TypeExtensions
    {
        public static bool IsDerivedFrom(this Type a_type, Type a_baseType)
        {
            Debug.Assert(a_type != null);
            Debug.Assert(a_baseType != null);
            Debug.Assert(a_type.IsClass);
            Debug.Assert(a_baseType.IsClass);

            return a_baseType.IsAssignableFrom(a_type);
        }

        public static bool IsImplementInterface(this Type a_type, Type a_interfaceType)
        {
            Debug.Assert(a_type != null);
            Debug.Assert(a_interfaceType != null);
            Debug.Assert(a_type.IsClass || a_type.IsInterface || a_type.IsValueType);
            Debug.Assert(a_interfaceType.IsInterface);

            return a_interfaceType.IsAssignableFrom(a_type);
        }

        public static IEnumerable<Type> GetBaseTypes(this Type a_type,
            bool a_with_this = false)
        {
            if (a_with_this)
                yield return a_type;

            var t = a_type;

            while (t.BaseType != null)
            {
                t = t.BaseType;
                yield return t;
            }
        }

        public static string GetParentFullName(this Type a_type)
        {
            return Path.GetFileNameWithoutExtension(a_type.FullName);
        }

        /// <summary>
        /// Get all private, protected, public properties from this type and sub-types.
        /// Without abstract properties. In case of overriding return top-most one.
        /// </summary>
        /// <param name="a_type"></param>
        /// <returns></returns>
        public static IEnumerable<PropertyInfo> GetAllProperties(this Type a_type)
        {
            var result = new List<PropertyInfo>();

            foreach (var t in a_type.GetBaseTypes(true))
            {
                if (t == typeof(object))
                    break;
                if (t == typeof(ValueType))
                    break;

                var type_props = t.GetProperties(
                    BindingFlags.Public | BindingFlags.NonPublic |
                    BindingFlags.Instance);

                foreach (var poss_prop in type_props.Reverse())
                {
                    if (poss_prop.IsAbstract())
                        continue;

                    if (result.All(prop => !prop.IsDerivedFrom(poss_prop, true)))
                        result.Add(poss_prop);
                }
            }

            result.Reverse();
            return result;
        }

        public static IEnumerable<MethodInfo> GetAllMethods(this Type a_type,
            bool a_include_autogenerated = false)
        {
            var result = new List<MethodInfo>();

            foreach (var t in a_type.GetBaseTypes(true))
            {
                if (t == typeof(object))
                    break;
                if (t == typeof(ValueType))
                    break;

                var methods = t.GetMethods(
                    BindingFlags.Public | BindingFlags.NonPublic |
                    BindingFlags.Instance);

                foreach (var method in methods.Reverse())
                {
                    if (method.IsDefined(typeof(CompilerGeneratedAttribute), true) &&
                        !a_include_autogenerated)
                    {
                        continue;
                    }

                    if (method.IsAbstract)
                        continue;
                    if (result.All(m => !m.IsDerivedFrom(method, true)))
                    {
                        result.Add(method);
                        yield return method;
                    }
                }
            }
        }

        public static IEnumerable<FieldInfo> GetAllFields(this Type a_type,
            bool a_include_autogenerated = false)
        {
            foreach (var t in a_type.GetBaseTypes(true).Reverse())
            {
                if (t == typeof(object))
                    continue;
                if (t == typeof(ValueType))
                    continue;

                var fields = t.GetFields(BindingFlags.Instance | BindingFlags.Public |
                                         BindingFlags.NonPublic);

                foreach (var field in fields)
                {
                    if (field.IsDefined(typeof(CompilerGeneratedAttribute), true) &&
                        !a_include_autogenerated)
                    {
                        continue;
                    }

                    if (field.DeclaringType == t)
                        yield return field;
                }
            }
        }

        public static ConstructorInfo GetConstructor(this Type a_type)
        {
            return a_type.GetConstructor(Type.EmptyTypes);
        }

        public static ConstructorInfo GetConstructor(this Type a_type, params Type[] a_types)
        {
            return a_type.GetConstructor(a_types);
        }
    }
}