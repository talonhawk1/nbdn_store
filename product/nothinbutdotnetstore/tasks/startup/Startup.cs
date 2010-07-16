using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Web.Compilation;
using nothinbutdotnetstore.infrastructure.containers;
using nothinbutdotnetstore.infrastructure.containers.basic;
using nothinbutdotnetstore.infrastructure.logging;
using nothinbutdotnetstore.infrastructure.logging.simple;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;
using System.Linq;

namespace nothinbutdotnetstore.tasks.startup
{
    public class Startup
    {
        public static void run()
        {
            var factories = new Dictionary<Type, DependencyFactory>();
            configure_core_services(factories);
            configure_front_controller(factories);
            configure_service_layer(factories);
        }

        static void configure_service_layer(Dictionary<Type, DependencyFactory> factories)
        {
            factories.Add(typeof(CatalogTasks), CreateFactory(new StubCatalogTasks()));
        }

        static void configure_front_controller(Dictionary<Type, DependencyFactory> factories)
        {
            factories.Add(typeof(FrontController), CreateFactory(new DefaultFrontController(
                                                                           new DefaultCommandRegistry(new StubFakeCommandSet())
                                                                           )));

            factories.Add(typeof(RequestFactory), CreateFactory(new StubRequestFactory()));

            //            var view_assembly_type =
            //                Type.GetType("nothinbutdotnetstore.web.ui.views.DepartmentBrowser, nothinbutdotnetstore.web.ui");
            var views = Assembly.GetCallingAssembly().GetTypes().Where(x => x.GetInterface("ViewFor`1") != null);
            factories.Add(typeof(ResponseEngine), CreateFactory(new DefaultResponseEngine(
                                                                          new DefaultViewFactory(new DefaultViewRegistry(views)))));

            DefaultViewFactory.page_factory = BuildManager.CreateInstanceFromVirtualPath;
        }

        static void configure_core_services(Dictionary<Type, DependencyFactory> factories)
        {
            Container container = new BasicContainer(factories);
            factories.Add(typeof(LoggerFactory),new BasicDependencyFactory(() => new TextWriterLoggerFactory()));
            IOC.factory_resolver = () => container;
        }

        static SingletonFactory CreateFactory(object dependency)
        {
            return new SingletonFactory(new BasicDependencyFactory(() => dependency));
        }
    }
}