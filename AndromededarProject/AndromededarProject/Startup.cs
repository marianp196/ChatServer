using Andromedarproject.MessageDto.Contents;
using AndromededarProject.Web.ClientInputHubs;
using AndromededarProject.Web.ConnectionPool;
using AndromededarProject.Web.InstanceInformations;
using AndromededarProject.Web.Output.ServerClients;
using AndromededarProject.Web.UserGroups.Moq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Andromedarproject.MessageRouter.Services.ContentMessageServices;
using Andromedarproject.MessageRouter.BasicMessagePipe;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

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

            services.TryAddInstanceInformation();

            services.TryAddClientOutput<TextContent>().TryAddContentService<TextContent>();

            services.AddSignalR();

			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie();

			services.ConfigureApplicationCookie(options =>
			{
				options.Cookie.SameSite = SameSiteMode.None;
			});

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

            app.UseCors(builder => {
                builder.AllowAnyMethod()
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });

			app.UseCookiePolicy();
			app.UseAuthentication();

			app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/ChatHub");
            });
			

			app.UseMvc();
        }
    }
}
