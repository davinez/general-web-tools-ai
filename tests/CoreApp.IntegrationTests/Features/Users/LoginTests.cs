using System;
using System.Threading.Tasks;
using CoreApp.API.Domain;
using CoreApp.API.Features.Users;
using CoreApp.API.Infrastructure.Security;
using Xunit;

namespace CoreApp.IntegrationTests.Features.Users;

public class LoginTests : SliceFixture
{
  [Fact]
  public async Task Expect_Login()
  {
    var salt = Guid.NewGuid().ToByteArray();
    var person = new Person
    {
      Username = "username",
      Email = "email",
      Hash = await new PasswordHasher().Hash("password", salt),
      Salt = salt
    };
    await InsertAsync(person);

    var command = new Login.Command(
        new Login.UserData { Email = "email", Password = "password" }
    );

    var user = await SendAsync(command);

    Assert.NotNull(user?.User);
    Assert.Equal(user.User.Email, command.User.Email);
    Assert.Equal("username", user.User.Username);
    Assert.NotNull(user.User.Token);
  }
}
