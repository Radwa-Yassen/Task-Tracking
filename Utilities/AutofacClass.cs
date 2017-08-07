using Application.IServices;
using Application.Services;
using Autofac;
using Autofac.Integration.Mvc;
//using Autofac.Integration.WebApi;
using DLL;
using DLL.Repositories;
using DLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Http;

namespace Task_Tracking
{
    public class AutofacClass
    {
        public IContainer autoFacContainer { get; private set; }
        public ContainerBuilder autoFacContainerbuilder { get; private set; }

        protected virtual void RegisterComponents(ContainerBuilder builder, object[] lifetimeScopeTags)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest(lifetimeScopeTags);
            builder.RegisterType<TaskRepository>().As<ITaskRepository>().InstancePerRequest(lifetimeScopeTags);
            builder.RegisterType<TaskService>().As<ITaskService>().InstancePerRequest(lifetimeScopeTags);

        }
    }
}