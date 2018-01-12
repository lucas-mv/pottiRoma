using Dapper;
using PottiRoma.DataAccess.Core;
using PottiRoma.DataAccess.Query;
using PottiRoma.Entities;
using PottiRoma.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.DataAccess.Repositories
{
    public class UserRepository : BaseDataAccess<UserEntity, UserQuery>
    {
        #region Instance

        private static UserRepository _instance;
        public static UserRepository Get()
        {
            if (_instance == null)
                _instance = new UserRepository();

            return _instance;
        }

        #endregion

        #region Selects

        private const string GET_USER_BY_ID = @"
        SELECT UsuarioId AS UserId
              ,Cpf As Cpf
              ,Nome as UserName
              ,Email as Email
              ,TelefonePrimario as PrimaryTelephone
              ,TelefoneSecundario as SecondaryTelphone
              ,TipoUsuario as UserType
          FROM dbo.usuario
          where UsuarioId = @usuarioId";

        public const string GET_USER_BY_EMAIL = @"
        SELECT UsuarioId AS UserId
              ,Cpf As Cpf
              ,Nome as UserName
              ,Email as Email
              ,TelefonePrimario as PrimaryTelephone
              ,TelefoneSecundario as SecondaryTelphone
              ,TipoUsuario as UserType
          FROM dbo.usuario
          where Email = @email";

        private const string GET_USER_AUTH_BY_EMAIL = @"
        SELECT UsuarioId AS UserId
              ,Cpf As Cpf
              ,Nome as UserName
              ,Email as Email
              ,TelefonePrimario as PrimaryTelephone
              ,TelefoneSecundario as SecondaryTelphone
              ,TipoUsuario as UserType,
              Senha as Password,
              Salt as PasswordSalt
          FROM dbo.usuario
          where Email = @email";

        private const string GET_USER_AUTH_BY_ID = @"
        SELECT UsuarioId AS UserId
              ,Cpf As Cpf
              ,Nome as UserName
              ,Email as Email
              ,TelefonePrimario as PrimaryTelephone
              ,TelefoneSecundario as SecondaryTelphone
              ,TipoUsuario as UserType,
              Senha as Password,
              Salt as PasswordSalt
          FROM dbo.usuario
          where UsuarioId = @usuarioid";

        #endregion

        #region Commands

        private const string INSERT_USER = @"
        INSERT INTO dbo.Usuario 
        (
	        UsuarioId, 
	        Cpf, 
	        Nome, 
	        Email, 
	        TelefonePrimario, 
	        TelefoneSecundario, 
	        TipoUsuario, 
	        Senha, 
	        Salt
        )
        VALUES 
        (
	        @usuarioid, 
	        @cpf, 
	        @nome, 
	        @email, 
	        @telefoneprimario, 
	        @telefonesecundario, 
	        @tipousuario, 
	        @senha, 
	        @salt
        )";

        private const string UPDATE_USER_PASSWORD = @"
        UPDATE dbo.Usuario
        SET Senha = @senha,
	        Salt = @salt
        WHERE UsuarioId = @usuarioid";

        #endregion

        #region Public methods

        public UserEntity GetUserById(Guid userId)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@usuarioId", userId, System.Data.DbType.Guid);

            return Query(GET_USER_BY_ID, parameters).FirstOrDefault();
        }

        public UserEntity GetUserByEmail(string email)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@email", email, System.Data.DbType.AnsiString);

            return Query(GET_USER_BY_EMAIL, parameters).FirstOrDefault();
        }

        public UserEntity GetUserAuth(string email)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@email", email, System.Data.DbType.AnsiString);

            return Query(GET_USER_AUTH_BY_EMAIL, parameters).FirstOrDefault();
        }

        public UserEntity GetUserAuthById(Guid userId)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@usuarioid", userId, System.Data.DbType.Guid);

            return Query(GET_USER_AUTH_BY_ID, parameters).FirstOrDefault();
        }

        public void InsertUser(Guid usuarioId, string email, string password, string passwordSalt, string name, string primaryTelephone, string secondaryTelephone, string cpf, UserType userType)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@usuarioid", usuarioId, System.Data.DbType.Guid);
            parameters.Add("@cpf", cpf, System.Data.DbType.AnsiString);
            parameters.Add("@email", email, System.Data.DbType.AnsiString);
            parameters.Add("@nome", name, System.Data.DbType.AnsiString);
            parameters.Add("@telefoneprimario", primaryTelephone, System.Data.DbType.AnsiString);
            parameters.Add("@telefonesecundario", secondaryTelephone, System.Data.DbType.AnsiString);
            parameters.Add("@tipousuario", userType, System.Data.DbType.Int16);
            parameters.Add("@senha", password, System.Data.DbType.AnsiString);
            parameters.Add("@salt", passwordSalt, System.Data.DbType.AnsiString);

            Execute(INSERT_USER, parameters);
        }

        public void UpdateUserPassword(Guid usuarioId, string password, string salt)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@usuarioid", usuarioId, System.Data.DbType.Guid);
            parameters.Add("@senha", password, System.Data.DbType.AnsiString);
            parameters.Add("@salt", salt, System.Data.DbType.AnsiString);

            Execute(UPDATE_USER_PASSWORD, parameters);
        }

        #endregion

        #region Private methods

        protected override IEnumerable<UserEntity> Fill(IEnumerable<UserEntity> entity, UserQuery query)
        {
            return entity;
        }

        #endregion
    }
}
