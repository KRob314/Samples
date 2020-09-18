using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using SpyStore.Mvc.Support;

namespace SpyStore.Mvc.ViewComponents
{
    public class Menu : ViewComponent
    {
        private readonly SpyStoreServiceWrapper _serviceWrapper;

        public Menu(SpyStoreServiceWrapper spyStoreServiceWrapper)
        {
            _serviceWrapper = spyStoreServiceWrapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cats = await _serviceWrapper.GetCategoriesAsync();
            if (cats == null)
            {
                return new ContentViewComponentResult("There was an error getting the categories");
            }
            return View("MenuView", cats);
        }
    }
}
