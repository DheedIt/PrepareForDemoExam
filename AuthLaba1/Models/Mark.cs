using System;
using System.Collections.Generic;

namespace AuthLaba1.Models;

public partial class Mark
{
    public int Id { get; set; }

    public int ItemId { get; set; }

    public int Score { get; set; }

    public virtual Item Item { get; set; } = null!;
}
