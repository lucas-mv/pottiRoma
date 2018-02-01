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
    public class ClientsRepository : BaseDataAccess<ClientEntity, ClientsQuery>
    {
        #region Instance

        private static ClientsRepository _instance;
        public static ClientsRepository Get()
        {
            if (_instance == null)
                _instance = new ClientsRepository();

            return _instance;
        }

        #endregion

        #region Selects

        private const string GET_BY_USER_ID = @"
        SELECT ClienteId as ClientId, 
        UsuarioId as UsuarioId,
        Name as Name, 
        Email as Email, 
        Telephone as Telephone, 
        Cep as Cep,
        Birthdate as Birthdate
        FROM dbo.Cliente
        WHERE UsuarioId = @usuarioid";

        #endregion

        #region Commands

        private const string INSERT_CLIENT = @"
        INSERT INTO dbo.Cliente 
        (
	        ClienteId, 
	        UsuarioId, 
	        Name, 
	        Email, 
	        Telephone, 
	        Cep, 
	        Birthdate
        )
        VALUES 
        (
	        @clienteid, 
	        @usuarioid, 
	        @name, 
	        @email, 
	        @telephone, 
	        @cep, 
            @birthdate
        )";

        #endregion

        #region Private methods

        protected override IEnumerable<ClientEntity> Fill(IEnumerable<ClientEntity> entity, ClientsQuery query)
        {
            return entity;
        }

        #endregion

        #region Public methods

        public void InsertClient(ClientEntity client)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@clienteid", client.ClienteId, System.Data.DbType.Guid);
            parameters.Add("@usuarioid", client.UsuarioId, System.Data.DbType.Guid);
            parameters.Add("@name", client.Name, System.Data.DbType.AnsiString);
            parameters.Add("@email", client.Email, System.Data.DbType.AnsiString);
            parameters.Add("@telephone", client.Telephone, System.Data.DbType.AnsiString);
            parameters.Add("@cep", client.Cep, System.Data.DbType.AnsiString);
            parameters.Add("@birthdate", client.Birthdate, System.Data.DbType.DateTime);

            Execute(INSERT_CLIENT, parameters);
        }

        public List<ClientEntity> GetClientsByUserId(Guid userId)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@usuarioid", userId, System.Data.DbType.Guid);

            return Query(GET_BY_USER_ID, parameters).ToList();
        }

        #endregion

    }
}
