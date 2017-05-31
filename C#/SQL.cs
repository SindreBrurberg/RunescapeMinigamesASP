using System;
using System.Data.SqlClient;
using System.Text;

namespace SQL {
    class sql {
        private static string CS() {
			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "RunescapeMinigames.database.windows.net"; 
                builder.UserID = "Dethsanius";            
                builder.Password = "Pass!000";     
                builder.InitialCatalog = "RunescapeMinigames";
			return builder.ConnectionString;
		}
		public string getSQLUsers() {
			string stg = "";
			try 
            { 
                using (SqlConnection connection = new SqlConnection(CS()))
                {
                    connection.Open();       
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT TOP 20 [PK], [Name], [Skill], [TotalXP],[EventXP],[Points],[Level]");
                    sb.Append("FROM [dbo].[UserTest] ");
                    String sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
								StringBuilder sbUser = new StringBuilder();
								sbUser.Append(reader["PK"] + "\t");
								sbUser.Append(reader["Name"] + "\t");
								sbUser.Append(reader["Skill"] + "\t");
								sbUser.Append(reader["TotalXP"] + "\t");
								sbUser.Append(reader["EventXP"] + "\t");
								sbUser.Append(reader["Points"] + "\t");
								sbUser.Append(reader["Level"] + "\n");
								stg += sbUser.ToString();
								// Console.WriteLine(reader[0]);
                                //Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
								//stg += reader.GetString(0) + " " + reader.GetString(1) + "\n";
                            }
                        }
                    }                    
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
			return stg;
		}
		public static void addUser(string name, int Attack, int Strength, int Defence, int Ranged, int Prayer, int Magic, int Constitution, int Crafting, 
        int Mining, int Smithing, int Fishing, int Cooking, int Firemaking, int Woodcutting, int Runecrafting, int Dungeoneering, int Agility, 
        int Herblore, int Thieving, int Fletching, int Slayer, int Farming, int Construction, int Hunter, int Summoning, int Divination, int Invention, long Overall, string Clan) {
            int ClanID = 0;
			try 
            { 
                using (SqlConnection connection = new SqlConnection(CS()))
                {
                    connection.Open(); 
                    StringBuilder sbget = new StringBuilder();
                    sbget.Append("SELECT ID ");
                    sbget.Append("FROM [dbo].[Clan] ");
                    sbget.Append("where name=@Name");
                    String sqlGet = sbget.ToString();
                    using (SqlCommand command = new SqlCommand(sqlGet, connection))
                    {
                        command.Parameters.AddWithValue("@Name", Clan);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
								ClanID = Int32.Parse(reader["ID"].ToString());
                            }
                        }
                    } 
                    if (ClanID == 0) {
                        Console.WriteLine("Invalid Clan");
                        return;
                    }     
                    StringBuilder sb = new StringBuilder();
                    sb.Append("INSERT INTO [dbo].[User] ([Name], [Attack], [Strength], [Defence], [Ranged], [Prayer], [Magic], [Constitution], [Crafting], [Mining], [Smithing], [Fishing]");
                    sb.Append(", [Cooking], [Firemaking], [Woodcutting], [Runecrafting], [Dungeoneering], [Agility], [Herblore], [Thieving], [Fletching], [Slayer], [Farming]");
                    sb.Append(", [Construction], [Hunter], [Summoning], [Divination], [Invention], [Overall], [ClanID])");
                    sb.Append("VALUES (@Name, @Attack, @Strength, @Defence, @Ranged, @Prayer, @Magic, @Constitution, @Crafting, @Mining, @Smithing, @Fishing, @Cooking, @Firemaking");
                    sb.Append(", @Woodcutting, @Runecrafting, @Dungeoneering, @Agility, @Herblore, @Thieving, @Fletching, @Slayer, @Farming, @Construction, @Hunter, @Summoning, @Divination");
                    sb.Append(", @Invention, @Overall, @ClanID);");
                    String sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Attack", Attack);
                        command.Parameters.AddWithValue("@Strength", Strength);
                        command.Parameters.AddWithValue("@Defence", Defence);
                        command.Parameters.AddWithValue("@Ranged", Ranged);
                        command.Parameters.AddWithValue("@Prayer", Prayer);
                        command.Parameters.AddWithValue("@Magic", Magic);
                        command.Parameters.AddWithValue("@Constitution", Constitution);
                        command.Parameters.AddWithValue("@Crafting", Crafting);
                        command.Parameters.AddWithValue("@Mining", Mining);
                        command.Parameters.AddWithValue("@Smithing", Smithing);
                        command.Parameters.AddWithValue("@Fishing", Fishing);
                        command.Parameters.AddWithValue("@Cooking", Cooking);
                        command.Parameters.AddWithValue("@Firemaking", Firemaking);
                        command.Parameters.AddWithValue("@Woodcutting", Woodcutting);
                        command.Parameters.AddWithValue("@Runecrafting", Runecrafting);
                        command.Parameters.AddWithValue("@Dungeoneering", Dungeoneering);
                        command.Parameters.AddWithValue("@Agility", Agility);
                        command.Parameters.AddWithValue("@Herblore", Herblore);
                        command.Parameters.AddWithValue("@Thieving", Thieving);
                        command.Parameters.AddWithValue("@Fletching", Fletching);
                        command.Parameters.AddWithValue("@Slayer", Slayer);
                        command.Parameters.AddWithValue("@Farming", Farming);
                        command.Parameters.AddWithValue("@Construction", Construction);
                        command.Parameters.AddWithValue("@Hunter", Hunter);
                        command.Parameters.AddWithValue("@Summoning", Summoning);
                        command.Parameters.AddWithValue("@Divination", Divination);
                        command.Parameters.AddWithValue("@Invention ", Invention);
                        command.Parameters.AddWithValue("@Overall", Overall);
                        command.Parameters.AddWithValue("@ClanId", ClanID);
                        command.ExecuteNonQuery();
                    }         
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
		}
    }
}