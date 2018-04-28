using System.Threading.Tasks;
using Hx.CShop.ApiService.Products.Commands;
using Hx.CShop.Repository.Products;
using Hxf.Infrastructure.Data;
using Hxf.Infrastructure.EventSources;

namespace Hx.CShop.ApiService.Products.Excutors {
    public class RegisterCommandExecutor2 : ICommandExecutor<RegisterCommand> {

        #region private methods

        private readonly MenuRepository _menuRepository;
        private readonly IEntityframeworkContext _efContext;

        #endregion

        #region ctor

        public RegisterCommandExecutor2(IEntityframeworkContext efContext) {
            _efContext = efContext;
            _menuRepository = new MenuRepository(efContext);
        }

        #endregion

        #region excute methods

        public async Task Excute(ICommand command) {
            var registerCommand = command as RegisterCommand;
            var menu = await _menuRepository.FindMenu(registerCommand.NickName);
            menu.Name = "采购2";
            _menuRepository.Modify(menu);
            await _efContext.CommitAsync();

        }

        #endregion
    }
}