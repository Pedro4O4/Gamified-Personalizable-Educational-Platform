using System;
using System.Collections.Generic;

namespace LastTriel.Models;

public partial class Notification
{
    public int NotificationId { get; set; }

    public DateTime? TimeStamp { get; set; }

    public string Message { get; set; } = null!;

    public string? Urgency { get; set; }

    public virtual ICollection<RecivedNotification> RecivedNotifications { get; set; } = new List<RecivedNotification>();
}
