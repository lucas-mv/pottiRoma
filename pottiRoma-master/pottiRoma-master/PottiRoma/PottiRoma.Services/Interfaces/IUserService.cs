using PottiRoma.Entities;
using PottiRoma.Entities.Internal;
using PottiRoma.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Services.Interfaces
{
    public interface IUserService
    {
        void Logout(string userId);
        void ChangePassword(Guid userId, string oldPassword, string newPassword);
        UserEntity ResetPassword(Guid userId);
        UserEntity GetUserById(Guid userId);
        UserEntity GetUserByEmail(string email);
        UserEntity Authenticate(string email, string password, AuthOrigin origin);
        UserEntity RegisterUser(string email, string password, string name,
            string primaryTelephone, string secundaryTelephone, string cpf, UserType userType, string cep,
            int AverageTicketPoints, int RegisterClientsPoints, int salesNumberPoints, int averageTtensPerSalepoints,
            int inviteAllyFlowersPoints, Guid temporadaId, Guid motherFlowerId, bool isActive, DateTime birthday);
        void UpdateUserPoints(Guid usuarioId, int averageTicketPoints, int registerClientsPoints, int salesNumberPoints, int averageItensPerSalePoints, int inviteAllyFlowersPoints);
        List<UserEntity> GetAppUsers();
        void UpdateUser(Guid usuarioId, string email, string primaryTelephone, string secundaryTelephone, string cep);
        List<SalespersonEntity> GetAllSalespeople();
        byte[] GenerateSalespeopleReport();
        int GetUserInvitePointsForChallenge(Guid usuarioId);
        List<UserEntity> GetAllAppUsers();
        void UpdateUserStatus(Guid userId, bool isActive);
    }
}
