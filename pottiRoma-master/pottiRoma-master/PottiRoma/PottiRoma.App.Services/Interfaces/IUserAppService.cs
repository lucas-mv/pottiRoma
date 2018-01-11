using PottiRoma.App.Models.Requests.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Services.Interfaces
{
    public interface IUserAppService
    {
        Task ChangePassword(ChangePasswordRequest request);
    }
}
