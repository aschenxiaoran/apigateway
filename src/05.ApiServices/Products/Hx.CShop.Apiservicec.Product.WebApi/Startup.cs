using Autofac;
using Autofac.Extensions.DependencyInjection;
using Hx.CShop.ApiService.Products.Excutors;
using Hx.CShop.Service.Products;
using Hxf.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Hxf.Infrastructure.EventSources.Ioc;

namespace Hx.CShop.Apiservicec.Product.WebApi {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddMvc ();
            services.AddCors ();

            services.AddAuthentication ("Bearer")
                .AddIdentityServerAuthentication (options => {
                    var authenticationServerUrl = Configuration["AuthenticationServerConfig:Url"];
                    options.Authority = authenticationServerUrl;
                    options.RequireHttpsMetadata = false;
                });

            services.AddDbContext<AdminContext> (options => options
                .UseSqlServer (Configuration.GetConnectionString ("AdminContext")));
            services.AddScoped<IEntityframeworkContext, AdminContext> ();

            IocContainer.Initialize (builder => {
                builder.RegisterAssemblyTypes (typeof (RegisterCommandExecutor).Assembly)
                    .Where (x => x.Name.Contains ("CommandExecutor"))
                    .AsImplementedInterfaces ();
                builder.Populate (services);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.UseAuthentication ();

            app.UseCors (configurePolicy: builder => {
                builder.AllowAnyOrigin () //允许任何来源的主机访问
                    .AllowAnyMethod ()
                    .AllowAnyHeader ();
            });

            app.UseMvc ();
        }
    }
}