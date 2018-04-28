using System;
using Autofac;

namespace Hxf.Infrastructure.EventSources.Ioc
{
    public class IocContainer{

        private IocContainer() { }

        private static IContainer _container;

        public static IContainer Container => _container;

        public static void Initialize(Action<ContainerBuilder> buildAtion) {
            if (buildAtion == null) {
                throw new Exception(nameof(buildAtion));
            }

            var builder=new ContainerBuilder();
            buildAtion(builder);
            _container = builder.Build();
        }

        public static void Initialize1(IContainer Container)
        {
            
            _container = Container;
        }

        public static TService Resolve<TService>() {
            return _container.Resolve<TService>();
        }

        public static object Resolve(Type serviceType) 
        {
            return _container.Resolve(serviceType) ;
        }

        public static TService Resolve<TService>(Type serviceType)where TService:class
        {
            return _container.Resolve(serviceType) as TService;
        }
    }
}
