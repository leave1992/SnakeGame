
CREATE TABLE Users (
    UserId int IDENTITY(1,1) PRIMARY KEY,
    Nickname varchar(255) NOT NULL,
    FullName varchar(255),
);