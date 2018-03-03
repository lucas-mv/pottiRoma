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

        private const string GET_ALL_SALES = @"
        SELECT * FROM dbo.Venda
        ";

        private const string GET_SALES_BY_USER_ID = @"
        SELECT 
	        VendaId AS VendaId, 
	        UsuarioId AS UsuarioId, 
	        ClienteId AS ClienteId, 
	        UserName AS UserName, 
	        ClientName AS ClientName,
	        SaleDate AS SaleDate,
	        SaleValue AS SaleValue,
	        SalePaidValue AS SalePaidValue, 
	        NumberSoldPieces AS NumberSoldPieces,
            Description AS Description
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
	        NumberSoldPieces,
            Description
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
	        @numbersoldpieces,
            @description
        )";

        public const string UPDATE_SALE = @"
        UPDATE dbo.Venda
        SET SaleValue = @salevalue,
	        SalePaidValue = @salepaidvalue,
	        NumberSoldPieces = @numbersoldpieces,
	        Description = @description
	
        WHERE VendaId = @vendaid;
        ";

        #endregion

        #region Public methods

        public void UpdateSale(Guid vendaId, float saleValue, float salePaidValue, int numberSoldPieces, string description)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@vendaid", vendaId, System.Data.DbType.Guid);
            parameters.Add("@salevalue", saleValue, System.Data.DbType.Double);
            parameters.Add("@salepaidvalue", salePaidValue, System.Data.DbType.Double);
            parameters.Add("@numbersoldpieces", numberSoldPieces, System.Data.DbType.Int32);
            parameters.Add("@description", description, System.Data.DbType.AnsiString);

            Execute(UPDATE_SALE, parameters);
        }

        public void InsertNewSale(SaleEntity sale)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@vendaid", sale.VendaId, System.Data.DbType.Guid);
            parameters.Add("@usuarioid", sale.UsuarioId, System.Data.DbType.Guid);
            parameters.Add("@clienteid", sale.ClienteId, System.Data.DbType.Guid);
            parameters.Add("@username", sale.UserName, System.Data.DbType.AnsiString);
            parameters.Add("@clientname", sale.ClientName, System.Data.DbType.AnsiString);
            parameters.Add("@saledate", sale.SaleDate, System.Data.DbType.DateTime);
            parameters.Add("@salevalue", sale.SaleValue, System.Data.DbType.Double);
            parameters.Add("@salepaidvalue", sale.SalePaidValue, System.Data.DbType.Double);
            parameters.Add("@numbersoldpieces", sale.NumberSoldPieces, System.Data.DbType.Int32);
            parameters.Add("@description", sale.Description, System.Data.DbType.AnsiString);

            Execute(INSERT_NEW_SALE, parameters);
        }

        public List<SaleEntity> GetSalesByUserId(Guid usuarioId)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@usuarioid", usuarioId, System.Data.DbType.Guid);

            return Query(GET_SALES_BY_USER_ID, parameters).ToList();
        }

        public List<SaleEntity> GetAllSales()
        {
            return Query(GET_ALL_SALES).ToList();
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
