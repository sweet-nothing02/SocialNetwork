using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.PLL.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SocialNetwork.Tests
{
    public class FriendsTests
    {
        FriendsService friendsService;
        // Тест почему-то так и не запустился( А еще у всего проекта теста был какой-то другой значок и надпись "отложенное добавление"...
        // и надпись "отложенное добавление"... Мб из-за этого не запустился?
        [Fact]
        public void AddToFriendsMustThrowException()
        {
            friendsService = new FriendsService();

            Assert.Throws<FriendsException>(() => friendsService.AddToFriends(new FriendAddingData()
            { UserId = 3, FriendEmail = "chpauk@mail.ru" }));
        }
    }
}
