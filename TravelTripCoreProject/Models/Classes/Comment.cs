using System;
using System.Collections.Generic;

namespace TravelTripCoreProject.Models.Classes;

public partial class Comment
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? UserComment { get; set; }

    public int BlogId { get; set; }

    public virtual Blog? Blog { get; set; }
}
