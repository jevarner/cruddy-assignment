using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MedikeeperAssignment.Interfaces;
using MedikeeperAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MedikeeperAssignment.Services
{
    public class ItemService : IItemsService
    {
        //Configuration that gets the connection string from the app settings
        private readonly IConfiguration configuration;

        //Connection strings that can be plugged into the GetConnectionString method without needing to retype the string itself
        private readonly string azureConnString = "azureConnString";

        //Stored Procedure names, easier to keep track of when centralized as well as plug in if necessary
        private readonly string getAllMaxCost = "Get_Max_Cost";
        private readonly string getMaxCostByItem = "Get_Item_Max_Cost";
        private readonly string createNewItem = "Create_New_Item";
        private readonly string deleteItem = "Delete_Item";

        public ItemService(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        public List<Item> GetAllMaxCost()
        {
            var itemList = new List<Item>();

            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString(azureConnString)))
            {
                connection.Open();

                var cmd = CreateSqlCommand(getAllMaxCost, connection);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    itemList.Add(new Item
                    {
                        ItemName = reader["ItemName"].ToString(),
                        Cost = Convert.ToInt32(reader["Cost"].ToString())
                    });
                }

                connection.Close();
            }

            return itemList;
        }

        public Item GetItemMaxCost(string itemName)
        {
            var item = new Item();

            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString(azureConnString)))
            {
                connection.Open();

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@ItemName", itemName)
                };

                var cmd = CreateSqlCommand(getMaxCostByItem, connection, parameters);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    item.ItemName = reader["ItemName"].ToString();
                    item.Cost = Convert.ToInt32(reader["Cost"].ToString());
                }

                connection.Close();
            }

            return item;
        }

        public int CreateNewItem(Item item)
        {
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString(azureConnString)))
            {
                connection.Open();

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@ItemName", item.ItemName),
                    new SqlParameter("@Cost", item.Cost)
                };

                var cmd = CreateSqlCommand(createNewItem, connection, parameters);

                return cmd.ExecuteNonQuery();
            };
        }

        public int DeleteItem(Item item)
        {
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString(azureConnString)))
            {
                connection.Open();

                var parameters = new List<SqlParameter>
                { 
                    new SqlParameter("@ID", item.Id)
                };

                var cmd = CreateSqlCommand(deleteItem, connection, parameters);

                return cmd.ExecuteNonQuery();
            }

        }

        public int UpdateItem(Item item)
        {
            using (SqlConnection connection = new SqlConnection(configuration.GetConnectionString(azureConnString)))
            {
                connection.Open();

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@ID", item.Id),
                    new SqlParameter("@ItemName", item.ItemName),
                    new SqlParameter("@Cost", item.Cost)
                };

                var cmd = CreateSqlCommand(deleteItem, connection, parameters);

                return cmd.ExecuteNonQuery();
            }
        }

        public SqlCommand CreateSqlCommand(string storedProcName, SqlConnection connection, List<SqlParameter> parameters = default)
        {
            var cmd = new SqlCommand(storedProcName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    cmd.Parameters.Add(param);
                }
            }
            
            return cmd;
        }
    }
}
