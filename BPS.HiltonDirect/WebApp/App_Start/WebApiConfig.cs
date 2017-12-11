using BPS.HiltonDirect.Core;
using BPS.HiltonDirect.Core.Context;
using BPS.HiltonDirect.Core.Handler;
using BPS.HiltonDirect.Core.Unity;
using BPS.HiltonDirect.Model;
using BPS.HiltonDirect.Repositories;
using BPS.HiltonDirect.Repositories.Mapping;
using BPS.HiltonDirect.Services;
using BPS.HiltonDirect.WebApp.Attribute;
using Microsoft.Practices.Unity;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BPS.HiltonDirect.WebApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = UnityConfig.GetConfiguredContainer();
            config.MessageHandlers.Add(new MessageHandler());
            //Enable cors globally
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            MapperBinding(container);
            SetupWebApi(config, container);
            SetUpCustomErrorForWebApi();
        }

        private static void MapperBinding(IUnityContainer container)
        {
            container.RegisterType<ILogger, Logger>();
            container.RegisterType<IUserContext, UserContext>(new HierarchicalLifetimeManager());
            container.RegisterType<HiltonDirectEntities>(new HierarchicalLifetimeManager(), new InjectionFactory(c =>
                new HiltonDirectEntities(ConfigManager.ConnectionString.DbContext, container.Resolve<IUserContext>())));
            var context = new HiltonDirectEntities(ConfigManager.ConnectionString.DbContext, container.Resolve<IUserContext>());
            context.Database.Initialize(force: false);

            container.RegisterType<IPersonMapper, PersonMapper>();
            container.RegisterType<IRequestMapper, RequestMapper>();

            container.RegisterType<IPersonRepository, PersonRepository>();
            container.RegisterType<IRequestRepository, RequestRepository>();

            container.RegisterType<IPersonService, PersonService>();
            container.RegisterType<IFileReadingService, FileReadingService>();
            container.RegisterType<IResourceStringService, ResourceStringService>();
            container.RegisterType<IRequestService, RequestService>();
        }

        private static void SetupWebApi(HttpConfiguration config, IUnityContainer container)
        {
            config.DependencyResolver = new UnityResolver(container);
            config.Filters.Add(ExceptionHandlingAttribute.CreateInstance());
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static void SetUpCustomErrorForWebApi()
        {
            var config = (CustomErrorsSection)
                    ConfigurationManager.GetSection("system.web/customErrors");

            if (config == null)
            {
                return;
            }
            IncludeErrorDetailPolicy errorDetailPolicy;

            switch (config.Mode)
            {
                case CustomErrorsMode.RemoteOnly:
                    errorDetailPolicy
                        = IncludeErrorDetailPolicy.LocalOnly;
                    break;
                case CustomErrorsMode.On:
                    errorDetailPolicy
                        = IncludeErrorDetailPolicy.Never;
                    break;
                case CustomErrorsMode.Off:
                    errorDetailPolicy
                        = IncludeErrorDetailPolicy.Always;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = errorDetailPolicy;
        }
    }
}
