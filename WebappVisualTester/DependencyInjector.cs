using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Unity;
using Unity.Lifetime;
using Unity.Resolution;
using System.Linq;

namespace WebappVisualTester
{
    public static class DependencyInjector
    {
        public static readonly UnityContainer UnityContainer = new UnityContainer();
        public static void Register<I, T>() where T : I
        {
            UnityContainer.RegisterType<I, T>(new ContainerControlledLifetimeManager());
        }
        public static void InjectStub<I>(I instance)
        {
            UnityContainer.RegisterInstance(instance, new ContainerControlledLifetimeManager());
        }
        public static T Retrieve<T>()
        {
            return UnityContainer.Resolve<T>();
        }

        ////https://stackoverflow.com/a/4521132
        public static T Resolve<T>(object parameterOverrides)
        {
            var properties = parameterOverrides
                .GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var overridesArray = properties
                .Select(p => new ParameterOverride(p.Name, p.GetValue(parameterOverrides, null)))
                .Cast<ResolverOverride>()
                .ToArray();
            return UnityContainer.Resolve<T>(null, overridesArray); //null needed to avoid a StackOverflow :)
        }
    }
}
