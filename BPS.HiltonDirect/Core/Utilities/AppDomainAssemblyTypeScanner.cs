using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BPS.HiltonDirect.Core.Utilities
{
    public static class AppDomainAssemblyTypeScanner
    {
        static AppDomainAssemblyTypeScanner()
        {
            UpdateTypes();
        }

        private static IEnumerable<Type> types;
        private static IEnumerable<Assembly> assemblies;

        public static IEnumerable<Type> Types
        {
            get
            {
                return types;
            }
        }

        public static IEnumerable<Assembly> Assemblies
        {
            get
            {
                return assemblies;
            }
        }

        public static IEnumerable<Type> InterfacesWithAttribute<TAttribute>() where TAttribute : Attribute
        {
            var interfaces = (
                from assembly in assemblies
                from type in assembly.GetExportedTypes()
                where type.IsInterface
                select type).ToArray();

            return interfaces
                .Where(i => Attribute.IsDefined(i, typeof(TAttribute)));

        }

        public static IEnumerable<Type> TypesWithAttribute<TAttribute>() where TAttribute : Attribute
        {
            return Types
                .Where(a => Attribute.IsDefined(a, typeof(TAttribute)));
        }


        public static IEnumerable<Type> TypesOf<TType>()
        {
            return Types
                .Where(type => typeof(TType).IsAssignableFrom(type));
        }

        public static Func<Assembly, bool>[] AssembliesToScan = new Func<Assembly, bool>[]
        {
            x =>
            {
                return x.GetName().Name.Contains("Platform") &&
                       x.GetName().Name.Contains("Test") == false;
            }
        };

        private static void UpdateAssemblies()
        {


            assemblies = (
                from assembly in AppDomain.CurrentDomain.GetAssemblies()
                where AssembliesToScan.Any(a => a(assembly))
                where assembly.IsDynamic == false
                where assembly.ReflectionOnly == false
                select assembly).ToArray();

            //load assemblies for modules not loaded in the current AppDomain

            var files = new System.IO.DirectoryInfo(AppDomain.CurrentDomain.SetupInformation.PrivateBinPath)
                .GetFiles("Platform.*.dll")
                .Where(fi => assemblies.All(a => !(a.CodeBase.Split(@"/\".ToCharArray()).LastOrDefault() ?? "").Equals(fi.Name, StringComparison.InvariantCultureIgnoreCase)));

            assemblies = assemblies.Union(
                files.Select(file => Assembly.LoadFrom(file.FullName))
                    .Where(assembly => !assembly.IsDynamic && !assembly.ReflectionOnly)
                ).ToArray();
        }

        public static void UpdateTypes()
        {
            UpdateAssemblies();

            types = (
                from assembly in assemblies
                from type in assembly.GetExportedTypes()
                where type.IsAbstract == false
                select type).ToArray();
        }


    }
}
