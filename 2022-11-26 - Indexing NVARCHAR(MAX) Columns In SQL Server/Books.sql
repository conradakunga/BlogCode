CREATE TABLE Books
    (
        BookID      UNIQUEIDENTIFIER PRIMARY KEY
            DEFAULT (NEWSEQUENTIALID()),
        Title       NVARCHAR(500)    NOT NULL
            UNIQUE,
        PublishDate DATE             NOT NULL,
        Abstract    NVARCHAR(MAX)    NOT NULL
    );

GO

INSERT dbo.Books
    (
        Title,
        PublishDate,
        Abstract
    )
VALUES
    (
        'The Hunger Games', '09/14/08', ''
    ),
    (
        'Harry Potter and the Order of the Phoenix', '09/28/04', ''
    ),
    (
        'To Kill a Mockingbird', '05/23/06', ''
    ),
    (
        'Pride and Prejudice', '10/10/2000', ''
    ),
    (
        'Twilight', '09/06/2006', ''
    ),
    (
        'The Book Thief', '03/14/06', ''
    ),
    (
        'Animal Farm', '04/28/96', ''
    ),
    (
        'The Chronicles of Narnia', '09/16/02', ''
    ),
    (
        'J.R.R. Tolkien 4-Book Boxed Set: The Hobbit and The Lord of the Rings', '09/25/12', ''
    );

CREATE INDEX ixBookTitle
    ON dbo.Books (Title);

CREATE INDEX ixBookPublishDate
    ON dbo.Books (PublishDate);

CREATE INDEX ixBookAbstract
    ON dbo.Books (Abstract);

ALTER TABLE dbo.Books
ADD
    AbstactCheckSum AS CHECKSUM(Books.Abstract);
GO

CREATE INDEX ixBooksAbstractChecksum
    ON dbo.Books (AbstactCheckSum);

SELECT
    Books.BookID
FROM
    dbo.Books
WHERE
    Books.Abstract = 'Test';

IF EXISTS
    (
        SELECT
            Books.BookID
        FROM
            dbo.Books
        WHERE
            CHECKSUM('abstract text') = Books.AbstactCheckSum
    )
    PRINT 'Found';
ELSE
    PRINT 'not found';