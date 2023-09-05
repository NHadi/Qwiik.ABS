using Autofac;
using Autofac.Core;
using AutoMapper;
using Quiik.ABS.Appointment.Domain.DTO;
using Quiik.ABS.Appointment.Domain;
using Quiik.ABS.Appointment.Domain.Interface;
using Quiik.ABS.Appointment.Infrastructure.Repositories;
using System.Reflection;

namespace Quiik.ABS.Appointment.Application
{
    public class AppointmentModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppointmentConfigurationRepository>().As<IAppointmentConfigurationRepository>();

            builder.RegisterType<AppointmentRepository>().As<IAppointmentRepository>();

            builder.RegisterType<TokenRepository>().As<ITokenRepository>();

            builder.RegisterType<AppointmentService>().As<IAppointmentService>();

            // Mapping Profile - Automapper
            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BookAppointmentRequest, Appointments>();
                cfg.CreateMap<Tokens, TokenDto>();
                cfg.CreateMap<Appointments, BookAppointmentResponse>()
                  .ForMember(dest => dest.IssueToken, opt => opt.MapFrom(src => src.Token.TokenNumber))
                  .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Token.Status));
 
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