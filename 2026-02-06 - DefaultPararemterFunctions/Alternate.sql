CREATE OR ALTER FUNCTION fn_GetDayOfWeek
(
    @Day TINYINT = 4
)
    RETURNS NVARCHAR(15)
AS
BEGIN
    DECLARE @Return NVARCHAR(15);
    SELECT
        @Return = CASE @Day
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
    RETURN @Return;
END;
GO

