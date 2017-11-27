using Globomantics.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Globomantics
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Configures mvc service to add mvc middleware.
            services.AddMvc();

            // Configures DI middleware.
            services.AddSingleton<IConferenceService, ConferenceMemoryService>();
            services.AddSingleton<IProposalService, ProposalMemoryService>();

            // Configures app settings to be used as a service.
            services.Configure<GlobomanticsOptions>(this._configuration.GetSection("Globomantics"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();
            app.UseStaticFiles();

            // Configures to use MVC in the pipeline.
            app.UseMvc(route => route.MapRoute(
                    name: "default",
                    template: "{controller=Conference}/{Action=Index}/{id?}"
                ));
        }
    }
}
