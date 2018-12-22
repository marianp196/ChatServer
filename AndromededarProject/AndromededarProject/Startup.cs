using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Andromedarproject.MessageDto.Contents;
using Andromedarproject.MessageRouter.Output;
using Andromedarproject.MessageRouter.BasicMessagePipe;
using AndromededarProject.Web.ClientInputHubs;
using AndromededarProject.Web.ConnectionPool;
using AndromededarProject.Web.InstanceInformations;
using AndromededarProject.Web.Output.Moq;
using AndromededarProject.Web.Output.ServerClients;
using AndromededarProject.Web.UserGroups.Moq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Andromedarproject.MessageRouter.Services;

namespace AndromededarProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.TryAddConnectionPool();
            services.TryAddUserGroupMoq();

            services.TryAddInstanceInformation().
                TryAddClientOutputMoq<TextContent>().
                TryAddServices<TextContent>();

            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/ChatHub");
            });

            app.UseMvc();
        }
    }
}
