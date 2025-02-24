using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class RecivedNotification
{
    public int NotificationId { get; set; }

    public int Sid { get; set; }

    public bool? IsRead { get; set; }

    public virtual Notification Notification { get; set; } = null!;

    public virtual Learner SidNavigation { get; set; } = null!;
}
