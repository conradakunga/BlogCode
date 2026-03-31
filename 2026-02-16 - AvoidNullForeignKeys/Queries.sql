CREATE TABLE Genders
    (
        GenderID TINYINT PRIMARY KEY,
        Name     NVARCHAR(50)
    );

INSERT dbo.Genders
    (
        GenderID,
        Name
    )
VALUES
    (
        1, 'Male'
    ),
    (
        2, 'Female'
    );

CREATE TABLE Persons
    (
        PersonID  INT          PRIMARY KEY,
        FirstName NVARCHAR(50) NULL,
        LastName  NVARCHAR(50) NULL,
        GenderID  TINYINT      NULL
            REFERENCES dbo.Genders (GenderID)
    );


INSERT dbo.Persons
    (
        PersonID,
        FirstName,
        LastName,
        GenderID
    )
VALUES
    (
        1, 'James', 'Bond', 1
    ),
    (
        2, 'Jason', 'Bourne', 1
    ),
    (
        3, 'Jane', 'Bond', 2
    );

SELECT
        Persons.PersonID,
        Persons.FirstName,
        Persons.LastName,
        Genders.Name Gender
FROM
        dbo.Persons
    INNER JOIN
        dbo.Genders
            ON Genders.GenderID = Persons.GenderID;

INSERT dbo.Persons
    (
        PersonID,
        FirstName,
        LastName,
        GenderID
    )
VALUES
    (
        4, 'Great', 'Scott', NULL
    );

SELECT
        Persons.PersonID,
        Persons.FirstName,
        Persons.LastName,
        Genders.Name Gender
FROM
        dbo.Persons
    LEFT OUTER JOIN
        dbo.Genders
            ON Genders.GenderID = Persons.GenderID;

SELECT
        Persons.PersonID,
        Persons.FirstName,
        Persons.LastName,
        ISNULL(Genders.Name, 'UNKNOWN') Gender
FROM
        dbo.Persons
    LEFT OUTER JOIN
        dbo.Genders
            ON Genders.GenderID = Persons.GenderID;

INSERT dbo.Genders
    (
        GenderID,
        Name
    )
VALUES
    (
        3, 'UNKNOWN'
    );

INSERT dbo.Persons
    (
        PersonID,
        FirstName,
        LastName,
        GenderID
    )
VALUES
    (
        5, 'Evelyn', 'Salt', 3
    );