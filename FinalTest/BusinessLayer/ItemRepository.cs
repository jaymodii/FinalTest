using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ItemRepository : ItemInterface
    {
        private readonly string _connectionString;

        public ItemRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<ItemDTO> GetItemCodes()
        {
            List<ItemDTO> items = new();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetItemCodes", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ItemDTO item = new()
                        {
                            ItemCode = reader.GetInt32(0),
                            ItemName = reader.GetString(1)
                        };

                        items.Add(item);
                    }
                }
            }

            return items;
        }


        public string AddPriceChangeAndUpdateItem(PriceChangeDTO priceChangeDTO)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand("AddPriceChangeAndUpdateItem", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        string codes = string.Join(",", priceChangeDTO.ItemCodes);
                        command.Parameters.AddWithValue("@Itemcodes", codes);
                        command.Parameters.AddWithValue("@Increase_Decrease", priceChangeDTO.IncreaseDecrease);
                        command.Parameters.AddWithValue("@PriceType", priceChangeDTO.PriceType);
                        command.Parameters.AddWithValue("@PriceUpdate", priceChangeDTO.PriceUpdate);
                        command.Parameters.AddWithValue("@Amount", priceChangeDTO.PriceAmount);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                return "Price Updated";
            }catch (Exception ex)
            {
                return "Error Occured!";
            }
        }

    }
}
