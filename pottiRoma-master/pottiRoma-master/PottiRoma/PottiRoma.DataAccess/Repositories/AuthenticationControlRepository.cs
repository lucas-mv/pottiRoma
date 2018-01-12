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
    public class AuthenticationControlRepository : BaseDataAccess<AuthenticationControlEntity, AuthenticationControlQuery>
    {
        #region Instance

        private static AuthenticationControlRepository _instance;
        public static AuthenticationControlRepository Get()
        {
            if (_instance == null)
                _instance = new AuthenticationControlRepository();

            return _instance;
        }

        #endregion

        #region SQL COMMMANDS

        public const string INSERT_AUTH_CONTROL = @"
        INSERT INTO dbo.AuthenticationControl 
        (
	        UsuarioId, 
	        Token, 
	        DataRegistro, 
	        Origem, 
	        ManterConectado, 
            Valido
        )
        VALUES 
        (
	        @usuarioid, 
	        @token, 
	        @dataregistro, 
	        @origem, 
	        @manterconectado, 
            1
        )";

        private const string GET_AUTH_CONTROL = @"
        SELECT UsuarioId as UserId, 
        Token as Token, 
        DataRegistro as RegisterDate, 
        Origem as AuthOrigin, 
        ManterConectado as KeepAlive, 
        Valido as Active
        FROM dbo.AuthenticationControl
        WHERE UsuarioId = @usuarioid
        AND Token = @token
        AND Valido = 1";

        private const string DELETE_AUTH_CONTROL = @"
        UPDATE dbo.AuthenticationControl
        SET Valido = 0
        WHERE UsuarioId = @usuarioid
        AND Token = @token";

        private const string DELETE_ALL_USER_AUTH_CONTROL = @"
        UPDATE dbo.AuthenticationControl
        SET Valido = 0
        WHERE UsuarioId = @usuarioid";

        #endregion

        #region Public methods

        public void DeleteAllUserAuthControl(Guid userId)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@usuarioid", userId, System.Data.DbType.Guid);

            Execute(DELETE_ALL_USER_AUTH_CONTROL, parameters);
        }

        public void DeleteAuthControl(Guid userId, Guid token)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@usuarioid", userId, System.Data.DbType.Guid);
            parameters.Add("@token", token, System.Data.DbType.Guid);

            Execute(DELETE_AUTH_CONTROL, parameters);
        }

        public AuthenticationControlEntity GetAuthControl(Guid userId, Guid token)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@usuarioid", userId, System.Data.DbType.Guid);
            parameters.Add("@token", token, System.Data.DbType.Guid);

            return Query(GET_AUTH_CONTROL, parameters).FirstOrDefault();
        }

        public void InsertAuthControl(Guid userId, Guid token, AuthOrigin origin, bool manterConectado)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@usuarioid", userId, System.Data.DbType.Guid);
            parameters.Add("@token", token, System.Data.DbType.Guid);
            parameters.Add("@dataregistro", DateTime.UtcNow, System.Data.DbType.DateTime);
            parameters.Add("@origem", origin, System.Data.DbType.Int16);
            parameters.Add("@manterconectado", manterConectado, System.Data.DbType.Int16);

            Execute(INSERT_AUTH_CONTROL, parameters);
        }

        #endregion

        #region Private methods

        protected override IEnumerable<AuthenticationControlEntity> Fill(IEnumerable<AuthenticationControlEntity> entity, AuthenticationControlQuery query)
        {
            return entity;
        }

        #endregion
    }
}
