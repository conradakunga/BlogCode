--
-- Number queies
--
-- 1 to 10
select *
from generate_series(1, 10);
-- odd numbers
select *
from generate_series(0, 10, 2);
-- even numbers
select *
from generate_series(1, 10, 2);
-- 0.0 to 1.0 in steps of .05
select *
from generate_series(0.0, 1.0, 0.05);

--
-- Date queries
--

SELECT *
FROM generate_series('2026-01-01 00:00 +00:00'::timestamptz,
                     '2026-01-10 00:00 +00:00'::timestamptz,
                     '1 day'::interval, 'Africa/Nairobi');

SELECT *
FROM generate_series('2026-01-01 00:00'::timestamp,
                     '2026-01-10 00:00'::timestamp,
                     '1 day');