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
        public static UserEntity GetUserById(Guid userId)
        {
            return UserRepository.Get().GetUserById(userId);
        }

        public static UserEntity RegisterUser(string email, string password, string name, string primaryTelephone, string secondaryTelephone, string cpf, UserType userType)
        {
            if (String.IsNullOrEmpty(email) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(name) ||
                String.IsNullOrEmpty(primaryTelephone) || String.IsNullOrEmpty(secondaryTelephone))
            {
                throw new ExceptionWithHttpStatus(System.Net.HttpStatusCode.BadRequest, Messages.OBRIGATORY_DATA_MISSING);
            }

            var oldUser = UserRepository.Get().GetUserByEmail(email);
            if (oldUser != null)
                throw new ExceptionWithHttpStatus(System.Net.HttpStatusCode.BadRequest, Messages.EMAIL_ALREADY_USED);

            var cryptoPassword = EncryptPassword(password);
            var newUserId = Guid.NewGuid();
            UserRepository.Get().InsertUser(newUserId, email, cryptoPassword.Password, cryptoPassword.Salt, name, primaryTelephone, secondaryTelephone, cpf, userType);
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

            if(ValidatePassword(password, user.PasswordSalt, user.Password))
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

        #region Private methods

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
