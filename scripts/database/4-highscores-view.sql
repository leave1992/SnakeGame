CREATE View HighScores AS
Select u.Nickname,
       s.Score,
	   s.ScoreId
	   s.Date
FROM Users AS u
INNER JOIN Scores AS s ON s.UserId = u.UserId
