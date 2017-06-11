using Microsoft.EntityFrameworkCore;
using Snake.Game.Models;
using Xunit;

namespace Snake.DataAccess.IntegrationTests
{
    public class UsersTests
    {
        private SnakeDBContext CreateContext()
        {
            var builder = new DbContextOptionsBuilder<SnakeDBContext>().UseInMemoryDatabase();
            return new SnakeDBContext(builder.Options);
        }

        [Fact]
        public void Add_NewUser_ShouldExist()
        {
            // Arrange
            var context = CreateContext();

            const int userId = 1;
            var user = new User
            {
                UserId = userId,
                Nickname = "johny",
                FullName = "Johny Johnson"
            };

            // Act
            context.Users.Add(user);
            var expected = context.Users.Find(userId);

            // Assert
            Assert.NotNull(expected);
        }
    }
}
