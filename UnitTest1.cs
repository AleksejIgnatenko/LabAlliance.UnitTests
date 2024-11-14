using LabAlliance.MockData.Repositories;
using LabAllianceTest.API.Models;

namespace LabAlliance.UnitTests
{
    public class UnitTest1
    {
        private readonly UserRepositoryTest _userRepositoryTest;

        public UnitTest1()
        {
            _userRepositoryTest = new UserRepositoryTest();
        }

        [Fact]
        public async void Test1()
        {
            UserModel user = UserModel.Create(Guid.NewGuid(), "TestUnitLogin3", "12345678").user;

            var id = await _userRepositoryTest.CreateUserAsync(user);

            Assert.Equal(user.Id, id);
        }

        [Fact]
        public async void Test2()
        {
            string login = "TestUnitLogin";
            string password = "12345678";

            var user = await _userRepositoryTest.LoginUserAsync(login, password);

            Assert.Equal(user.Login, login);
        }

        [Fact]
        public async void Test3()
        {
            string login = "TestUnitLogin";
            string password = "12345678";

            var users = await _userRepositoryTest.GetAllUsersAsync();

            Assert.NotNull(users);
            Assert.Equal(users.Count, 3);
        }
    }

}