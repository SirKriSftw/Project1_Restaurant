using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RestAPP.Models
{
    public class DishModel
    {
        #region Columns / Properties
        public int dishID { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        #endregion
        SqlConnection conn = new SqlConnection(@"server=DESKTOP-TDTK0RJ\KRISSQL;Initial Catalog=RestaurantProj1;Persist Security Info=True;User ID=sa;Password=rev511");
        public List<DishModel> GetDishes()
        {
            string query = "SELECT * FROM Dishes";
            SqlCommand cmd = new SqlCommand(query, conn);
            List<DishModel> dishes = new List<DishModel>();
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (!reader.HasRows)
                    throw new Exception("No dishes found");
                while (reader.Read())
                {
                    dishes.Add(new DishModel()
                    {
                        dishID = reader.GetInt32(0),
                        name = reader.GetString(1),
                        price = reader.GetDouble(2),
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
            return dishes;
        }

        public DishModel GetDishByID(int dishID)
        {
            string query = "SELECT * FROM Dishes WHERE dishID=@dishID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@dishID", dishID);
            DishModel dish = new DishModel();
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    dish.dishID = dishID;
                    dish.name = reader.GetString(1);
                    dish.price = reader.GetDouble(2);
                }
                else
                {
                    throw new Exception("Dish not found");
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
            return dish;
        }

        public string AddDish(string name, double price)
        {
            string query = "INSERT INTO Dishes VALUES(@name, @price)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@price", price);
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

            return "Dish " + name + " added successfully";
        }

        public string EditDish(DishModel editDish)
        {
            string query = "UPDATE Dishes SET name=@name, price=@price WHERE dishID=@dishID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@dishID", editDish.dishID);
            cmd.Parameters.AddWithValue("@name", editDish.name);
            cmd.Parameters.AddWithValue("@price", editDish.price);

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

            return "Dish " + editDish.name + " updated successfully";
        }

        public string DelDish(int dishID)
        {
            string query = "DELETE FROM Dishes WHERE dishID = @dishID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@dishID", dishID);

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

            return "Dish " + dishID + " removed successfully";
        }
    }
}
