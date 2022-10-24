DECLARE @Date DATE;

-- Full Date
SET @Date = '24 October 2022';

SELECT
    @Date [Full Date]

-- Full Date - 2 Digit Year
SET @Date = '24 October 22';

SELECT
    @Date [Full Date - 2 Digit Year]

-- Full Date Without Spaces
SET @Date = '24October2022';

SELECT
    @Date [Full Date Without Spaces]

-- Full Date Without Spaces - 2 Digit Year
SET @Date = '24October22';

SELECT
    @Date [Full Date Without Spaces - 2 Digit Year]

-- Short Date
SET @Date = '24 Oct 2022';

SELECT
    @Date [Short Date]

-- Short Date With Separator
SET @Date = '24 Oct,2022';

SELECT
    @Date [Short Date With Separator]

-- Short Date - 2 Digit Year
SET @Date = '24 Oct 22';

SELECT
    @Date [Short Date - 2 Digit Year]

-- Short Date Without Spaces
SET @Date = '24Oct2022';

SELECT
    @Date [Short Date Without Spaces]

-- Short Date Without Spaces - 2 Digit Year
SET @Date = '24Oct22';

SELECT
    @Date [Short Date Without Spaces - 2 Digit Year]

-- International Format
SET @Date = '2022-10-24';

SELECT
    @Date [International Format]

-- International Format Without Spaces
SET @Date = '20221024';

SELECT
    @Date [International Format Without Spaces]

-- International Format - 2 Digit Year Without Spaces
SET @Date = '221024';

SELECT
    @Date [International Format - 2 Digit Year Without Spaces]

