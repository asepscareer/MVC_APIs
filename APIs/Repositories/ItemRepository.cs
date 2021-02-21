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
    public class ItemRepository : IItemRepository
    {
        DynamicParameters parameters = new DynamicParameters();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        // Create
        public int Create(Item item)
        {
            var SP_Con = "SP_InsertItem";
            parameters.Add("@ItemName", item.ItemName);
            parameters.Add("@Quantity", item.Quantity);
            parameters.Add("@Price", item.Price);
            parameters.Add("@SupplierID", item.SupplierID);
            var Create = connection.Execute(SP_Con, parameters, commandType: System.Data.CommandType.StoredProcedure);
            return Create;
        }
        // Delete
        public int Delete(int Id)
        {
            var SP_Net = "SP_DeleteItem";
            parameters.Add("@Id", Id);
            var Delete = connection.Execute(SP_Net, parameters, commandType: CommandType.StoredProcedure);
            return Delete;

        }
        // Get All
        public IEnumerable<ViewItem> Get()
        {
            var SP_Net = "SP_GetItem";
            var Get = connection.Query<ViewItem>(SP_Net, commandType: CommandType.StoredProcedure);
            return Get;
        }
        // Update

        public int Update(Item item, int Id)
        {
            var SP_Net = "SP_UpdateItem";
            parameters.Add("@Id", Id);
            parameters.Add("@ItemName", item.ItemName);
            parameters.Add("@Quantity", item.Quantity);
            parameters.Add("@Price", item.Price);
            parameters.Add("@SupplierID", item.SupplierID);
            var Update = connection.Execute(SP_Net, parameters, commandType: CommandType.StoredProcedure);
            return Update;
        }
        // Get by Id
        public async Task<IEnumerable<ViewItem>> GetById(int Id)
        {
            var SP_Net = "SP_GetItemById";
            parameters.Add("@Id", Id);
            var Get = await connection.QueryAsync<ViewItem>(SP_Net, parameters, commandType: CommandType.StoredProcedure);
            return Get;
        }
        // End
    }
}