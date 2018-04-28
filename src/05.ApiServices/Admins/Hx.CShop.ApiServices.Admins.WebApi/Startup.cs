using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Hx.CShop.ApiServices.Admins.Executors;
using Hx.CShop.ApiServices.Admins.WebApi.Models;
using Hx.CShop.Service.Admins;
using Hxf.Infrastructure.Data;
using Hxf.Infrastructure.EventSources.Ioc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace Hx.CShop.ApiServices.Admins.WebApi {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc()
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddCors();
            services.Configure<AuthenticationServerConfig>(Configuration.GetSection("AuthenticationServerConfig"));

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options => {
                    var authenticationServerUrl = Configuration["AuthenticationServerConfig:Url"];
                    options.Authority = authenticationServerUrl;
                    options.RequireHttpsMetadata = false;
                    //微软jwt验证默认有5分钟的延迟，这里将延迟取消
                    options.JwtValidationClockSkew = new TimeSpan(0, 0, 0, 0, 0);
                });

            services.AddDbContext<AdminContext>(options => options
                .UseSqlServer(Configuration.GetConnectionString("AdminContext")));
            services.AddScoped<IEntityframeworkContext, AdminContext>();

            IocContainer.Initialize(builder => {
                builder.RegisterAssemblyTypes(typeof(NullCommandExecutor).Assembly)
                    .Where(x => x.Name.Contains("CommandExecutor"))
                    .AsImplementedInterfaces().AsSelf();
                builder.Populate(services);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseCors(configurePolicy: builder => {
                builder.AllowAnyOrigin() //允许任何来源的主机访问
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });

            app.UseMvc();
        }
    }
}