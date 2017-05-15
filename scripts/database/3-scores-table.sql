
CREATE TABLE Scores (
    ScoreId int IDENTITY(1,1) PRIMARY KEY,
    Score int NOT NULL,
	Date date,
    UserId int FOREIGN KEY REFERENCES Users(UserId)
);