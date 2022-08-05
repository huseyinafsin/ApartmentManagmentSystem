using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using Bussiness.Abstracts;
using Bussiness.Abstracts.Apartment;
using Bussiness.Concrete;
using Bussiness.Concrete.Apartment;
using Bussiness.Configuration.Mapper;
using Castle.DynamicProxy;
using Core.Entity.Concrete;
using Core.Repository;
using Core.Service.Abstract;
using Core.Service.Concretye;
using Core.Utilities.Security.JWT;
using DataAccess.Concrete;
using DataAccess.Contexts;
using Microsoft.Extensions.Configuration;
using Module = Autofac.Module;


namespace Bussiness.DependencyResolver
{
    public class RepoServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(ApartmentContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MappingProfile));
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            builder.RegisterType<AuthService>().As<IAuthService>();

            builder.RegisterGeneric(typeof(IRepository<>)).As(typeof(EfGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<,>)).As(typeof(IService<,>)).InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
           



        }
    }
}
