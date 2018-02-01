using PottiRoma.Entities;
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
        UserEntity Authenticate(string email, string password);
        UserEntity RegisterUser(string email, string password, string name,
            string primaryTelephone, string secondaryTelephone, string cpf, UserType userType, string cep,
            int AverageTicketPoints, int RegisterClientsPoints, int salesNumberPoints, int averageTtensPerSalepoints,
            int inviteAllyFlowersPoints, Guid temporadaId, Guid motherFlowerId);
    }
}
