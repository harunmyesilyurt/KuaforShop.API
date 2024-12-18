using KuaforShop.API.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace KuaforShop.API.Persistance
{
    public class SaloonRepository
    { 
        public List<mdlSaloons> GetAllSaloons()
        {
            var _connectionString = @"Server=DESKTOP-4MD8BH3\SQLEXPRESS;Database=KuaforShop;Integrated Security=True;TrustServerCertificate=True;";
            List<mdlSaloons> saloonsList = new List<mdlSaloons>();

            string query = "SELECT * FROM Saloons";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                mdlSaloons saloon = new mdlSaloons
                                {
                                    Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                    Name = reader["Name"]?.ToString(),
                                    Address = reader["Address"]?.ToString(),
                                    OpenTime = reader.GetTimeSpan(reader.GetOrdinal("OpenTime")),
                                    CloseTime = reader.GetTimeSpan(reader.GetOrdinal("CloseTime")),
                                    WorkDays = reader.GetInt32(reader.GetOrdinal("WorkDays")),
                                    Phone = reader["Phone"]?.ToString(),
                                    MyProperty = reader["MyProperty"]?.ToString(),
                                    SaloonType = reader.GetInt32(reader.GetOrdinal("SaloonType"))
                                };

                                saloonsList.Add(saloon);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata oluştu: " + ex.Message);
            }

            return saloonsList;
        }
    }
}
