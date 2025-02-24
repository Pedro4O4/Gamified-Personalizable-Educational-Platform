select *
from notification

select *
from recived_notification
go
create procedure AssessmentNot
@NotificationID int,
@timestamp datetime,
@message varchar(max),
@urgencylevel varchar(50),
@LearnerID int
as
begin

(select @NotificationID= max (notification_id)+1 from 
notification) 
set  identity_insert notification on
insert into notification (notification_id,message, time_stamp, urgency)
values (@NotificationID,@message, GETDATE(), @urgencylevel)
insert into recived_notification (sid, notification_id)
values (@LearnerID, SCOPE_IDENTITY())
print 'Notification sent successfully'
set identity_insert notification off
end
drop procedure AssessmentNot




--11