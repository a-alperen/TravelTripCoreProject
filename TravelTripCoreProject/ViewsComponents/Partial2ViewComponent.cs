using Microsoft.AspNetCore.Mvc;
using TravelTripCoreProject.Models.Classes;
namespace TravelTripCoreProject.ViewsComponents
{
    public class Partial2ViewComponent(Context context) : ViewComponent
    {
        private readonly Context _context = context;

        public IViewComponentResult Invoke()
        {
            var value = _context.Blogs.Where(x => x.Id == 2).ToList();
            return View(value);
        }
    }
}
