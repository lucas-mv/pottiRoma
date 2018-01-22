using PottiRoma.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PottiRoma.Entities;
using PottiRoma.Utils.Enums;
using PottiRoma.Business.User;

namespace PottiRoma.Services.Implementations
{
    public class UserService : IUserService
    {
        public UserEntity Authenticate(string email, string password)
        {
            return UserBusiness.Authenticate(email, password);
        }

        public void Logout(string userId)
        {
            UserBusiness.Logout(userId);
        }

        public UserEntity RegisterUser(string email, string password, string name, string primaryTelephone, string secondaryTelephone, string cpf, UserType userType, DateTime birthday, Guid flowerId)
        {
            return UserBusiness.RegisterUser(email, password, name, primaryTelephone, secondaryTelephone, cpf, userType, birthday, flowerId);
        }

        public UserEntity GetUserById(Guid userId)
        {
            return UserBusiness.GetUserById(userId);
        }

        public void ChangePassword(Guid userId, string oldPassword, string newPassword)
        {
            UserBusiness.ChangePassword(userId, oldPassword, newPassword);
        }

        public UserEntity ResetPassword(Guid userId)
        {
            var user = GetUserById(userId);
            user.Password = UserBusiness.ResetPassword(userId);
            return user;
        }
    }
}
