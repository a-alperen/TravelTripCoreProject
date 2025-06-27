using Microsoft.AspNetCore.Mvc;
using TravelTripCoreProject.Models.Classes;
namespace TravelTripCoreProject.ViewsComponents
{
    public class Partial3ViewComponent : ViewComponent
    {
        private readonly Context _context;
        public Partial3ViewComponent(Context context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.Blogs.Take(10).ToList();
            return View(values);
        }
    }
}
