using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuthLaba1.Models;

public partial class User
{
    public int Id { get; set; }

    public string Password { get; set; } = null!;

    public string Username { get; set; } = null!;

    public int GroupId { get; set; }
	[RegularExpression("^(Student|Teacher)$", ErrorMessage = "Допустимые значения: Student или Teacher")]
	public string UserType { get; set; } = null!;

    public virtual Group Group { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
