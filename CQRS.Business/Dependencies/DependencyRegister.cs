using Autofac;
using CQRS.DataAccess.IRepositories;
using CQRS.Data;
using Microsoft.AspNetCore.Http;
using CQRS.DataAccess.Repositories;
using CQRS.Business.CommandHandlers;
using MediatR.Extensions.Autofac.DependencyInjection;

namespace CQRS.Business.Dependencies
{
    public class DependencyRegister : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerDependency();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerDependency();
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
            builder.RegisterMediatR(typeof(DefineCommandHandler).Assembly);
        }
    }
}
