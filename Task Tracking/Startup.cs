using Microsoft.Owin;
using Owin;
using System.Collections.Generic;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

[assembly: OwinStartupAttribute(typeof(Task_Tracking.Startup))]
namespace Task_Tracking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var httpConfig = new System.Web.Http.HttpConfiguration();


            var autofacContainer = new AutofacClass();
            var modules = new List<Autofac.Module>();

            var container = autofacContainer.Configure(httpConfig, modules, null);

            app.UseAutofacMiddleware(container);

            app.UseAutofacMvc();
            app.UseAutofacWebApi(httpConfig);

            Task_Traking.App_Start.WebApiConfig.Register(httpConfig);

            app.UseWebApi(httpConfig);

        }



    }
}
