using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Role { get; set; } = null!;

    public virtual Admin? Admin { get; set; }

    public virtual Instructor? Instructor { get; set; }
}
