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
    public class SalespersonRepository : BaseDataAccess<SalespersonEntity, SalespersonQuery>
    {
        #region Instance

        private static SalespersonRepository _instance;
        public static SalespersonRepository Get()
        {
            if (_instance == null)
                _instance = new SalespersonRepository();

            return _instance;
        }

        #endregion

        #region Selects

        private const string GET_SALESPERSON_BY_ID = @"
        SELECT 
        VendedorId AS SalespersonId, 
        UsuarioId AS UserId, 
        FlorId AS FlowerId, 
        DataNascimento AS Birthday
        FROM dbo.Vendedor
        WHERE VendedorId = @vendedorid";

        #endregion

        #region Commands

        private const string INSERT_NEW_SALESPERSON = @"
        INSERT INTO dbo.Vendedor 
        (
	        VendedorId, 
	        UsuarioId, 
	        FlorId, 
	        DataNascimento
        )
        VALUES 
        (
	        @vendedorid, 
	        @usuarioid, 
	        @florid, 
	        @datanascimento
        )";

        #endregion

        #region Public methods

        public void InsertSalesperson(Guid userId, Guid salespersonId, Guid flowerId, DateTime birthDate)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@usuarioid", userId, System.Data.DbType.Guid);
            parameters.Add("@florid", flowerId, System.Data.DbType.Guid);
            parameters.Add("@vendedorid", salespersonId, System.Data.DbType.Guid);
            parameters.Add("@datanascimento", birthDate, System.Data.DbType.DateTime);
            
            Execute(INSERT_NEW_SALESPERSON, parameters);
        }

        public SalespersonEntity GetSalespersonById(Guid salespersonId)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@vendedorid", salespersonId, System.Data.DbType.Guid);

            return Query(INSERT_NEW_SALESPERSON, parameters).FirstOrDefault();
        }

        #endregion

        #region Private methods

        protected override IEnumerable<SalespersonEntity> Fill(IEnumerable<SalespersonEntity> entity, SalespersonQuery query)
        {
            return entity;
        }

        #endregion
    }
}
