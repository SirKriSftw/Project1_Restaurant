using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RestAPP.Models
{
    public class UserModel
    {
        #region Columns / Properties
        public int userID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string name { get; set; }
        #endregion
        SqlConnection conn = new SqlConnection(@"server=DESKTOP-TDTK0RJ\KRISSQL;Initial Catalog=RestaurantProj1;Persist Security Info=True;User ID=sa;Password=rev511");

        public List<UserModel> GetUsers()
        {
            string query = "SELECT * FROM Users";
            SqlCommand cmd = new SqlCommand(query, conn);
            List<UserModel> users = new List<UserModel>();
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                    throw new Exception("No users found");
                while (reader.Read())
                {
                    users.Add(new UserModel()
                    {
                        userID = reader.GetInt32(0),
                        name = reader.GetString(3),
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

        public UserModel GetUser(int userID)
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

        public string AddUser(UserModel newUser)
        {
            string query = "INSERT INTO Users VALUES(@username, @password, @name)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username",newUser.username);
            cmd.Parameters.AddWithValue("@password", newUser.password);
            cmd.Parameters.AddWithValue("@name", newUser.name);

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

        public string EditUser(UserModel editUser, string newPass)
        {
            string query = "UPDATE Users SET username=@username, password=@newPass, name=@name WHERE userID = @userID AND password=@password";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", editUser.username);
            cmd.Parameters.AddWithValue("@password", editUser.password);
            cmd.Parameters.AddWithValue("@name", editUser.name);
            cmd.Parameters.AddWithValue("@userID", editUser.userID);
            cmd.Parameters.AddWithValue("@newPass", newPass);

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

            return "User " + editUser.name + " updated";
        }

        public string DelUser(int userID)
        {
            string query = "DELETE FROM Users WHERE userID = @userID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@userID", userID);

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

            return "User " + userID + " removed successfully";
        }
    }
}
