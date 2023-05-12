using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Sklad
{
    public int Idtovara { get; set; }

    public int Amount { get; set; }

    public int Idskalda { get; set; }

    public virtual Tovari IdtovaraNavigation { get; set; } = null!;
}
