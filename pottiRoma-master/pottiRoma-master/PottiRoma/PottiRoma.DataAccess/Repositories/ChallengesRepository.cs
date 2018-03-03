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
    public class ChallengesRepository : BaseDataAccess<ChallengeEntity, ChallengesQuery>
    {
        #region Instance

        private static ChallengesRepository _instance;
        public static ChallengesRepository Get()
        {
            if (_instance == null)
                _instance = new ChallengesRepository();

            return _instance;
        }

        #endregion

        #region Selects

        private const string GET_CURRENT_CHALLENGES = @"
        SELECT
            TemporadaId as TemporadaId,
            Name as Name,
            StartDate as StartDate,
            EndDate as EndDate,
            Parameter as Parameter,
            Goal as Goal
        FROM dbo.Desafio
        WHERE TemporadaId = @temporadaid
        ";

        #endregion

        #region Commands

        private const string INSERT_NEW_CHALLENGE = @"
        INSERT INTO dbo.Desafio 
        (
	        TemporadaId, 
	        Name, 
	        StartDate, 
	        EndDate, 
	        Parameter, 
            Goal
        )
        VALUES 
        (
	        @temporadaid, 
	        @name, 
	        @startdate, 
	        @enddate, 
	        @parameter,
            @goal      
        )";

        #endregion

        #region Public methods

        public void InsertNewChallenge(ChallengeEntity challenge)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@temporadaid", challenge.TemporadaId, System.Data.DbType.Guid);
            parameters.Add("@name", challenge.Name, System.Data.DbType.String);
            parameters.Add("@startdate", challenge.StartDate, System.Data.DbType.DateTime);
            parameters.Add("@enddate", challenge.EndDate, System.Data.DbType.DateTime);
            parameters.Add("@parameter", challenge.Parameter, System.Data.DbType.Int16);
            parameters.Add("@goal", challenge.Goal, System.Data.DbType.Int16);

            Execute(INSERT_NEW_CHALLENGE, parameters);
        }

        public List<ChallengeEntity> GetCurrentChallenges(Guid temporadaId)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@temporadaid", temporadaId, System.Data.DbType.Guid);

            return Query(GET_CURRENT_CHALLENGES, parameters).ToList();
        }

        #endregion

        #region Private methods

        protected override IEnumerable<ChallengeEntity> Fill(IEnumerable<ChallengeEntity> entity, ChallengesQuery query)
        {
            return entity;
        }

        #endregion
    }
}
