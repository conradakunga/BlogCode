CREATE OR ALTER PROC GetDayOfWeek @Day TINYINT = 8
AS
BEGIN
    IF @Day = 8
        BEGIN
            RAISERROR('Something went wrong', 16, 1);
            RETURN;
        END;
    SELECT
        CASE @Day
            WHEN 1
                THEN
                'Monday'
            WHEN 2
                THEN
                'Tuesday'
            WHEN 3
                THEN
                'Wednesday'
            WHEN 4
                THEN
                'Thursday'
            WHEN 5
                THEN
                'Friday'
            WHEN 6
                THEN
                'Satruday'
            WHEN 7
                THEN
                'Sunday'
            END;
END;
GO

