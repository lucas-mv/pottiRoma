using Dapper;
using PottiRoma.DataAccess.Core;
using PottiRoma.DataAccess.Query;
using PottiRoma.Entities;
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

        public const string GET_USER_BY_ID = @"
        SELECT usuarioId AS UserId
              ,cpf As Cpf
              ,nome as UserName
              ,email as Email
              ,telefonePrimario as PrimaryTelephone
              ,telefoneSecundario as SecondaryTelphone
              ,tipoUsuario as UserType
          FROM dbo.usuario
          where usuarioId = @usuarioId";

        #endregion

        #region Commands
        #endregion

        #region Public methods

        public UserEntity GetUserById(Guid userId)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@usuarioId", userId, System.Data.DbType.Guid);

            return Query(GET_USER_BY_ID, parameters).FirstOrDefault();
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
