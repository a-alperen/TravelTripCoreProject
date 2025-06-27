using Microsoft.AspNetCore.Mvc;
using TravelTripCoreProject.Models.Classes;

namespace TravelTripCoreProject.ViewsComponents
{
    public class Partial1ViewComponent : ViewComponent
    {
        private readonly Context _context;
        public Partial1ViewComponent(Context context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var values = _context.Blogs.Take(2).ToList();
            return View(values); // View yolu: Views/Shared/Components/Partial1/Default.cshtml
        }
    }
}
