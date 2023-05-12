using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class User
{
    public int Id { get; set; }

    public string Nickname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phonenumber { get; set; }

    public bool Auth { get; set; }

    public bool IsAdmin { get; set; }

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual ICollection<SavedAdress> SavedAdresses { get; } = new List<SavedAdress>();

    public virtual ICollection<TovariList> TovariLists { get; } = new List<TovariList>();
}
