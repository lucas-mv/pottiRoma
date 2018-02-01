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
    public class SalesRepository : BaseDataAccess<SaleEntity, SalesQuery>
    {

        #region Instance

        private static SalesRepository _instance;
        public static SalesRepository Get()
        {
            if (_instance == null)
                _instance = new SalesRepository();

            return _instance;
        }

        #endregion

        #region Selects

        private const string GET_SALES_BY_USER_ID = @"
        SELECT 
	        VendaId AS SaleId, 
	        UsuarioId AS UserId, 
	        ClienteId AS ClientId, 
	        UserName AS UserName, 
	        ClientName AS ClientName,
	        SaleDate AS SaleDate,
	        SaleValue AS SaleValue,
	        SalePaidValue AS SalePaidValue, 
	        NumberSoldPieces AS NumberSoldPieces
        FROM dbo.Venda
        WHERE UsuarioId = @usuarioid";

        #endregion

        #region Commands

        private const string INSERT_NEW_SALE = @"
        INSERT INTO dbo.Venda 
        (
	        VendaId, 
	        UsuarioId, 
	        ClienteId, 
	        UserName, 
	        ClientName, 
	        SaleDate, 
	        SaleValue, 
	        SalePaidValue, 
	        NumberSoldPieces
        )
        VALUES 
        (
	        @vendaid, 
	        @usuarioid, 
	        @clienteid, 
	        @username, 
	        @clientname, 
	        @saledate, 
	        @salevalue, 
	        @salepaidvalue,
	        @numbersoldpieces
        )";

        #endregion

        #region Public methods

        public void InsertNewSale(SaleEntity sale)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@vendaid", sale.SaleId, System.Data.DbType.Guid);
            parameters.Add("@usuarioid", sale.UserId, System.Data.DbType.Guid);
            parameters.Add("@clienteid", sale.ClientId, System.Data.DbType.Guid);
            parameters.Add("@username", sale.UserName, System.Data.DbType.AnsiString);
            parameters.Add("@clientname", sale.ClientName, System.Data.DbType.AnsiString);
            parameters.Add("@saledate", sale.SaleDate, System.Data.DbType.DateTime);
            parameters.Add("@salevalue", sale.SaleValue, System.Data.DbType.Double);
            parameters.Add("@salepaidvalue", sale.SalePaidValue, System.Data.DbType.Double);
            parameters.Add("@numbersoldpieces", sale.NumberSoldPieces, System.Data.DbType.Int32);

            Execute(INSERT_NEW_SALE, parameters);
        }

        public List<SaleEntity> GetSalesByUserId(Guid userId)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@usuarioid", userId, System.Data.DbType.Guid);

            return Query(GET_SALES_BY_USER_ID, parameters).ToList();
        }

        #endregion

        #region Private methods

        protected override IEnumerable<SaleEntity> Fill(IEnumerable<SaleEntity> entity, SalesQuery query)
        {
            return entity;
        }

        #endregion
    }
}
