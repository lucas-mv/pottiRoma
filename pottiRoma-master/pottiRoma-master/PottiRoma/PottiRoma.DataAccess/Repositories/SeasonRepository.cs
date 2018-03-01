using Dapper;
using PottiRoma.DataAccess.Core;
using PottiRoma.DataAccess.Query;
using PottiRoma.Entities.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.DataAccess.Repositories
{
    public class SeasonRepository : BaseDataAccess<SeasonEntity, SeasonQuery>
    {
        #region Instance

        private static SeasonRepository _instance;
        public static SeasonRepository Get()
        {
            if (_instance == null)
                _instance = new SeasonRepository();

            return _instance;
        }

        #endregion

        #region Selects

        private const string GET_CURRENT_SEASON = @"SELECT TemporadaId AS TemporadaId
        , Name AS Name
        , StartDate AS StartDate
        , EndDate AS EndDate
        , AverageTicketGoal AS AverageTicketGoal
        , AverageItensPerSaleGoal AS AverageItensPerSaleGoal
        , RegisterClientsGoal AS RegisterClientsGoal
        , SalesNumberGoal AS SalesNumberGoal
        , InviteFlowersGoal AS InviteFlowersGoal
        , IsActive AS IsActive
            FROM dbo.Temporada
            WHERE IsActive = 1";

        #endregion

        #region Commands

        private const string INSERT_SEASON = @"
        UPDATE dbo.Temporada
        SET IsActive = 0;        

        INSERT INTO dbo.Temporada 
        (
	        TemporadaId, 
	        Name, 
	        StartDate, 
	        EndDate, 
            IsActive
        )
        VALUES 
        (
	        @temporadaid, 
	        @name, 
	        @startdate, 
	        @enddate, 
	        @isactive
        )";

        #endregion


        #region Public Methods

        public SeasonEntity GetCurrentSeason()
        {
            return Query(GET_CURRENT_SEASON).FirstOrDefault();
        }

        public void InsertSeason(string name,DateTime StartDate, DateTime EndDate, bool IsActive)
        {
            DynamicParameters parameters = new DynamicParameters();
            Guid seasonId = Guid.NewGuid();

            parameters.Add("@temporadaid", seasonId, System.Data.DbType.Guid);
            parameters.Add("@name", name, System.Data.DbType.AnsiString);
            parameters.Add("@startdate", StartDate, System.Data.DbType.DateTime);
            parameters.Add("@enddate", EndDate, System.Data.DbType.DateTime);
            parameters.Add("@isactive", IsActive, System.Data.DbType.Boolean);

            Execute(INSERT_SEASON,parameters);
        }

        #endregion


        #region Private methods

        protected override IEnumerable<SeasonEntity> Fill(IEnumerable<SeasonEntity> entity, SeasonQuery query)
        {
            return entity;
        }

        #endregion
    }
}
