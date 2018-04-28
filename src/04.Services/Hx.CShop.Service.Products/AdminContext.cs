using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Hx.CShop.Repository.Products;
using Hxf.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Hx.CShop.Service.Products {
    public class AdminContext : EntityframeworkContext, IAdminContext {
        //private readonly ILog _logger = LogManager.GetLogger("AdminContext", "AdminContext");
        //private static IEnumerable<IAdminMapper> _entityMappers;

            //private readonly IList<>
        static AdminContext() {
        }



        public AdminContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions) {

        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            RegisterEntityMapping(builder);
        }

        private static void RegisterEntityMapping(ModelBuilder builder) {
            var mappingInterface = typeof(IEntityTypeConfiguration<>);

            var mappingTypes = typeof(IAdminMapper).GetTypeInfo().Assembly.GetTypes()
                .Where(x => x.GetInterfaces()
                    .Any(y => y.GetTypeInfo().IsGenericType && y.GetGenericTypeDefinition() == mappingInterface));

            var entityMethod = typeof(ModelBuilder).GetMethods()
                .Single(x => x.Name == "Entity" &&
                             x.IsGenericMethod &&
                             x.ReturnType.Name == "EntityTypeBuilder`1");

            Parallel.ForEach(mappingTypes, mappingType => {
                var genericTypeArg = mappingType.GetInterfaces().Single().GenericTypeArguments.Single();
                var genericEntityMethod = entityMethod.MakeGenericMethod(genericTypeArg);
                var entityBuilder = genericEntityMethod.Invoke(builder, null);
                var mapper = Activator.CreateInstance(mappingType);
                mapper.GetType().GetMethod("Configure").Invoke(mapper, new[] {entityBuilder});
            });
        }
    }
}