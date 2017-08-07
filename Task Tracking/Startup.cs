using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Task_Tracking.Startup))]
namespace Task_Tracking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var autofacContainer = new AutofacClass();

            //var container = autofacContainer.Configure(httpConfig, modules, Hangfire.AutofacJobActivator.LifetimeScopeTag);

             //app.UseAutofacMiddleware(container);

            ConfigureAuth(app);
        }

        
    }
}
