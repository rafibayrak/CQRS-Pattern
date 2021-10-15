using Autofac;
using MediatorProject.CommandHandlers;
using MediatorProject.Core.IRepositories;
using MediatorProject.Core.IServices;
using MediatorProject.Core.IUnitOfWorks;
using MediatorProject.Data;
using MediatorProject.Data.Repositories;
using MediatorProject.Data.Services;
using MediatorProject.Data.UnitOfWork;
using MediatR.Extensions.Autofac.DependencyInjection;

namespace MediatorProject.Business.Dependencies
{
    public class DependencyRegister : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MediatorDataContext>().As<IMediatorDataContext>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(RepositoryService<>)).As(typeof(IService<>)).InstancePerDependency();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerDependency();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerDependency();
            builder.RegisterMediatR(typeof(DefineCommandHandler).Assembly);
        }
    }
}
