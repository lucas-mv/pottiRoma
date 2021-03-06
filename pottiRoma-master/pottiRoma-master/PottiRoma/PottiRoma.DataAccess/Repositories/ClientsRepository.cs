﻿using Dapper;
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
        SELECT ClienteId as ClienteId, 
            UsuarioId as UsuarioId,
            Name as Name, 
            Email as Email, 
            Telephone as Telephone, 
            Cep as Cep,
            Birthdate as Birthdate
        FROM dbo.Cliente
        WHERE UsuarioId = @usuarioid AND IsActive = 1";

        private const string GET_ALL = @"
        SELECT ClienteId as ClienteId, 
            UsuarioId as UsuarioId,
            Name as Name, 
            Email as Email, 
            Telephone as Telephone, 
            Cep as Cep,
            Birthdate as Birthdate
        FROM dbo.Cliente
        WHERE IsActive = 1";

        #endregion

        #region Commands

        private const string UPDATE_CLIENT_INFO = @"
        UPDATE dbo.Cliente
        SET Name = @name,
	        Email = @email,
	        Telephone = @telephone,
 	        Cep = @cep,
            Birthdate = @birthdate
        WHERE ClienteId = @clienteid  
        ";

        private const string REMOVE_CLIENT = @"
        UPDATE dbo.Cliente
            SET IsActive = 0
            WHERE ClienteId = @clienteid";

        private const string INSERT_CLIENT = @"
        INSERT INTO dbo.Cliente 
        (
	        ClienteId, 
	        UsuarioId, 
	        Name, 
	        Email, 
	        Telephone, 
	        Cep, 
	        Birthdate,
            IsActive
        )
        VALUES 
        (
	        @clienteid, 
	        @usuarioid, 
	        @name, 
	        @email, 
	        @telephone, 
	        @cep, 
            @birthdate,
            1
        )";

        private const string GET_USER_CLIENT_POINTS_FOR_CHALLENGE = @"
            SELECT COUNT(*) AS PontosDesafioVigenteVendas FROM Desafio d
            LEFT JOIN Cliente c 												
            ON d.Parameter = 3 												
            WHERE @now BETWEEN d.StartDate AND d.EndDate 	
            AND c.RegisterDate BETWEEN d.StartDate AND d.EndDate
            AND c.UsuarioId = @usuarioid 
        ";

        #endregion

        #region Private methods

        protected override IEnumerable<ClientEntity> Fill(IEnumerable<ClientEntity> entity, ClientsQuery query)
        {
            return entity;
        }

        #endregion

        #region Public methods

        public void UpdateClientInfo(ClientEntity client)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@clienteid", client.ClienteId, System.Data.DbType.Guid);
            parameters.Add("@name", client.Name, System.Data.DbType.AnsiString);
            parameters.Add("@email", client.Email, System.Data.DbType.AnsiString);
            parameters.Add("@telephone", client.Telephone, System.Data.DbType.AnsiString);
            parameters.Add("@cep", client.Cep, System.Data.DbType.AnsiString);
            parameters.Add("@birthdate", client.Birthdate, System.Data.DbType.DateTime);

            Execute(UPDATE_CLIENT_INFO, parameters);
        }

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

        public void RemoveClient(Guid clienteId)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@clienteid", clienteId, System.Data.DbType.Guid);

            Execute(REMOVE_CLIENT, parameters);
        }

        public List<ClientEntity> GetClientsByUserId(Guid userId)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@usuarioid", userId, System.Data.DbType.Guid);

            return Query(GET_BY_USER_ID, parameters).ToList();
        }

        public List<ClientEntity> GetAllClients()
        {
            DynamicParameters parameters = new DynamicParameters();

            return Query(GET_ALL, parameters).ToList();
        }

        public int GetUserClientPointsForChallenge(Guid usuarioId, DateTime now)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@usuarioid", usuarioId, System.Data.DbType.Guid);
            parameters.Add("@now", now, System.Data.DbType.DateTime);

            return Query<int>(GET_USER_CLIENT_POINTS_FOR_CHALLENGE, parameters).FirstOrDefault();
        }

        #endregion

    }
}
