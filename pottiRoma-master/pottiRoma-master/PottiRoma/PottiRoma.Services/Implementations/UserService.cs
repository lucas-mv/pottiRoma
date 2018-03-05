using PottiRoma.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PottiRoma.Entities;
using PottiRoma.Utils.Enums;
using PottiRoma.Business.User;
using PottiRoma.Entities.Internal;

namespace PottiRoma.Services.Implementations
{
    public class UserService : IUserService
    {
        public UserEntity Authenticate(string email, string password, AuthOrigin origin)
        {
            return UserBusiness.Authenticate(email, password, origin);
        }

        public void Logout(string userId)
        {
            UserBusiness.Logout(userId);
        }

        public UserEntity RegisterUser(string email, string password, string name,
            string primaryTelephone, string secundaryTelephone, string cpf, UserType userType, string cep,
            int AverageTicketPoints, int RegisterClientsPoints, int salesNumberPoints, int averageTtensPerSalepoints,
            int inviteAllyFlowersPoints, Guid temporadaId, Guid motherFlowerId, bool isActive, DateTime birthday)
        {
            return UserBusiness.RegisterUser( email, password, name,
             primaryTelephone, secundaryTelephone, cpf, userType, cep,
             AverageTicketPoints, RegisterClientsPoints, salesNumberPoints, averageTtensPerSalepoints,
             inviteAllyFlowersPoints, temporadaId, motherFlowerId, isActive, birthday);
        }

        public UserEntity GetUserById(Guid usuarioId)
        {
            return UserBusiness.GetUserById(usuarioId);
        }

        public UserEntity GetUserByEmail(string email)
        {
            return UserBusiness.GetUserByEmail(email);
        }

        public void ChangePassword(Guid UsuarioId, string oldPassword, string newPassword)
        {
            UserBusiness.ChangePassword(UsuarioId, oldPassword, newPassword);
        }

        public UserEntity ResetPassword(Guid usuarioId)
        {
            var user = GetUserById(usuarioId);
            user.Password = UserBusiness.ResetPassword(usuarioId);
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

        public void UpdateUser(Guid usuarioId, string email, string primaryTelephone, string secundaryTelephone, string cep)
        {
            UserBusiness.UpdateUser(usuarioId, email, primaryTelephone, secundaryTelephone, cep);
        }

        public List<SalespersonEntity> GetAllSalespeople()
        {
            return UserBusiness.GetAllSalespeople();
        }

        public byte[] GenerateSalespeopleReport()
        {
            return UserBusiness.GenerateSalespeopleReport();
        }
    }
}
