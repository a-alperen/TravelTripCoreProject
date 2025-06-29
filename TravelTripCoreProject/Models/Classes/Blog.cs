using System;
using System.Collections.Generic;

namespace TravelTripCoreProject.Models.Classes;

public partial class Blog
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public DateTime DateTime { get; set; }

    public string? Description { get; set; }

    public string? BlogImage { get; set; }
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
