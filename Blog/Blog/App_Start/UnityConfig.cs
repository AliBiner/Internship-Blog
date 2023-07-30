using System.Web.Mvc;
using Blog.Controllers;
using Blog.Layers.Bussiness.DtoMappers;
using Blog.Layers.Bussiness.DtoMappers.CommentMapper;
using Blog.Layers.Bussiness.DtoMappers.EntryMapper;
using Blog.Layers.Bussiness.Services.CommentService;
using Blog.Layers.Bussiness.Services.EntryService;
using Blog.Layers.Controllers;
using Blog.Layers.Repositories;
using Blog.Layers.Repositories.CommentRepository;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
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
            container.RegisterType<IUserMapper, UserMapper>();
            container.RegisterType<IUserService, UserService>();

            container.RegisterType<IEntryRepository, EntryRepository>();
            container.RegisterType<IEntryService, EntryService>();
            container.RegisterType<IEntryMapper, EntryMapper>();

            container.RegisterType<ICommentRepository, CommentRepository>();
            container.RegisterType<ICommentService, CommentService>();
            container.RegisterType<ICommentMapper, CommentMapper>();






            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}