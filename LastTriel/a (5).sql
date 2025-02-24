CREATE PROCEDURE SendNotificationToLearner
    @LearnerID INT,
    @Message NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @NotificationID INT;
    DECLARE @TimeStamp DATETIME = GETDATE();

    -- Insert new notification
    INSERT INTO [dbo].[notification] ([time_stamp], [message], [urgency])
    VALUES (@TimeStamp, @Message, 'low');

    -- Get the last inserted notification ID
    SET @NotificationID = SCOPE_IDENTITY();

    -- Insert into received_notification
    INSERT INTO [dbo].[recived_notification] ([notification_id], [sid], [is_read])
    VALUES (@NotificationID, @LearnerID, 0);

    -- Logic to send the message to the learner can be added here
    -- This is a placeholder for the actual message sending logic
    -- You can replace this with your actual message sending code

    -- Example: Print message to console (for demonstration purposes)
    PRINT 'Message sent to learner with ID: ' + CAST(@LearnerID AS NVARCHAR) + ' - ' + @Message;
END;

execute SendNotificationToLearner 1, 'Hello, this is a notification message';


select * from recived_notification;


select *
from notification