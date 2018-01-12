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
        UserEntity GetUserById(Guid userId);
        UserEntity Authenticate(string email, string password);
        UserEntity RegisterUser(string email, string password, string name, string primaryTelephone, string secondaryTelephone, string cpf, UserType userType);
    }
}
