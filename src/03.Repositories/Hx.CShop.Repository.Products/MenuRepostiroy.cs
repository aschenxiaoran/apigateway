using System.Threading.Tasks;
using Hx.CShop.Domain.Products;
using Hxf.Infrastructure.Data;

namespace Hx.CShop.Repository.Products
{
    public class MenuRepository : Repository<Menu>
    {

        public MenuRepository(IEntityframeworkContext unitOfWork) : base(unitOfWork)
        {

        }
        public async Task<Menu> FindMenu(string menuCode) {
            var menu = await GetAsync(r => r.Code == menuCode);
            return menu;
        }
    }
}