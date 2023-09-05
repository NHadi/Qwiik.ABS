using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Quiik.ABS.Common.Repositories;
using Quiik.ABS.Common.Repositories.Interface;

namespace Quiik.ABS.Common
{
    //public class QuiikCommonModule
    //{
    //    public static void RegisterServices(IServiceCollection services)
    //    {
    //        services.AddScoped(typeof(IEfRepository<>), typeof(EfRepository<>));
    //    }
    //}
    public class QuiikCommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IEfRepository<>))
                .InstancePerLifetimeScope();
        }
    }
}