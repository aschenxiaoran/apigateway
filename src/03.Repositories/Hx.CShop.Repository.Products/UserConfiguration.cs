using Hx.CShop.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hx.CShop.Repository.Products {
    internal class MenuConfiguration : IEntityTypeConfiguration<Menu> {

        //public void Map(EntityTypeBuilder<Menu> builder) {
        //    builder.ToTable("Menu", "admins");
        //    builder.HasKey(c => c.Id);
        //    builder.Property(c => c.Name).HasMaxLength(255).IsRequired();

        //    builder.Property(t => t.Name).HasMaxLength(100);
        //    builder.Property(t => t.Code).HasMaxLength(100);
        //    builder.Property(t => t.CreateUserName).HasMaxLength(250);
        //    builder.Property(t => t.ModifyUserName).HasMaxLength(250);
        //    builder.Property(t => t.Remark).HasMaxLength(100);
        //}

        public void Configure(EntityTypeBuilder<Menu> builder) {
            builder.ToTable("Menu", "admins");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasMaxLength(255).IsRequired();

            builder.Property(t => t.Name).HasMaxLength(100);
            builder.Property(t => t.Code).HasMaxLength(100);
            builder.Property(t => t.CreateUserName).HasMaxLength(250);
            builder.Property(t => t.ModifyUserName).HasMaxLength(250);
            builder.Property(t => t.Remark).HasMaxLength(100);
        }
    }
}