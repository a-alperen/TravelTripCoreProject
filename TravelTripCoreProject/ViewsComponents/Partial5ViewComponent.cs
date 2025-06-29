using Microsoft.AspNetCore.Mvc;
using TravelTripCoreProject.DataAccessLayer.Contexts;

namespace TravelTripCoreProject.ViewsComponents
{
    public class Partial5ViewComponent(Context context) : ViewComponent
    {
        private readonly Context _context = context;

        public IViewComponentResult Invoke()
        {
            var value = _context.Blogs.OrderByDescending(x => x.Id).Take(3).ToList();
            return View(value);
        }
    }
}
