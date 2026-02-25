using System;
using System.Collections.Generic;

namespace AuthLaba1.Models;

public partial class Item
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Mark> Marks { get; set; } = new List<Mark>();

    public virtual User User { get; set; } = null!;
}
