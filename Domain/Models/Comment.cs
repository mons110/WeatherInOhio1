using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Comment
{
    public int UserId { get; set; }

    public int GoodId { get; set; }

    public int Rate { get; set; }

    public int? Comment1 { get; set; }

    public virtual Tovari Good { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
