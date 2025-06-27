using System;
using System.Collections.Generic;

namespace TravelTripCoreProject.Models.Classes;

public partial class Address
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? StreetAddress { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Location { get; set; }
}
