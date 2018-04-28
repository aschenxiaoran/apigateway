using FluentValidation;
using Hx.CShop.Domain.Products;
using Hxf.Infrastructure.Validation;

namespace Hx.CShop.Service.Products.Validator{
    public class MenuValidator : EntityValidator<Menu>{
        public MenuValidator() {
            RuleFor(m => m.ModuleCode).NotEmpty().WithMessage("²»ÄÜÎª¿Õ");
        }
    }
}