using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedikeeperAssignment.Models;
using Microsoft.Data.SqlClient;

namespace MedikeeperAssignment.Interfaces
{
    public interface IItemsService
    {
        public List<Item> GetAllMaxCost();
        public Item GetItemMaxCost(string itemName);
        public int CreateNewItem(Item item);
        public SqlCommand CreateSqlCommand(string storedProcName, SqlConnection connection, List<SqlParameter> parameters = default);
        public int UpdateItem(Item item);
        public int DeleteItem(Item item);
        
    }
}
