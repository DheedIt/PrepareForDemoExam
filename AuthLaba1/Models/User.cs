using System;
using System.Collections.Generic;

namespace AuthLaba1.Models;

public partial class User
{
    public int Id { get; set; }

    public string Password { get; set; } = null!;

    public string Username { get; set; } = null!;

    public int GroupId { get; set; }

    public string UserType { get; set; } = null!;

    public virtual Group Group { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
