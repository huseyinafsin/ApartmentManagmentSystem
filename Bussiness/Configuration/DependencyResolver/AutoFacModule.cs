using System.Reflection;
using Autofac;
using Bussiness.Abstracts.Apartment;
using Bussiness.Concrete.Apartment;
using Bussiness.Configuration.Mapper;
using Core.Repository;
using Core.Service.Abstract;
using Core.Service.Concretye;
using Core.Utilities.Security.JWT;
using DataAccess.Concrete;
using DataAccess.Contexts;
using Module = Autofac.Module;


namespace Bussiness.Configuration.DependencyResolver
{
    public class AutoFacModule : Module
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
