using System;
using System.Collections.Generic;

namespace TravelTripCoreProject.Models.Classes;

public partial class Contact
{
    public int Id { get; set; }

    public string? NameSurname { get; set; }

    public string? Email { get; set; }

    public string? Subject { get; set; }

    public string? Message { get; set; }
}
