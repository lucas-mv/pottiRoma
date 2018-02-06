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

        public UserEntity RegisterUser(string email, string password, string name,
            string primaryTelephone, string secundaryTelephone, string cpf, UserType userType, string cep,
            int AverageTicketPoints, int RegisterClientsPoints, int salesNumberPoints, int averageTtensPerSalepoints,
            int inviteAllyFlowersPoints, Guid temporadaId, Guid motherFlowerId, bool isActive)
        {
            return UserBusiness.RegisterUser( email, password, name,
             primaryTelephone, secundaryTelephone, cpf, userType, cep,
             AverageTicketPoints, RegisterClientsPoints, salesNumberPoints, averageTtensPerSalepoints,
             inviteAllyFlowersPoints, temporadaId, motherFlowerId, isActive);
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

        public void UpdateUserPoints(Guid usuarioId, int averageTicketPoints, int registerClientsPoints, int salesNumberPoints, int averageItensPerSalePoints, int inviteAllyFlowersPoints)
        {
            UserBusiness.UpdateUserPoints(usuarioId, averageTicketPoints, registerClientsPoints, salesNumberPoints, averageItensPerSalePoints, inviteAllyFlowersPoints);
        }

        public List<UserEntity> GetAppUsers()
        {
            return UserBusiness.GetAppUsers();
        }
    }
}
