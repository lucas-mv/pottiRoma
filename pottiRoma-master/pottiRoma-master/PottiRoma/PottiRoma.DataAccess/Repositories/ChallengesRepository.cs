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
            DesafioId as DesafioId,
            TemporadaId as TemporadaId,
            Name as Name,
            StartDate as StartDate,
            EndDate as EndDate,
            Parameter as Parameter,
            Goal as Goal,
            Prize as Prize,
            Description as Description
        FROM dbo.Desafio
        WHERE TemporadaId = @temporadaid
        ";

        private const string GET_CURRENT_CHALLENGES_PORTAL = @"
        SELECT
            DesafioId as DesafioId,
            TemporadaId as TemporadaId,
            Name as Name,
            StartDate as StartDate,
            EndDate as EndDate,
            Parameter as Parameter,
            Goal as Goal,
            Prize as Prize,
            Description as Description
        FROM dbo.Desafio
        ";

        #endregion

        #region Commands

        private const string INSERT_NEW_CHALLENGE = @"
        INSERT INTO dbo.Desafio 
        (
            DesafioId,
	        TemporadaId, 
	        Name, 
	        StartDate, 
	        EndDate, 
	        Parameter, 
            Goal,
            Description,
            Prize
        )
        VALUES 
        (
            @desafioid,
	        @temporadaid, 
	        @name, 
	        @startdate, 
	        @enddate, 
	        @parameter,
            @goal,
            @description,
            @prize
        )";

        private const string UPDATE_CHALLENGE = @"
        UPDATE dbo.Desafio SET
 
	        TemporadaId = @temporadaid, 
	        Name = @name, 
	        StartDate = @startdate,
	        EndDate = @enddate,
	        Parameter = @parameter, 
            Goal = @goal,
            Description = @description,
            Prize = @prize
        WHERE DesafioId = @desafioId";

        #endregion

        #region Public methods

        public void InsertNewChallenge(ChallengeEntity challenge)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@desafioid", challenge.DesafioId, System.Data.DbType.Guid);
            parameters.Add("@temporadaid", challenge.TemporadaId, System.Data.DbType.Guid);
            parameters.Add("@name", challenge.Name, System.Data.DbType.String);
            parameters.Add("@startdate", challenge.StartDate, System.Data.DbType.DateTime);
            parameters.Add("@enddate", challenge.EndDate, System.Data.DbType.DateTime);
            parameters.Add("@parameter", challenge.Parameter, System.Data.DbType.Int16);
            parameters.Add("@goal", challenge.Goal, System.Data.DbType.Int16);
            parameters.Add("@description", challenge.Description, System.Data.DbType.String);
            parameters.Add("@prize", challenge.Prize, System.Data.DbType.Int16);
            Execute(INSERT_NEW_CHALLENGE, parameters);
        }

        public void UpdateChallenge(ChallengeEntity challenge)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@desafioid", challenge.DesafioId, System.Data.DbType.Guid);
            parameters.Add("@temporadaid", challenge.TemporadaId, System.Data.DbType.Guid);
            parameters.Add("@name", challenge.Name, System.Data.DbType.String);
            parameters.Add("@startdate", challenge.StartDate, System.Data.DbType.DateTime);
            parameters.Add("@enddate", challenge.EndDate, System.Data.DbType.DateTime);
            parameters.Add("@parameter", challenge.Parameter, System.Data.DbType.Int16);
            parameters.Add("@goal", challenge.Goal, System.Data.DbType.Int16);
            parameters.Add("@description", challenge.Description, System.Data.DbType.String);
            parameters.Add("@prize", challenge.Prize, System.Data.DbType.Int16);
            Execute(UPDATE_CHALLENGE, parameters);
        }

        public List<ChallengeEntity> GetCurrentChallenges(Guid temporadaId)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@temporadaid", temporadaId, System.Data.DbType.Guid);

            return Query(GET_CURRENT_CHALLENGES, parameters).ToList();
        }

        public List<ChallengeEntity> GetCurrentChallengesPortal()
        {
            DynamicParameters parameters = new DynamicParameters();
            return Query(GET_CURRENT_CHALLENGES_PORTAL, parameters).ToList();
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
