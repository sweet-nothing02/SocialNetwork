using System;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.PLL.Views;

namespace SocialNetwork
{
    class Program
    {
        static MessageService messageService;
        static UserService userService;
        static FriendsService friendsService;

        public static MainView mainView;
        public static RegistrationView registrationView;
        public static AuthenticationView authenticationView;
        public static UserMenuView userMenuView;
        public static UserInfoView userInfoView;
        public static UserDataUpdateView userDataUpdateView;
        public static MessageSendingView messageSendingView;
        public static UserIncomingMessageView userIncomingMessageView;
        public static UserOutgoingMessageView userOutgoingMessageView;
        public static FriendAddingView friendAddingView;
        public static FriendDeletingView friendDeletingView;
        public static FriendsView friendsView;
        static void Main(string[] args)
        {
            userService = new UserService();
            messageService = new MessageService();
            friendsService = new FriendsService();

            mainView = new MainView();
            registrationView = new RegistrationView(userService);
            authenticationView = new AuthenticationView(userService);
            userMenuView = new UserMenuView();
            userInfoView = new UserInfoView();
            userDataUpdateView = new UserDataUpdateView();
            messageSendingView = new MessageSendingView(userService, messageService);
            userIncomingMessageView = new UserIncomingMessageView();
            userOutgoingMessageView = new UserOutgoingMessageView();
            friendsView = new FriendsView();
            friendAddingView = new FriendAddingView();
            friendDeletingView = new FriendDeletingView(friendsService, userService);

            while (true)
            {
                mainView.Show();
            }
        }
    }
}
