create table things
(
    id      uniqueidentifier primary key default (newsequentialid()),
    caption nvarchar(100) not null
)
