using PottiRoma.DataAccess.Repositories;
using PottiRoma.Entities;
using PottiRoma.Entities.Internal;
using PottiRoma.Utils;
using PottiRoma.Utils.Constants;
using PottiRoma.Utils.CustomExceptions;
using PottiRoma.Utils.Enums;
using SimpleCrypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Business.User
{
    public static class UserBusiness
    {
        private static Random _random = new Random();

        public static UserEntity GetUserById(Guid userId)
        {
            var user = UserRepository.Get().GetUserById(userId);
            return user;
        }

        public static void Logout(string userId)
        {
            AuthenticationControlRepository.Get().DeleteAllUserAuthControl(new Guid(userId));
        }

        public static UserEntity RegisterUser(string email, string password, string name,
            string primaryTelephone, string secundaryTelephone, string cpf, UserType userType, string cep,
            int AverageTicketPoints, int RegisterClientsPoints, int salesNumberPoints, int averageTtensPerSalepoints,
            int inviteAllyFlowersPoints, Guid temporadaId, Guid motherFlowerId, bool isActive)
        {
            if (String.IsNullOrEmpty(email) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(name) ||
                String.IsNullOrEmpty(primaryTelephone) || String.IsNullOrEmpty(cpf))
            {
                throw new ExceptionWithHttpStatus(System.Net.HttpStatusCode.BadRequest, Messages.OBRIGATORY_DATA_MISSING);
            }

            var oldUser = UserRepository.Get().GetUserByEmail(email);
            if (oldUser != null)
                throw new ExceptionWithHttpStatus(System.Net.HttpStatusCode.BadRequest, Messages.EMAIL_ALREADY_USED);

            var cryptoPassword = EncryptPassword(password);
            var newUserId = Guid.NewGuid();
            UserRepository.Get().InsertUser(newUserId, email, cryptoPassword.Password, cryptoPassword.Salt, name, primaryTelephone,
                secundaryTelephone, cpf, userType, cep, AverageTicketPoints, RegisterClientsPoints, salesNumberPoints, averageTtensPerSalepoints, 
                inviteAllyFlowersPoints, temporadaId, motherFlowerId, isActive);
            var newUser = UserRepository.Get().GetUserById(newUserId);

            if (newUser == null)
                throw new ExceptionWithHttpStatus(System.Net.HttpStatusCode.BadRequest, Messages.USER_REGISTRATION_ERROR);
            return newUser;
        }

        public static UserEntity Authenticate(string email, string password)
        {
            UserEntity user;
            user = UserRepository.Get().GetUserAuth(email);

            if (user == null)
                throw new ExceptionWithHttpStatus(System.Net.HttpStatusCode.BadRequest, Messages.USER_INVALID);

            if (ValidatePassword(password, user.PasswordSalt, user.Password))
            {
                user.Password = string.Empty;
                user.PasswordSalt = string.Empty;
                return user;
            }
            else
            {
                throw new ExceptionWithHttpStatus(System.Net.HttpStatusCode.BadRequest, Messages.USER_INVALID);
            }
        }

        public static void ChangePassword(Guid userId, string oldPassword, string newPassword)
        {
            UserEntity user;
            user = UserRepository.Get().GetUserAuthById(userId);

            if (user == null)
                throw new ExceptionWithHttpStatus(System.Net.HttpStatusCode.BadRequest, Messages.USER_INVALID);

            if (ValidatePassword(oldPassword, user.PasswordSalt, user.Password))
            {
                var newPasswordEncryption = EncryptPassword(newPassword);
                UserRepository.Get().UpdateUserPassword(user.UsuarioId, newPasswordEncryption.Password, newPasswordEncryption.Salt);
            }
            else
            {
                throw new ExceptionWithHttpStatus(System.Net.HttpStatusCode.BadRequest, Messages.USER_INVALID);
            }
        }

        public static string ResetPassword(Guid userId)
        {
            UserEntity user;
            user = UserRepository.Get().GetUserAuthById(userId);

            if (user == null)
                throw new ExceptionWithHttpStatus(System.Net.HttpStatusCode.BadRequest, Messages.USER_INVALID);

            var newPassword = RandomString(10);
            var newPasswordEncryption = EncryptPassword(newPassword);
            UserRepository.Get().UpdateUserPassword(user.UsuarioId, newPasswordEncryption.Password, newPasswordEncryption.Salt);
            return newPassword;
        }

        public static void UpdateUserPoints(Guid usuarioId, int averageTicketPoints, int registerClientsPoints, int salesNumberPoints, int averageItensPerSalePoints, int inviteAllyFlowersPoints)
        {
            var user = new UserEntity()
            {
                UsuarioId = usuarioId,
                AverageTicketPoints = averageTicketPoints,
                RegisterClientsPoints = registerClientsPoints,
                SalesNumberPoints = salesNumberPoints,
                AverageItensPerSalePoints = averageItensPerSalePoints,
                InviteAllyFlowersPoints = inviteAllyFlowersPoints
            };
            UserRepository.Get().UpdateUserPoints(user);
        }

        public static List<UserEntity> GetAppUsers()
        {
            return UserRepository.Get().GetAppUsers();
        }

        #region Private methods

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        private static PasswordCrypto EncryptPassword(string password)
        {
            ICryptoService cryptoService = new PBKDF2();
            var crypto = new PasswordCrypto();
            crypto.Salt = cryptoService.GenerateSalt();
            crypto.Password = cryptoService.Compute(password);
            return crypto;
        }

        private static bool ValidatePassword(string password, string salt, string hashedPassword)
        {
            ICryptoService cryptoService = new PBKDF2();
            string hashedPassword2 = cryptoService.Compute(password, salt);
            return cryptoService.Compare(hashedPassword, hashedPassword2);
        }

        #endregion
    }
}
