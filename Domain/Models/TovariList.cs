using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class TovariList
{
    public int UserId { get; set; }

    public int GoodId { get; set; }

    public int Amount { get; set; }

    public virtual Tovari Good { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
