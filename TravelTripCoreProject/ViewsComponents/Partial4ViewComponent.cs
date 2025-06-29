using Microsoft.AspNetCore.Mvc;
using TravelTripCoreProject.DataAccessLayer.Contexts;

namespace TravelTripCoreProject.ViewsComponents
{
    public class Partial4ViewComponent : ViewComponent
    {
        private readonly Context _context;
        public Partial4ViewComponent(Context context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var value = _context.Blogs.Take(3).ToList();
            return View(value);
        }
    }
}
