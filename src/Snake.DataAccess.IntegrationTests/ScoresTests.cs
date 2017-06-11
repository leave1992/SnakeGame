using Microsoft.EntityFrameworkCore;
using Snake.Game.Models;
using System;
using Xunit;

namespace Snake.DataAccess.Tests
{
    public class ScoresTests
    {
        private SnakeDBContext CreateContext()
        {
            var builder = new DbContextOptionsBuilder<SnakeDBContext>().UseInMemoryDatabase();
            return new SnakeDBContext(builder.Options);
        }

        [Fact]
        public void Add_NewScore_ShouldExist()
        {
            // Arrange
            var context = CreateContext();

            const int scoreId = 1;
            const int userId = 1;
            var score = new Scores
            {
                ScoreId = scoreId,
                UserId = userId,
                Score = 1000,
                Date = new DateTime(2017, 6, 1)
            };

            // Act
            context.Scores.Add(score);
            var expected = context.Scores.Find(scoreId);

            // Assert
            Assert.NotNull(expected);
        }
    }
}
