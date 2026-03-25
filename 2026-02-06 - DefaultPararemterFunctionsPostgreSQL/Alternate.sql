CREATE OR REPLACE FUNCTION get_day_of_week(day INT DEFAULT 4)
RETURNS TEXT
LANGUAGE plpgsql
AS $$
BEGIN
    RETURN CASE day
               WHEN 1 THEN 'Monday'
               WHEN 2 THEN 'Tuesday'
               WHEN 3 THEN 'Wednesday'
               WHEN 4 THEN 'Thursday'
               WHEN 5 THEN 'Friday'
               WHEN 6 THEN 'Saturday'
               WHEN 7 THEN 'Sunday'
               ELSE 'Something went wrong'
        END;
END;
$$;