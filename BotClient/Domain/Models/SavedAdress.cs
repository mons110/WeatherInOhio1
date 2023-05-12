using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class SavedAdress
{
    public int UserId { get; set; }

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public int House { get; set; }

    public int? Building { get; set; }

    public int? Apartament { get; set; }

    public virtual User User { get; set; } = null!;
}
