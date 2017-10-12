using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Snake.Game.Models;
using System;
using System.Linq;
using Xunit;

namespace Snake.DataAccess.Tests
{
    public class UnitOfWorkTests
    {
        public static SnakeDBContext GenerateCoontext()
        {
            var options = CreateNewContextOptions();
            var context = new SnakeDBContext(options);
            return context;
        }

        private static DbContextOptions<SnakeDBContext> CreateNewContextOptions()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<SnakeDBContext>();
            builder.UseInMemoryDatabase(Guid.NewGuid().ToString())
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        [Fact]
        public void Save_ShouldSave_ContextChanges()
        {
            // Arrange
            var context = GenerateCoontext();
            var unitOfWork = new UnitOfWork(context);

            var user = new User
            {
                UserId = 1,
                Nickname = "Nickname",
                FullName = "FullName"
            };

            // Act
            context.Users.Add(user);
            unitOfWork.Save();

            //Assert
            Assert.True(context.Users.Any());
        }
    }
}
