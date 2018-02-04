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
    public class GamificationPointsRepository : BaseDataAccess<GamificationPointsEntity, GamificationPointsQuery>
    {
        #region Instance

        private static GamificationPointsRepository _instance;
        public static GamificationPointsRepository Get()
        {
            if (_instance == null)
                _instance = new GamificationPointsRepository();

            return _instance;
        }

        #endregion

        #region Commands

        private const string UPDATE_GAMIFICATION_POINTS = @"
        UPDATE dbo.PontosGamificacao
        SET AverageTicket = @averageticket,
	        RegisterNewClients = @registernewclients,
	        SalesNumber = @salesnumber,
 	        AverageItensPerSale = @averageitenspersale,
            InviteFlower = @inviteflower
        WHERE PontosGamificacaoId = @pontosgamificacaoid";

        private const string GET_GAMIFICATION_POINTS_BY_ID = @"
        SELECT AverageTicket as AverageTicket, 
            RegisterNewClients as RegisterNewClients,
            SalesNumber as SalesNumber, 
            AverageItensPerSale as AverageItensPerSale, 
            InviteFlower as InviteFlower,
            PontosGamificacaoId as PontosGamificacaoId
        FROM dbo.PontosGamificacao
        WHERE PontosGamificacaoId = @pontosgamificacaoid";

        #endregion

        #region Private methods

        protected override IEnumerable<GamificationPointsEntity> Fill(IEnumerable<GamificationPointsEntity> entity, GamificationPointsQuery query)
        {
            return entity;
        }

        #endregion

        #region Public Methods

        public void UpdateGamificationPoints(GamificationPointsEntity pointsGamification)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@pontosgamificacaoid", pointsGamification.PontosGamificacaoId, System.Data.DbType.Guid);
            parameters.Add("@averageticket", pointsGamification.AverageTicket, System.Data.DbType.Int32);
            parameters.Add("@registernewclients", pointsGamification.RegisterNewClients, System.Data.DbType.Int32);
            parameters.Add("@salesnumber", pointsGamification.SalesNumber, System.Data.DbType.Int32);
            parameters.Add("@averageitenspersale", pointsGamification.AverageItensPerSale, System.Data.DbType.Int32);
            parameters.Add("@inviteflower", pointsGamification.InviteFlower, System.Data.DbType.Int32);
        }

        public GamificationPointsEntity GetGamificationPointsById(Guid gamificationPointsId)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@pontosgamificacaoid", gamificationPointsId, System.Data.DbType.Guid);

            return Query(GET_GAMIFICATION_POINTS_BY_ID, parameters).FirstOrDefault();
        }

        #endregion

    }
}
