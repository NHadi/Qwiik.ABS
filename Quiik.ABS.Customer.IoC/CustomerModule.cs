using Autofac;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Quiik.ABS.Customer.Application;
using Quiik.ABS.Customer.Domain;
using Quiik.ABS.Customer.Domain.DTO;
using Quiik.ABS.Customer.Domain.Interface;
using Quiik.ABS.Customer.Infrastructure;
using Quiik.ABS.Customer.Infrastructure.Repositories;

namespace Quiik.ABS.Customer.IoC
{
    public class CustomerModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Context
            builder.Register(x =>
            {
                var config = x.Resolve<IConfiguration>();
                var optionsBuilder = new DbContextOptionsBuilder<ABS_CustomersContext>();
                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
                return new ABS_CustomersContext(optionsBuilder.Options);
            }).InstancePerLifetimeScope();

            // Repositories
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();

            //Service
            builder.RegisterType<CustomerService>().As<ICustomerService>();

            // Mapping Profile - Automapper
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerRequest, Customers>();
                cfg.CreateMap<Customers, CustomerResponse>();
            })).AsSelf().SingleInstance();

            builder.Register(c =>
            {
                //This resolves a new context that can be used later.
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();

        }
    }
}