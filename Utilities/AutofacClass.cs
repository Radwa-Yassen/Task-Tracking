using Application.IServices;
using Application.Services;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using DLL;
using DLL.Repositories;
using DLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Task_Tracking
{
    public class AutofacClass
    {
        public IContainer autoFacContainer { get; private set; }
        public ContainerBuilder autoFacContainerbuilder { get; private set; }

        public object Configure(object httpConfig, object modules, object lifetimeScopeTag)
        {
            throw new NotImplementedException();
        }

        public IContainer Configure(HttpConfiguration globalConfiguration, List<Autofac.Module> modules, params object[] lifetimeScopeTags)
        {
            autoFacContainerbuilder = new ContainerBuilder();

            //The line below tells autofac, when a controller is initialized, pass into its constructor, the implementations of the required interfaces
            autoFacContainerbuilder.RegisterControllers(Assembly.GetCallingAssembly());
            autoFacContainerbuilder.RegisterApiControllers(Assembly.GetCallingAssembly());

            if (modules != null)
            {
                modules.ForEach(module =>
                {
                    autoFacContainerbuilder.RegisterModule(module);
                });
            }

            RegisterComponents(autoFacContainerbuilder, lifetimeScopeTags);

            if (this.autoFacContainer == null)
            {
                this.autoFacContainer = autoFacContainerbuilder.Build();
            }
            else
            {
                autoFacContainerbuilder.Update(this.autoFacContainer);
            }

            //This tells the MVC application to use myContainer as its dependency resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(this.autoFacContainer));
            globalConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(this.autoFacContainer);

            return this.autoFacContainer;
        }
        protected virtual void RegisterComponents(ContainerBuilder builder, object[] lifetimeScopeTags)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<TaskRepository>().As<ITaskRepository>().InstancePerRequest();
            builder.RegisterType<TaskService>().As<ITaskService>().InstancePerRequest();

        }
    }
}