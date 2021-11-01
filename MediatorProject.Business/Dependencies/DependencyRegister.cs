using Autofac;
using MediatorProject.CommandHandlers;
using MediatorProject.Core.IRepositories;
using MediatorProject.Data;
using MediatorProject.Data.Repositories;
using MediatR.Extensions.Autofac.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace MediatorProject.Business.Dependencies
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
