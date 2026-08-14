create table things
(
    id      uniqueidentifier not null
        constraint things_pk
            primary key,
    caption nvarchar(100)
);
