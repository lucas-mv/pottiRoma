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
    public class RankingBySeasonRepository : BaseDataAccess<RankingBySeasonEntity, RankingBySeasonQuery>
    {
        #region Private methods

        protected override IEnumerable<RankingBySeasonEntity> Fill(IEnumerable<RankingBySeasonEntity> entity, RankingBySeasonQuery query)
        {
            return entity;
        }

        #endregion

        #region Instance

        private static RankingBySeasonRepository _instance;
        public static RankingBySeasonRepository Get()
        {
            if (_instance == null)
                _instance = new RankingBySeasonRepository();

            return _instance;
        }

        #endregion

        #region Commands

        private const string INSERT_RANKING_BY_SEASON = @"
        INSERT INTO dbo.RankingPorTemporada 
        (
	        Name, 
	        Email, 
            AverageTicketPoints,
            RegisterClientsPoints,
            SalesNumberPoints,
            AverageItensPerSalePoints,
            InviteAllyFlowersPoints,
            Season,
            StartDate,
            EndDate,
            TotalPoints
        )
        VALUES 
        (
	        @name, 
	        @email, 
            @averageticketpoints,
            @registerclientspoints,
            @salesnumberPoints,
            @averageitenspersalepoints,
            @inviteallyflowerspoints,
            @season,
            @startdate,
            @enddate,
            @totalpoints
        )";

        #endregion

        #region Public methods

        public void GenerateRankingBySeason(RankingBySeasonEntity rankingElement)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@name", rankingElement.Name, System.Data.DbType.AnsiString);
            parameters.Add("@email", rankingElement.Email, System.Data.DbType.AnsiString);
            parameters.Add("@averageticketpoints", rankingElement.AverageTicketPoints, System.Data.DbType.Int16);
            parameters.Add("@registerclientspoints", rankingElement.RegisterClientsPoints, System.Data.DbType.Int16);
            parameters.Add("@salesnumberpoints", rankingElement.SalesNumberPoints, System.Data.DbType.Int16);
            parameters.Add("@averageitenspersalepoints", rankingElement.AverageItensPerSalePoints, System.Data.DbType.Int16);
            parameters.Add("@inviteallyflowerspoints", rankingElement.InviteAllyFlowersPoints, System.Data.DbType.Int16);
            parameters.Add("@season", rankingElement.Season, System.Data.DbType.AnsiString);
            parameters.Add("@startdate", rankingElement.StartDate, System.Data.DbType.DateTime);
            parameters.Add("@enddate", rankingElement.EndDate, System.Data.DbType.DateTime);
            parameters.Add("@totalpoints", rankingElement.TotalPoints, System.Data.DbType.Int32);

            Execute(INSERT_RANKING_BY_SEASON, parameters);
        }

        #endregion
    }
}
