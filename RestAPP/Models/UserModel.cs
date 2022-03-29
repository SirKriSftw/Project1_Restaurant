using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace RestAPP.Models
{
    public class UserModel
    {
        #region Columns / Properties
        public int userID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        public bool isAdmin { get; set; }
        #endregion
        SqlConnection conn = new SqlConnection(@"server=DESKTOP-TDTK0RJ\KRISSQL;Initial Catalog=RestaurantProj1;Persist Security Info=True;User ID=sa;Password=rev511");

        public List<UserModel> getUsers()
        {
            string query = "SELECT * FROM Users";
            SqlCommand cmd = new SqlCommand(query, conn);
            List<UserModel> users = new List<UserModel>();
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new UserModel()
                    {
                        userID = reader.GetInt32(0),
                        name = reader.GetString(3),
                        isAdmin = reader.GetBoolean(4)
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return users;
        }

        public UserModel getUser(int userID)
        {
            string query = "SELECT * FROM Users WHERE userID = @userID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@userID",userID);
            UserModel user = new UserModel();
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user.userID = userID;
                    user.name = reader.GetString(3);
                    user.isAdmin = reader.GetBoolean(4);
                }
                else
                {
                    throw new Exception("User not found");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return user;
        }

        public string addUser(UserModel newUser)
        {
            string query = "INSERT INTO Users VALUES(@username, @password, @name, @isAdmin)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username",newUser.username);
            cmd.Parameters.AddWithValue("@password", newUser.password);
            cmd.Parameters.AddWithValue("@name", newUser.name);
            cmd.Parameters.AddWithValue("@isAdmin", 0);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return "User " + newUser.name + " added successfully";
        }
    }
}
