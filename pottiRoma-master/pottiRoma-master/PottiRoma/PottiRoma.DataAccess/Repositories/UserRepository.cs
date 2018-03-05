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

        private const string GET_APP_USERS = @"
        SELECT UsuarioId AS UsuarioId
              ,Cpf As Cpf
              ,Name as Name
              ,Email as Email
              ,PrimaryTelephone as PrimaryTelephone
              ,SecundaryTelephone as SecundaryTelephone
              ,UserType as UserType
              ,Cep as Cep
              ,AverageTicketPoints as AverageTicketPoints
              ,RegisterClientsPoints as RegisterClientsPoints
              ,SalesNumberPoints as SalesNumberPoints
              ,AverageItensPerSalePoints as AverageItensPerSalePoints
              ,InviteAllyFlowersPoints as InviteAllyFlowersPoints
              ,TemporadaId as TemporadaId
              ,MotherFlowerId as MotherFlowerId
              ,IsActive as IsActive,
              Birthday as Birthday
          FROM dbo.UsuarioPotti
          where IsActive = 1 AND UserType = 1";

        private const string GET_USER_BY_ID = @"
        SELECT UsuarioId AS UsuarioId
              ,Cpf As Cpf
              ,Name as Name
              ,Email as Email
              ,PrimaryTelephone as PrimaryTelephone
              ,SecundaryTelephone as SecundaryTelephone
              ,UserType as UserType
              ,Cep as Cep
              ,AverageTicketPoints as AverageTicketPoints
              ,RegisterClientsPoints as RegisterClientsPoints
              ,SalesNumberPoints as SalesNumberPoints
              ,AverageItensPerSalePoints as AverageItensPerSalePoints
              ,InviteAllyFlowersPoints as InviteAllyFlowersPoints
              ,TemporadaId as TemporadaId
              ,MotherFlowerId as MotherFlowerId
              ,IsActive as IsActive,
              Birthday as Birthday
          FROM dbo.UsuarioPotti
          where UsuarioId = @usuarioId";

        private const string GET_ALL_USERS = @"
        SELECT UsuarioId AS UsuarioId
              ,Cpf As Cpf
              ,Name as Name
              ,Email as Email
              ,PrimaryTelephone as PrimaryTelephone
              ,SecundaryTelephone as SecundaryTelephone
              ,UserType as UserType
              ,Cep as Cep
              ,AverageTicketPoints as AverageTicketPoints
              ,RegisterClientsPoints as RegisterClientsPoints
              ,SalesNumberPoints as SalesNumberPoints
              ,AverageItensPerSalePoints as AverageItensPerSalePoints
              ,InviteAllyFlowersPoints as InviteAllyFlowersPoints
              ,TemporadaId as TemporadaId
              ,MotherFlowerId as MotherFlowerId
              ,IsActive as IsActive,
              Birthday as Birthday
          FROM dbo.UsuarioPotti
          where IsActive = 1";

        private const string GET_USER_BY_EMAIL = @"
        SELECT UsuarioId AS UsuarioId
              ,Cpf As Cpf
              ,Name as Name
              ,Email as Email
              ,PrimaryTelephone as PrimaryTelephone
              ,SecundaryTelephone as SecundaryTelephone
              ,UserType as UserType
              ,Cep as Cep
              ,AverageTicketPoints as AverageTicketPoints
              ,RegisterClientsPoints as RegisterClientsPoints
              ,SalesNumberPoints as SalesNumberPoints
              ,AverageItensPerSalePoints as AverageItensPerSalePoints
              ,InviteAllyFlowersPoints as InviteAllyFlowersPoints
              ,TemporadaId as TemporadaId
              ,MotherFlowerId as MotherFlowerId
              ,IsActive as IsActive,
              Birthday as Birthday
          FROM dbo.UsuarioPotti
          where Email = @email";

        private const string GET_USER_AUTH_BY_EMAIL = @"
        SELECT UsuarioId AS UsuarioId
              ,Cpf As Cpf
              ,Name as Name
              ,Email as Email
              ,PrimaryTelephone as PrimaryTelephone
              ,SecundaryTelephone as SecundaryTelephone
              ,UserType as UserType
              ,Senha as Password
              ,Salt as PasswordSalt
              ,Cep as Cep
              ,AverageTicketPoints as AverageTicketPoints
              ,RegisterClientsPoints as RegisterClientsPoints
              ,SalesNumberPoints as SalesNumberPoints
              ,AverageItensPerSalePoints as AverageItensPerSalePoints
              ,InviteAllyFlowersPoints as InviteAllyFlowersPoints
              ,TemporadaId as TemporadaId
              ,MotherFlowerId as MotherFlowerId
              ,IsActive as IsActive,
              Birthday as Birthday
          FROM dbo.UsuarioPotti
          where Email = @email";

        private const string GET_USER_AUTH_BY_ID = @"
        SELECT UsuarioId AS UsuarioId
              ,Cpf As Cpf
              ,Name as Name
              ,Email as Email
              ,PrimaryTelephone as PrimaryTelephone
              ,SecundaryTelephone as SecundaryTelephone
              ,UserType as UserType
              ,Cep as Cep
              ,Senha as Password
              ,Salt as PasswordSalt
              ,AverageTicketPoints as AverageTicketPoints
              ,RegisterClientsPoints as RegisterClientsPoints
              ,SalesNumberPoints as SalesNumberPoints
              ,AverageItensPerSalePoints as AverageItensPerSalePoints
              ,InviteAllyFlowersPoints as InviteAllyFlowersPoints
              ,TemporadaId as TemporadaId
              ,MotherFlowerId as MotherFlowerId
              ,IsActive as IsActive,
              Birthday as Birthday
          FROM dbo.UsuarioPotti
          where UsuarioId = @usuarioid";

        #endregion

        #region Commands

        private const string UPDATE_USER = @"
        UPDATE dbo.UsuarioPotti
                SET Email = @email,
	                PrimaryTelephone = @primarytelephone,
	                SecundaryTelephone = @secundaryTelephone,
	                Cep = @cep
                WHERE UsuarioId = @usuarioid;";

        private const string INSERT_USER = @"
        INSERT INTO dbo.UsuarioPotti 
        (
	        UsuarioId, 
	        Cpf, 
	        Name, 
	        Email, 
	        PrimaryTelephone, 
	        SecundaryTelephone, 
	        UserType, 
            Cep,
	        Senha, 
	        Salt,
            AverageTicketPoints,
            RegisterClientsPoints,
            SalesNumberPoints,
            AverageItensPerSalePoints,
            InviteAllyFlowersPoints,
            TemporadaId,
            MotherFlowerId,
            IsActive,
            Birthday
        )
        VALUES 
        (
	        @usuarioid, 
	        @cpf, 
	        @name, 
	        @email, 
	        @primarytelephone, 
	        @secundarytelephone, 
	        @usertype,
            @cep,
	        @senha, 
	        @salt,
            @averageticketpoints,
            @RegisterClientsPoints,
            @salesnumberpoints,
            @averageitenspersalepoints,
            @inviteallyflowerspoints,
            @temporadaid,
            @motherflowerid,
            @isactive,
            @birthday
        )";

        private const string UPDATE_USER_PASSWORD = @"
        UPDATE dbo.UsuarioPotti
        SET Salt = @salt,
            Senha = @senha
        WHERE UsuarioId = @usuarioid  
        ";

        private const string UPDATE_USER_POINTS = @"
        UPDATE dbo.UsuarioPotti
        SET AverageTicketPoints = @averageTicketPoints,
	        RegisterClientsPoints = @registerClientsPoints,
	        SalesNumberPoints = @salesNumberPoints,
 	        AverageItensPerSalePoints = @averageItensPerSalePoints,
            InviteAllyFlowersPoints = @inviteAllyFlowersPoints
        WHERE UsuarioId = @usuarioid  
        ";

        #endregion

        #region Public methods


        public void UpdateUserPoints(UserEntity user)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@usuarioid", user.UsuarioId, System.Data.DbType.Guid);
            parameters.Add("@averageTicketPoints", user.AverageTicketPoints, System.Data.DbType.Int64);
            parameters.Add("@registerClientsPoints", user.RegisterClientsPoints, System.Data.DbType.Int64);
            parameters.Add("@salesNumberPoints", user.SalesNumberPoints, System.Data.DbType.Int64);
            parameters.Add("@averageItensPerSalePoints", user.AverageItensPerSalePoints, System.Data.DbType.Int64);
            parameters.Add("@inviteAllyFlowersPoints", user.InviteAllyFlowersPoints, System.Data.DbType.Int64);

            Execute(UPDATE_USER_POINTS, parameters);
        }

        public void UpdateUser(Guid usuarioId, string email, string primaryTelephone, string secundaryTelephone, string cep)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@usuarioid", usuarioId, System.Data.DbType.Guid);
            parameters.Add("@email", email, System.Data.DbType.AnsiString);
            parameters.Add("@primarytelephone", primaryTelephone, System.Data.DbType.AnsiString);
            parameters.Add("@secundarytelephone", secundaryTelephone, System.Data.DbType.AnsiString);
            parameters.Add("@cep", cep, System.Data.DbType.AnsiString);

            Execute(UPDATE_USER, parameters);
        }

        public List<UserEntity> GetAppUsers()
        {
            return Query(GET_APP_USERS).ToList();
        }

        public UserEntity GetUserById(Guid userId)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@usuarioId", userId, System.Data.DbType.Guid);

            return Query(GET_USER_BY_ID, parameters).FirstOrDefault();
        }

        public List<UserEntity> GetAllUsers()
        {
            DynamicParameters parameters = new DynamicParameters();

            return Query(GET_ALL_USERS, parameters).ToList();
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

        public UserEntity GetUserAuthById(Guid usuarioId)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@usuarioid", usuarioId, System.Data.DbType.Guid);

            return Query(GET_USER_AUTH_BY_ID, parameters).FirstOrDefault();
        }

        public void InsertUser(Guid usuarioId, string email, string password, string passwordSalt, string name, 
            string primaryTelephone, string secundaryTelephone, string cpf, UserType userType, string cep,
            int AverageTicketPoints, int RegisterClientsPoints, int salesNumberPoints, int averageTtensPerSalepoints,
            int inviteAllyFlowersPoints, Guid temporadaId, Guid motherFlowerId, bool isActive, DateTime birthday)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@usuarioid", usuarioId, System.Data.DbType.Guid);
            parameters.Add("@cpf", cpf, System.Data.DbType.AnsiString);
            parameters.Add("@email", email, System.Data.DbType.AnsiString);
            parameters.Add("@name", name, System.Data.DbType.AnsiString);
            parameters.Add("@primarytelephone", primaryTelephone, System.Data.DbType.AnsiString);
            parameters.Add("@secundarytelephone", secundaryTelephone, System.Data.DbType.AnsiString);
            parameters.Add("@usertype", userType, System.Data.DbType.Int16);
            parameters.Add("@cep", cep, System.Data.DbType.AnsiString);
            parameters.Add("@senha", password, System.Data.DbType.AnsiString);
            parameters.Add("@salt", passwordSalt, System.Data.DbType.AnsiString);
            parameters.Add("@averageticketpoints", AverageTicketPoints, System.Data.DbType.Int16);
            parameters.Add("@RegisterClientsPoints", RegisterClientsPoints, System.Data.DbType.Int16);
            parameters.Add("@salesnumberpoints", salesNumberPoints, System.Data.DbType.Int16);
            parameters.Add("@averageitenspersalepoints", averageTtensPerSalepoints, System.Data.DbType.Int16);
            parameters.Add("@inviteallyflowerspoints", inviteAllyFlowersPoints, System.Data.DbType.Int16);
            parameters.Add("@temporadaid", temporadaId, System.Data.DbType.Guid);
            parameters.Add("@motherflowerid", motherFlowerId, System.Data.DbType.Guid);
            parameters.Add("@isactive", isActive, System.Data.DbType.Boolean);
            parameters.Add("@birthday", birthday, System.Data.DbType.DateTime);

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
