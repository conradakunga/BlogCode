-- 1 to 10
select value
from generate_series(1, 10)
-- odd numbers
select value
from generate_series(0, 10, 2)
-- even numbers
select value
from generate_series(1, 10, 2)
-- 0.0 to 1.0 in steps of .05
select value