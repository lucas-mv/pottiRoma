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
    public class LogInsertPointsRepository : BaseDataAccess<LogInsertPointsEntity, LogInsertPointsQuery>
    {
        #region Instance

        private static LogInsertPointsRepository _instance;
        public static LogInsertPointsRepository Get()
        {
            if (_instance == null)
                _instance = new LogInsertPointsRepository();

            return _instance;
        }

        #endregion

        #region Commands

        private const string INSERT_NEW_LOG = @"
        INSERT INTO dbo.LogInserirPontos 
        (
	        UsuarioId, 
	        UserEmail, 
	        AverageTicket, 
	        RegisterNewClients, 
	        SalesNumber, 
	        AverageItensPerSale, 
	        InviteFlower,
            Description
        )
        VALUES 
        (
	        @usuarioid, 
	        @useremail, 
	        @averageticket, 
	        @registernewclients, 
	        @salesnumber, 
	        @averageitenspersale, 
	        @inviteflower,
            @description
        )";

        #endregion

        #region Public methods

        public void InsertNewLog(LogInsertPointsEntity log)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@usuarioid", log.UsuarioId, System.Data.DbType.Guid);
            parameters.Add("@useremail", log.UserEmail, System.Data.DbType.AnsiString);
            parameters.Add("@averageticket", log.AverageTicket, System.Data.DbType.Int32);
            parameters.Add("@registernewclients", log.RegisterNewClients, System.Data.DbType.Int32);
            parameters.Add("@salesnumber", log.SalesNumber, System.Data.DbType.Int32);
            parameters.Add("@averageitenspersale", log.AverageItensPerSale, System.Data.DbType.Int32);
            parameters.Add("@inviteflower", log.InviteFlower, System.Data.DbType.Int32);
            parameters.Add("@description", log.Description, System.Data.DbType.AnsiString);

            Execute(INSERT_NEW_LOG, parameters);
        }

        #endregion

        #region Private methods

        protected override IEnumerable<LogInsertPointsEntity> Fill(IEnumerable<LogInsertPointsEntity> entity, LogInsertPointsQuery query)
        {
            return entity;
        }

        #endregion
    }
}
