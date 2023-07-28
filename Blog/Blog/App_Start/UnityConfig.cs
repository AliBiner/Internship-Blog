using System.Web.Mvc;
using Blog.Bussiness;
using Blog.Bussiness.Repositories.Login_Repository;
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
            container.RegisterType<IAccountPRepository, AccountPRepository>();
            
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}