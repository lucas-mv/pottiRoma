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
    public class ClientsRepository : BaseDataAccess<ClientEntity, ClientsQuery>
    {
        #region Instance

        private static ClientsRepository _instance;
        public static ClientsRepository Get()
        {
            if (_instance == null)
                _instance = new ClientsRepository();

            return _instance;
        }

        #endregion

        #region Selects

        private const string GET_BY_SALESPERSON_ID = @"
        SELECT ClienteId as ClientId, 
        VendedorId as SalespersonId, 
        Nome as Name, 
        Email as Email, 
        Telefone as Telephone, 
        Endereco as Address,
        Cpf as Cpf,
        DataAniversario as Birthdate
        FROM dbo.Cliente
        WHERE VendedorId = @vendedorid";

        #endregion

        #region Commands

        private const string INSERT_CLIENT = @"
        INSERT INTO dbo.Cliente 
        (
	        ClienteId, 
	        VendedorId, 
	        Nome, 
	        Email, 
	        Telefone, 
	        Endereco, 
	        Cpf,
            DataAniversario
        )
        VALUES 
        (
	        @clienteid, 
	        @vendedorid, 
	        @nome, 
	        @email, 
	        @telefone, 
	        @endereco, 
	        @cpf,
            @dataaniversario
        )";

        #endregion

        #region Private methods

        protected override IEnumerable<ClientEntity> Fill(IEnumerable<ClientEntity> entity, ClientsQuery query)
        {
            return entity;
        }

        #endregion

        #region Public methods

        public void InsertClient(ClientEntity client)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@clienteid", client.ClientId, System.Data.DbType.Guid);
            parameters.Add("@vendedorid", client.SalespersonId, System.Data.DbType.Guid);
            parameters.Add("@nome", client.Name, System.Data.DbType.AnsiString);
            parameters.Add("@email", client.Email, System.Data.DbType.AnsiString);
            parameters.Add("@telefone", client.Telephone, System.Data.DbType.AnsiString);
            parameters.Add("@cpf", client.Cpf, System.Data.DbType.AnsiString);
            parameters.Add("@endereco", client.Address, System.Data.DbType.AnsiString);
            parameters.Add("@dataaniversario", client.Birthdate, System.Data.DbType.DateTime);

            Execute(INSERT_CLIENT, parameters);
        }

        public List<ClientEntity> GetClientsBySalespersonId(Guid salespersonId)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@vendedorid", salespersonId, System.Data.DbType.Guid);

            return Query(GET_BY_SALESPERSON_ID, parameters).ToList();
        }

        #endregion

    }
}
