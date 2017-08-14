using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Snake.DataAccess.Repositories;
using Snake.Game.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Snake.DataAccess.Tests
{
    public class GenericRepositoryTests
    {
        public static SnakeDBContext GenerateCoontext()
        {
            var options = CreateNewContextOptions();

            var context = new SnakeDBContext(options);
            context.Users.AddRange(GetUsers());
            context.SaveChanges();

            return context;
        }

        private static DbContextOptions<SnakeDBContext> CreateNewContextOptions()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<SnakeDBContext>();
            builder.UseInMemoryDatabase()
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        private static List<User> GetUsers()
        {
            return new List<User>
            {
                new User
                {
                    UserId = 1,
                    FullName = "Full name",
                    Nickname = "NickName"
                },
                new User
                {
                    UserId = 2,
                    FullName = "Full name 2",
                    Nickname = "NickName2"
                },
                new User
                {
                    UserId = 3,
                    FullName = "Full name 3",
                    Nickname = "NickName3"
                },
            };
        }

        [Fact]
        public void GetByID_ShouldReturn_User()
        {
            // Arrange
            const int userId = 1;
            var context = GenerateCoontext();
            GenericRepository<User> repository = new GenericRepository<User>(context);

            //Act
            var result = repository.GetByID(userId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(userId, result.UserId);
        }

        [Fact]
        public void GetAll_ShouldReturn_AllUsers()
        {
            // Arrange
            const int usersCount = 3;
            var context = GenerateCoontext();

            GenericRepository<User> repository = new GenericRepository<User>(context);

            //Act
            var users = repository.Get();

            //Assert
            Assert.NotNull(users);
            Assert.Equal(usersCount, users.Count());
        }

        [Fact]
        public void Delete_ShouldDelete_User()
        {
            // Arrange
            const int userId = 1;
            const int count = 2;
            var context = GenerateCoontext();

            GenericRepository<User> repository = new GenericRepository<User>(context);

            //Act
            repository.Delete(userId);
            context.SaveChanges();

            var users = context.Users.Count();
            var user = context.Users.SingleOrDefault(u => u.UserId == userId);

            //Assert
            Assert.Null(user);
            Assert.Equal(count, users);
        }

        [Fact]
        public void Insert_ShouldInsert_NewUser()
        {
            // Arrange
            const int userId = 4;
            var context = GenerateCoontext();

            GenericRepository<User> repository = new GenericRepository<User>(context);

            var user = new User()
            {
                UserId = userId,
                FullName = "Full name4",
                Nickname = "NickName4"
            };
            //Act
            repository.Insert(user);
            context.SaveChanges();

            var newUser = context.Users.SingleOrDefault(u => u.UserId == userId);

            //Assert
            Assert.NotNull(newUser);
            Assert.Equal(userId, newUser.UserId);
        }
    }
    
}
