using System.Web.Mvc;
using Blog.Bussiness;
using Blog.Bussiness.DtoConverter;
using Blog.Bussiness.Repositories.Login_Repository;
using Blog.Bussiness.Repositories.Post;
using Blog.Layers.Bussiness.DtoMappers;
using Blog.Repository;
using Unity;
using Unity.Injection;
using Unity.Mvc5;

namespace Blog
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IAccountRepository, AccountRepository>();
            container.RegisterType<IEntryRepository, EntryRepository>();
            container.RegisterType<IUserMapper, UserMapper>();
            
            
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}