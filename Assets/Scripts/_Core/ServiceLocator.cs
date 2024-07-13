using System;
using System.Collections.Generic;

namespace Game
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();

        public static void AddService<T>(T service)
        {
            _services.Add(typeof(T), service);
        }

        public static T GetService<T>() => (T)_services[typeof(T)];
    }
}