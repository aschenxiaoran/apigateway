using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Hx.Infrastructure.Consuls;
using Hxf.Infrastructure.ApiGateway.Configuration;
using Hxf.Infrastructure.ApiGateway.Errors.Middleware;
using Hxf.Infrastructure.ApiGateway.LoadBalanceStrategy;
using Hxf.Infrastructure.ApiGateway.Requester;
using Hxf.Infrastructure.ApiGateway.Requester.Middleware;
using Hxf.Infrastructure.ApiGateway.Responser;
using Hxf.Infrastructure.ApiGateway.Responser.Middleware;
using Hxf.Infrastructure.ApiGateway.Route.Middleware;
using Hxf.Infrastructure.ApiGateway.ServiceDiscovery;
using Hxf.Infrastructure.ApiGateway.ServiceDiscovery.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Hxf.ApiGateway
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("apiroute.json", optional: true, reloadOnChange: true)
                .AddGatewayFile("gateway.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<ApiRouteConfig>(Configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IHttpClientCache, HttpClientCache>();
            services.TryAddSingleton<IHttpStatusCodeHandler, HttpStatusCodeHandler>();
            services.AddMvc();

            return RegisterAutofac(services);
        }

        private IServiceProvider RegisterAutofac(IServiceCollection services) {
            var builder = new ContainerBuilder();
            builder.Populate(services);


            builder.Register(c => new ConsulServiceDiscoveryProvider(GlobalConfig.ServiceDisconvery))
                .As<IServiceDiscoveryProvider>().InstancePerDependency();

            builder.RegisterType<DefaultLoadBalanceStrategy>().As<IServiceLoadBalancer>().SingleInstance();

            var componentContext = builder.Build();
            return new AutofacServiceProvider(componentContext);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.UseMiddleware<UncaughtExceptionMiddleware>();
            app.UseMiddleware<ResponderMiddleware>();
            app.UseMiddleware<InitHttpRequestMiddleware>();
            app.UseMiddleware<ResetRouteMiddleware>();
            app.UseMiddleware<LoadBalanceMiddleware>();
            app.UseMiddleware<RequestMiddleware>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
