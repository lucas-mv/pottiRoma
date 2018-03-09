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
    public class TrophiesRepository : BaseDataAccess<TrophyEntity, TrophiesQuery>
    {
        #region Instance

        private static TrophiesRepository _instance;
        public static TrophiesRepository Get()
        {
            if (_instance == null)
                _instance = new TrophiesRepository();

            return _instance;
        }

        #endregion

        #region Selects

        private const string GET_TROPHIES = @"
        SELECT
            DesafioId as DesafioId,
            UsuarioId as UsuarioId,
            TemporadaId as TemporadaId,
            Name as Name,
            StartDate as StartDate,
            EndDate as EndDate,
            Parameter as Parameter,
            Goal as Goal
        FROM dbo.Trofeus
        WHERE UsuarioId = @usuarioid
        ";

        #endregion

        #region Commands

        private const string INSERT_NEW_TROPHY = @"
        INSERT INTO dbo.Trofeus 
        (
            DesafioId,
            UsuarioId,
	        TemporadaId, 
	        Name, 
	        StartDate, 
	        EndDate, 
	        Parameter, 
            Goal
        )
        VALUES 
        (
            @desafioid,
            @usuarioid,
	        @temporadaid, 
	        @name, 
	        @startdate, 
	        @enddate, 
	        @parameter,
            @goal
        )";

        #endregion

        #region Public methods

        public void InsertNewTrophy(TrophyEntity trophy)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@desafioid", trophy.DesafioId, System.Data.DbType.Guid);
            parameters.Add("@usuarioid", trophy.UsuarioId, System.Data.DbType.Guid);
            parameters.Add("@temporadaid", trophy.TemporadaId, System.Data.DbType.Guid);
            parameters.Add("@name", trophy.Name, System.Data.DbType.String);
            parameters.Add("@startdate", trophy.StartDate, System.Data.DbType.DateTime);
            parameters.Add("@enddate", trophy.EndDate, System.Data.DbType.DateTime);
            parameters.Add("@parameter", trophy.Parameter, System.Data.DbType.Int16);
            parameters.Add("@goal", trophy.Goal, System.Data.DbType.Int16);

            Execute(INSERT_NEW_TROPHY, parameters);
        }

        public List<TrophyEntity> GetTrophies(Guid usuarioId)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@usuarioid", usuarioId, System.Data.DbType.Guid);

            return Query(GET_TROPHIES,parameters).ToList();
        }

        #endregion

        #region Private methods

        protected override IEnumerable<TrophyEntity> Fill(IEnumerable<TrophyEntity> entity, TrophiesQuery query)
        {
            return entity;
        }

        #endregion
    }
}
