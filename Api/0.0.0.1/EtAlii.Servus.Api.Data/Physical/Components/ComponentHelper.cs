﻿namespace EtAlii.Servus.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class ComponentHelper
    {
        private static readonly Dictionary<Type, string> _componentNames = new Dictionary<Type, string>();
        private static readonly object[] _emptyConstructorParameters = new object[] { };

        /// <summary>
        /// TODO: this method could be completely replaced by the Generic GetName method.
        /// </summary>
        /// <param name="containerComponent"></param>
        /// <returns></returns>
        public static string GetName(IComponent containerComponent)
        {
            return ((ComponentBase)containerComponent).Name;
        }

        public static string GetName<T>()
            where T : ComponentBase
        {
            var type = typeof(T);
            var name = String.Empty;

            if (!_componentNames.TryGetValue(type, out name))
            {
                var constructor = type.GetTypeInfo()
                                      .DeclaredConstructors
                                      .Where(c => !c.IsStatic)
                                      .Where(c => c.GetParameters().Length == 0)
                                      .First();
                var instance = (T)constructor.Invoke(_emptyConstructorParameters);
                name = instance.Name;
                _componentNames[type] = name;
            }
            return name;
        }

        public static void SetId(CompositeComponent compositeComponent, ulong id)
        {
            compositeComponent.Id = id;
        }

        public static void SetStored(IComponent component, bool stored)
        {
            ((ComponentBase)component).Stored = stored;
        }
    }
}
