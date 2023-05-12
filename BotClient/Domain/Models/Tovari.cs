using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Tovari
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public decimal Price { get; set; }

    public string Descryption { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual ICollection<Sklad> Sklads { get; } = new List<Sklad>();

    public virtual ICollection<TovariList> TovariLists { get; } = new List<TovariList>();
}
