using APIs.Models;
using APIs.Repositories.Interface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace APIs.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        DynamicParameters parameters = new DynamicParameters();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        // Create
        public int Create(Supplier supplier)
        {
            var SP_Con = "SP_InsertSupplier";
            parameters.Add("@Name", supplier.Name);
            var Create = connection.Execute(SP_Con, parameters, commandType: System.Data.CommandType.StoredProcedure);
            return Create;
        }
        // Delete
        public int Delete(int Id)
        {
            var SP_Net = "SP_DeleteSupplier";
            parameters.Add("@Id", Id);
            var Delete = connection.Execute(SP_Net, parameters, commandType: CommandType.StoredProcedure);
            return Delete;

        }
        // Get All
        public IEnumerable<Supplier> Get()
        {
            var SP_Net = "SP_GetSupplier";
            var Get = connection.Query<Supplier>(SP_Net, commandType: CommandType.StoredProcedure);
            return Get;
        }
        // Update

        public int Update(Supplier supplier, int Id)
        {
            var SP_Net = "SP_UpdateSupplier";
            parameters.Add("@Id", Id);
            parameters.Add("@Name", supplier.Name);
            var Update = connection.Execute(SP_Net, parameters, commandType: CommandType.StoredProcedure);
            return Update;
        }
        // Get by Id
        public async Task<IEnumerable<Supplier>> GetById(int Id)
        {
            var SP_Net = "SP_GetSupplierById";
            parameters.Add("@Id", Id);
            var Get = await connection.QueryAsync<Supplier>(SP_Net, parameters, commandType: CommandType.StoredProcedure);
            return Get;
        }
        // End
    }
}