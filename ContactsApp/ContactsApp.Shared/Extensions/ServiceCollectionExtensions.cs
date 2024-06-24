using ContactsApp.Shared.Attributes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Shared.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AutoBind(this IServiceCollection source, params Assembly[] assemblies)
        {
            source.Scan(scan => scan.FromAssemblies(assemblies)
                .AddClasses(classes => classes.WithAttribute<AutoBindAttribute>())
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        }
    }
}
