using Microsoft.AspNetCore.Mvc;
using TravelTripCoreProject.Models.Classes;

namespace TravelTripCoreProject.ViewsComponents
{
    public class LeaveCommentViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            var model = new Comment { BlogId = id };
            return View(model);
        }
    }
}
